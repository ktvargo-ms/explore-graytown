# Version-Managed Extensions: Cloud Ingest Edge Volume on a Ubuntu K3s Cluster with an SFTP Front End

This example can be used to create a ReadWriteMany Cloud Ingest Edge Volume on an Ubuntu K3s cluster and an SFTP front end. This allows you all the functionality of the base product as well as being able to accept writes from SFTP clients. 
Cloud Ingest edge volumes will transfer files saved to the volume to cloud and purge the local copy, according to your ingest policy. 

> ⚠️ **Disclaimer:** Version-managed extensions is currently in public preview. Access to the feature is limited and subject to specific terms and conditions. For further details and updates on availability, please refer to the [Version-managed extensoins for Arc-enabled Kubernetes](https://learn.microsoft.com/en-us/azure/azure-arc/kubernetes/managed-extensions).

### Set your environment variables
Use the following table to determine the values to be used in the export block below. If you exit your shell during configuration before you have completed all the steps, you must re-export the variables before continuing.  

|Variable        | Required Parameter                                             | Example |
|----------------|----------------------------------------------------------------|-----------------|
|YOUR-REGION          | Azure Region you wish to deploy in                             | eastus          |
|YOUR-RESOURCE-GROUP  | The Resource Group you created with the storage account in it  | myResourceGroup |
|YOUR-SUBSCRIPTION    | The Azure Subscription ID you are using                        | nnnn-nnnnnnn-nnn|
|YOUR-CLUSTER-NAME        | The name you would like your ARC cluster to be called in Azure | myArcClusterName|
|YOUR-STORAGEACCOUNT  | The name of the storage account you created                    | myStorageAccount|

```bash
export YOUR-REGION="eastus"
export YOUR-RESOURCE-GROUP="myResourceGroup"
export YOUR-SUBSCRIPTION="your-subscription-id-here"
export YOUR-CLUSTER-NAME="myArcClusterName"
export YOUR-STORAGEACCOUNT="myStorageAccountName"
```
### Configure ACSA 

```bash
az k8s-extension update --resource-group "${YOUR-RESOURCE-GROUP}" --cluster-name "${YOUR-CLUSTER-NAME}" --cluster-type connectedClusters --name azure.arc.containerstorage --config feature.diskStorageClass="default,local-path" --config  edgeStorageConfiguration.create=true
```

### Assign role to storage account

```bash
export pid=`az k8s-extension list --cluster-name "${YOUR-CLUSTER-NAME}" --resource-group "${YOUR-RESOURCE-GROUP}" --cluster-type connectedClusters | jq --arg extType "microsoft.arc.containerstorage" 'map(select(.extensionType == $extType)) | .[] | .identity.principalId' -r`
az role assignment create --assignee $pid --role "Storage Blob Data Owner" --scope "/subscriptions/${YOUR-SUBSCRIPTION}/resourceGroups/${YOUR-RESOURCE-GROUP}/providers/Microsoft.Storage/storageAccounts/${YOUR-STORAGEACCOUNT}"
```

### Configure ACSA with an SFTP Front End

For this example, all the necessary components were packaged in deployment.yaml; this includes the PVC creation, the Ingest Subvolume config, and the SFTP setup. Make any necessary changes to deployment.yaml before running it. For more information about the cloud connected storage account setting, see [here](https://learn.microsoft.com/azure/azure-arc/container-storage/cloud-ingest-edge-volume-configuration?tabs=portal#attach-subvolume-to-edge-volume).

```bash
kubectl apply -f deployment.yaml
```

### Start writing files to your SFTP Server

1. Let's create a sample file to push through to make sure our server setup is working.
   
 ```bash
 echo "Hello World! I'm so glad my SFTP front end is working with ACSA!" > testfile1.txt
 ```

2. Run the following command to get the IP address of your SFTP server, and note it for the next step:
   
 ```bash
 kubectl get service
 ```

3. Next, we will run the SFTP command. For our example, the user and password are both 'demo,' but you will want to change those to be something meaningful and secure.
   
 ```bash
 sftp demo@IPADDRESS
 ```

You'll have to enter your password here.

4. **From here, you'll need to change directories to the location you specified. In this example, it's /config/acsa/exampleSubDir.**
   
 ```bash
 cd /config/acsa/exampleSubDir
 ```

5. Then, we can put our file using:
   
 ```bash
 put testfile1.txt
 ```

### Confirm your file is uploaded

Finally, we can go to the Azure Portal and check our specified storage account container in our specified storage account. Our testfile1.txt should be there.
Note: Please keep in mind that we have set up this system with the default Ingest Policy, which waits 5 minutes after a file is written before it will upload it to the cloud. So if you don't see your file right away, just wait a few minutes. Policies can also be altered according to [these instructions](https://learn.microsoft.com/azure/azure-arc/container-storage/cloud-ingest-edge-volume-configuration?tabs=portal#optional-modify-the-ingestpolicy-from-the-default).

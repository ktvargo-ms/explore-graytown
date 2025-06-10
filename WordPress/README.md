# GT
GT testing with WordPress

Initial instructions at https://kubernetes.io/docs/tutorials/stateful-application/mysql-wordpress-persistent-volume/
Files modified to use VME

##Apply and Verify
The kustomization.yaml contains all the resources for deploying a WordPress site and a MySQL database. You can apply the directory by
```bash
kubectl apply -k ./
```
Now you can verify that all objects exist.

1. Verify that the Secret exists by running the following command:
```bash
kubectl get secrets
```
The response should be like this:
```bash
NAME                    TYPE                                  DATA   AGE
mysql-pass-c57bb4t7mf   Opaque                                1      9s
```
2. Verify that a PersistentVolume got dynamically provisioned.
```bash
kubectl get pvc
```
>Note:
It can take up to a few minutes for the PVs to be provisioned and bound.
The response should be like this:
```bash
NAME             STATUS    VOLUME                                     CAPACITY   ACCESS MODES   STORAGECLASS       AGE
mysql-pv-claim   Bound     pvc-8cbd7b2e-4044-11e9-b2bb-42010a800002   20Gi       RWO            standard           77s
wp-pv-claim      Bound     pvc-8cd0df54-4044-11e9-b2bb-42010a800002   20Gi       RWO            standard           77s
```
3. Verify that the Pod is running by running the following command:
```bash
kubectl get pods
```
>Note:
It can take up to a few minutes for the Pod's Status to be RUNNING.
The response should be like this:
```bash
NAME                               READY     STATUS    RESTARTS   AGE
wordpress-mysql-1894417608-x5dzt   1/1       Running   0          40s
```
4. Verify that the Service is running by running the following command:
```bash
kubectl get services wordpress
```
The response should be like this:
```bash
NAME        TYPE            CLUSTER-IP   EXTERNAL-IP   PORT(S)        AGE
wordpress   LoadBalancer    10.0.0.89    <pending>     80:32406/TCP   4m
```
>Note:
Minikube can only expose Services through NodePort. The EXTERNAL-IP is always pending.
5. Run the following command to get the IP Address for the WordPress Service:

minikube service wordpress --url
The response should be like this:

http://1.2.3.4:32406
Copy the IP address, and load the page in your browser to view your site.

You should see the WordPress set up page similar to the following screenshot.

wordpress-init

Warning:
Do not leave your WordPress installation on this page. If another user finds it, they can set up a website on your instance and use it to serve malicious content.

Either install WordPress by creating a username and password or delete your instance.
Cleaning up
Run the following command to delete your Secret, Deployments, Services and PersistentVolumeClaims:

kubectl delete -k ./

Getting Started with Wordpress
Since this is a brand new Wordpress site, you will need to complete the initial setup which creates the Database schema and populates it with seed data as well as creates the wp-config.php file to read the configuration from the environment variables.

To do this, you will first need to map the FQDN of the site you specified when provisioning the template to the public IP address of the Azure Application Gateway. You can do this by either adding an entry to your pubcic dns zone or simply by adding an entry to your hosts file.

Once you have mapped the FQDN to the public IP address, you can navigate to the site in your browser and complete the initial setup.

New WordPress instance
Navigate to the http://FQDN using your browser

Select the wordpress language and click Continue Setup

Fill in the site title, the administrator username, password, and email address and click Install WordPress

Setup

Now you can navigate to the site in your browser and login using the username and password you specified during the setup to access the administration console or navigate to the site to see it.

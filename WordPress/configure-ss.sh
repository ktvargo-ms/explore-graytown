export RESOURCE_GROUP="AzureArcTest"
export CLUSTER_NAME="AzureArcTest1"
export LOCATION="EastUS"
export SUBSCRIPTION="$(az account show --query id --output tsv)"
az account set --subscription "${SUBSCRIPTION}"
export AZURE_TENANT_ID="$(az account show -s $SUBSCRIPTION --query tenantId --output tsv)"
export CURRENT_USER="$(az ad signed-in-user show --query userPrincipalName --output tsv)"
export KEYVAULT_NAME="my-kv"
export KEYVAULT_SECRET_NAME="my-secret"
export USER_ASSIGNED_IDENTITY_NAME="my-identity"
export FEDERATED_IDENTITY_CREDENTIAL_NAME="my-credential"
export KUBERNETES_NAMESPACE="my-namespace"
export SERVICE_ACCOUNT_NAME="my-service-account"
az connectedk8s connect --name ${CLUSTER_NAME} --resource-group ${RESOURCE_GROUP} --enable-oidc-issuer --enable-workload-identity
az connectedk8s update --name ${CLUSTER_NAME} --resource-group ${RESOURCE_GROUP} --enable-oidc-issuer --enable-workload-identity
az keyvault create --resource-group "${RESOURCE_GROUP}" --location "${LOCATION}" --name "${KEYVAULT_NAME}" --enable-rbac-authorization
az role assignment create --role "Key Vault Secrets Officer" --assignee ${CURRENT_USER} --scope /subscriptions/${SUBSCRIPTION}/resourcegroups/${RESOURCE_GROUP}/providers/Microsoft.KeyVault/vaults/${KEYVAULT_NAME}
az keyvault secret set --vault-name "${KEYVAULT_NAME}" --name "${KEYVAULT_SECRET_NAME}" --value 'Hello!'
az keyvault secret set --vault-name "${KEYVAULT_NAME}" --name "${KEYVAULT_SECRET_NAME}" --value 'Hello2'
az identity create --name "${USER_ASSIGNED_IDENTITY_NAME}" --resource-group "${RESOURCE_GROUP}" --location "${LOCATION}" --subscription "${SUBSCRIPTION}"
export USER_ASSIGNED_CLIENT_ID="$(az identity show --resource-group "${RESOURCE_GROUP}" --name "${USER_ASSIGNED_IDENTITY_NAME}" --query 'clientId' -otsv)"
az role assignment create --role "Key Vault Reader" --assignee "${USER_ASSIGNED_CLIENT_ID}" --scope /subscriptions/${SUBSCRIPTION}/resourcegroups/${RESOURCE_GROUP}/providers/Microsoft.KeyVault/vaults/${KEYVAULT_NAME}
az role assignment create --role "Key Vault Secrets User" --assignee "${USER_ASSIGNED_CLIENT_ID}" --scope /subscriptions/${SUBSCRIPTION}/resourcegroups/${RESOURCE_GROUP}/providers/Microsoft.KeyVault/vaults/${KEYVAULT_NAME}
kubectl create ns ${KUBERNETES_NAMESPACE}

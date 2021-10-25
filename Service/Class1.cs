using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class KeyVaultService
    {
        public async Task<string> GetSecretValue(string keyName)
        {
            string secret = "";
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            //slow without ConfigureAwait(false)    
            //keyvault should be keyvault DNS Name    
            var secretBundle = await keyVaultClient.GetSecretAsync(
                //Environment.GetEnvironmentVariable("keyvault")
                "https://d365-config-keys.vault.azure.net/secrets/"
                + keyName).ConfigureAwait(false);
            secret = secretBundle.Value;
            Console.WriteLine(secret);
            return secret;
        }
    }
}
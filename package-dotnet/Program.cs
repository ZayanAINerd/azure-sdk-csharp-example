using Azure;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

class Program
{
    static async Task Main(string[] args)
    {
        //string subscriptionId = "f206fbcd-97dd-4d6a-af6f-435d3a2847cd";
        string resourceGroupName = "my-sdk-rg";
        // AzureLocation location = AzureLocation.WestUS2;
        string location = "westus";

        // Authenticate with Azure
        var credential = new DefaultAzureCredential();

        // Inititalize Azure ARM Client
        var client = new ArmClient(credential);

        // Create or get access to the resource group
        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);

        Console.WriteLine("Storage account created successfully.");
    }
}
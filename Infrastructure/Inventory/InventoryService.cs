using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Network;

namespace CleanArchitecture.Infrastructure.Inventory;

public sealed class InventoryService
    : IInventoryService
{
    // Note: these are hard coded to keep the demo simple
    private const string AddressTemplate = "https://abc123.com/inventory/products/{0}/notifysaleoccured/";

    private const string JsonTemplate = "{{\"quantity\": {0}}}";

    private readonly IHttpClientWrapper _client;

    public InventoryService(IHttpClientWrapper client) => _client = client;

    public void NotifySaleOccurred(int productId, int quantity)
    {
        string address = string.Format(AddressTemplate, productId);

        string json = string.Format(JsonTemplate, quantity);

        _client.Post(address, json);
    }
}

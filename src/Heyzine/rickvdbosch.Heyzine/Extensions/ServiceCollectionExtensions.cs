using Microsoft.Extensions.DependencyInjection;

namespace RvdB.Heyzine.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHeyzine(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient(Constants.HTTPCLIENT_NAME, client =>
        {
            client.BaseAddress = new Uri(Constants.API_URL);
        }); 
        serviceCollection.AddTransient<IHeyzineRestClient, HeyzineRestClient>();

        return serviceCollection;
    }
}

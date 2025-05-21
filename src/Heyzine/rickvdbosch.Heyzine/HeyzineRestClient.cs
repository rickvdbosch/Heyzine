using System.Net.Http.Json;

using rickvdbosch.Heyzine.Exceptions;

namespace rickvdbosch.Heyzine;

public class HeyzineRestClient : IHeyzineRestClient
{
    #region Private fields

    private readonly HttpClient _httpClient;
    private readonly string _clientId;

    #endregion

    #region Constructors

    public HeyzineRestClient(IHttpClientFactory httpClientFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        var clientId = Environment.GetEnvironmentVariable(Constants.CLIENTID_SETTINGNAME);
        if (string.IsNullOrEmpty(clientId))
        { 
            throw new EnvironmentVariableNotSetException(Constants.CLIENTID_SETTINGNAME);
        }
        _clientId = clientId;
        _httpClient = httpClientFactory.CreateClient(Constants.HTTPCLIENT_NAME);
    }

    #endregion

    public async Task<Response?> ConvertPdfAsync(Uri pdfLocation)
    {
        Request request = new(pdfLocation, _clientId);
        var response = await _httpClient.PostAsJsonAsync(Constants.API_REST_POSTFIX, request);

        return await response.Content.ReadFromJsonAsync<Response>();
    }
}

using System.Net;
using System.Text.Json;

using Moq;
using Moq.Protected;

using rickvdbosch.Heyzine.Exceptions;
using rickvdbosch.Heyzine.Models;

namespace rickvdbosch.Heyzine.Tests;

public class HeyzineRestClientTests
{
    IHttpClientFactory mockHttpClientFactory;

    public HeyzineRestClientTests()
    {
        Response response = new()
        {
            Id = "success",
            Url = new Uri("https://heyzine.com/test"),
            Thumbnail = new Uri("https://heyzine.com/test/thumbnail"),
            Pdf = new Uri("https://heyzine.com/test.pdf"),
            Metadata = new Metadata()
            {
                NumberOfPages = 10,
                AspectRatio = 1.5f
            }
        };
        var mockFactory = new Mock<IHttpClientFactory>();
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            { 
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(response))
            });
        mockFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(Constants.API_URL)
            });
        mockHttpClientFactory = mockFactory.Object;
    }

    [Fact]
    public void Constructor_WhenIHttpClientFactoryNull_ShouldThrow()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => new HeyzineRestClient(null));

        Assert.Equal("httpClientFactory", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenClientIdNotSet_ShouldThrow()
    {
        Environment.SetEnvironmentVariable(Constants.CLIENTID_SETTINGNAME, null);

        var exception = Assert.Throws<EnvironmentVariableNotSetException>(() => new HeyzineRestClient(mockHttpClientFactory));

        Assert.Equal(string.Format(Constants.ERRORS_ENVVAR_NOTSET, Constants.CLIENTID_SETTINGNAME), exception.Message);
    }

    [Fact]
    public void Constructor_WhenClientIdSet_ShouldInitializeClient()
    {
        Environment.SetEnvironmentVariable(Constants.CLIENTID_SETTINGNAME, "testClientId");

        var client = new HeyzineRestClient(mockHttpClientFactory);

        Assert.NotNull(client);
        Assert.IsType<HeyzineRestClient>(client);
        Assert.NotNull(client.GetType().GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
    }

    [Fact]
    public async Task ConvertPdfAsync_WhenParametersSet_ShouldReturnResponse()
    {
        Environment.SetEnvironmentVariable(Constants.CLIENTID_SETTINGNAME, "testClientId");

        var client = new HeyzineRestClient(mockHttpClientFactory);
        var pdfLocation = new Uri("https://example.com/test.pdf");

        var response = await client.ConvertPdfAsync(pdfLocation);

        Assert.NotNull(response);
        Assert.IsType<Response>(response);
    }
}

using System.Text.Json.Serialization;

namespace RvdB.Heyzine.Models;

public class Request(Uri pdfUrl, string clientId)
{
    [JsonPropertyName("pdf")]
    public Uri PdfUrl { get; set; } = pdfUrl;

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = clientId;
}

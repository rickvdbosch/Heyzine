using System.Text.Json.Serialization;

namespace RvdB.Heyzine.Models;

public class Response
{
    public string Id { get; set; }

    public Uri Url { get; set; }

    public Uri Thumbnail { get; set; }

    public Uri Pdf { get; set; }

    [JsonPropertyName("meta")]
    public Metadata Metadata { get; set; }
}

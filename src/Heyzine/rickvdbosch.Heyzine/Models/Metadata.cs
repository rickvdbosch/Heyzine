using System.Text.Json.Serialization;

namespace rickvdbosch.Heyzine.Models;

public class Metadata
{
    [JsonPropertyName("num_pages")]
    public int NumberOfPages { get; set; }

    [JsonPropertyName("aspect_ratio")]
    public float AspectRatio { get; set; }
}

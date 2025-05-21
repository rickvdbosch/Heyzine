using System.Text.Json.Serialization;

namespace RvdB.Heyzine.Models;

public class Metadata
{
    [JsonPropertyName("num_pages")]
    public int NumberOfPages { get; set; }

    [JsonPropertyName("aspect_ratio")]
    public float AspectRatio { get; set; }
}

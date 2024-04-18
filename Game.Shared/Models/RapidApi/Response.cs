using System.Text.Json.Serialization;

namespace Game.Shared.Models.RapidApi;

public record Response<T>
{
    [JsonPropertyName("response")]
    public T[] Results { get; init; } = [];
}
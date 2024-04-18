using System.Text.Json.Serialization;

namespace Game.Shared.Models;

public record Team
{
    [JsonPropertyName("team")]
    public required Information Information { get; init; }

    public required Venue Venue { get; init; }
}

public record Information
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Logo { get; init; }
}

public record Venue
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public string Address { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public int Capacity { get; init; }
    public string Surface { get; init; } = string.Empty;
    public required string Image { get; init; }
}
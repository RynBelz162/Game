namespace Game.Configuration;

public record FootballApi
{
    public required string ApiKey { get; init; }
    public required string Url { get; init; }
}
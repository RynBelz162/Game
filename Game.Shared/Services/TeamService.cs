using Game.Shared.Clients;
using Game.Shared.Constants;
using Game.Shared.Models;

namespace Game.Shared.Services;

public class TeamService(ApiFootballClient apiFootballClient)
{
    private static readonly Dictionary<int, Team[]> _teams = [];

    public async Task<Team> GetRandomTeam()
    {
        var (leagueId, year) = GetRandomLeague();
        if (!_teams.ContainsKey(leagueId))
        {
            await RefreshTeamForLeague(leagueId, year);
        }

        var teams = _teams[leagueId];
        var index = new Random().Next(0, teams.Length);
        return teams[index];
    }

    private async Task RefreshTeamForLeague(int leagueId, int year)
    {
        var teams = await apiFootballClient.GetTeamsForLeague(leagueId, year);
        _teams.TryAdd(leagueId, teams);
    }

    private static (int Id, int Year)[] Leagues => [
        ( LeagueIds.PremierLeague, DateTime.Now.AddYears(-1).Year ),
        ( LeagueIds.BundesLiga, DateTime.Now.AddYears(-1).Year ),
        ( LeagueIds.LaLiga, DateTime.Now.AddYears(-1).Year ),
        ( LeagueIds.SerieA, DateTime.Now.AddYears(-1).Year ),
        ( LeagueIds.MajorLeagueSoccer, DateTime.Now.Year)
    ];

    private static (int Id, int Year) GetRandomLeague()
    {
        var index = new Random().Next(0, Leagues.Length);
        return Leagues[index];
    }
}
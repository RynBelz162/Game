using Game.Models;
using Game.Models.RapidApi;

namespace Game.Clients;

public class ApiFootballClient(HttpClient httpClient)
{
    public async Task<Team[]> GetTeamsForLeague(int leagueId, int seasonYear)
    {
        string url = $"/teams?league={leagueId}&season={seasonYear}";
        var request = await httpClient.GetAsync(url);

        request.EnsureSuccessStatusCode();
        var response = await request.Content.ReadFromJsonAsync<Response<Team>>() ?? new Response<Team>();
        return response.Results;
    }
}
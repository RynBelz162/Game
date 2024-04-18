using Game.Shared.Clients;
using Game.Components;
using Game.Shared.Configuration;
using Game.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<ApiFootballClient>(
    client =>
    {
        var settings = builder.Configuration.GetSection("FootballApi").Get<FootballApi>() 
            ?? throw new NullReferenceException("Football Api settings are null");

        client.BaseAddress = new Uri(settings.Url);
        client.DefaultRequestHeaders.Add("X-Rapidapi-Key", settings.ApiKey);
    });

builder.Services.AddSingleton<TeamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Game.Client._Imports).Assembly);

app.Run();

using TriviaR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddSingleton<GameFactory>();

// This needs to be transient as the GameFactory manages the lifetime
// of Game
builder.Services.AddTransient<Game>();

// We only have a single client so we'll use the empty name
builder.Services.AddHttpClient(string.Empty, client =>
{
    client.BaseAddress = new Uri("https://the-trivia-api.com/api/questions");
});

var app = builder.Build();

app.MapHub<GameHub>("/trivia");

app.Run();

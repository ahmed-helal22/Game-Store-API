using GameStore.Api.Dtos;
namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
    const string GetGameEndpointName="GetGame";
    private static readonly List<GameDto> games =[
    new(
        1,
        "The Legend of Zelda",
        "Action-adventure",
        2017,
        new DateOnly(1988, 8, 21)
    ),
    new(
        2,
        "Final Fantasy VII Rebirth",
        "RPG",
        69.99m,
        new DateOnly(2024, 2, 29)
    ),
    new(
        3,
        "Astro Bot",
        "Platformer",
        59.99m,
        new DateOnly(2024, 9, 6)
    )
];
public static void MapGamesEndpoints(this WebApplication app)
{
var group=app.MapGroup("/games");//isnted of /games and app    
group.MapGet("/", () => games);//get all games
app.MapGet("/games/{id}", (int id) =>
{
    var game= games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() :Results.Ok(game);
})
    .WithName("GetGame");
//create
app.MapPost("/games", (CreateGameDto newGame) =>//create new game
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);
    return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
});

//Update
app.MapPut("/games/{id}",(int id,UpdateGameDto updatedgame)=>
{
    var index = games.FindIndex(game =>game.Id==id);
    if(index ==-1){return Results.NotFound();}
    games[index]=new GameDto
    (
        id ,
        updatedgame.name ,
        updatedgame.genre,
        updatedgame.price,
        updatedgame.RelaseDate
    );
    return Results.NoContent();
});

//delete 
app.MapDelete("/games/{id}",(int id)=>
{
    games.RemoveAll(game=>game.Id==id);
    return Results.NoContent();
});    
        }
}
}
namespace GameStore.Api.Dtos;
    public record UpdateGameDto
    (
        string name,
        string genre,
        decimal price,
        DateOnly RelaseDate        
    );
        
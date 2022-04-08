using Films.Infrastructure.Database;
using MediatR;

namespace Films.Sturtup.Features.Post;

public class CreateNewFilmCommand : IRequest<bool>
{

}

public class CreateNewPostCommandHandler : IRequestHandler<CreateNewFilmCommand, bool>
{
    private readonly FilmDbContext _filmContext;

    public CreateNewPostCommandHandler(FilmDbContext filmContext)
    {
        _filmContext = filmContext;
    }

    public async Task<bool> Handle(CreateNewFilmCommand request, CancellationToken cancellationToken)
    {
        var film = new Core.Domain.Model.Film()
        {
            Name = "Шрек",
            Link = "https://www.kinopoisk.ru/film/430/",
            Review = "О хорошем парне",
            DateCreate = "2001"
        };

        await _filmContext.Films.AddAsync(film, cancellationToken);
        var result = await _filmContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
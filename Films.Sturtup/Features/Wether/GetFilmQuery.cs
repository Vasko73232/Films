using Films.Core.Domain.Model;
using Films.Core.Domain.SharedKernel.Repository;
using Microsoft.AspNetCore.Mvc;
using Films.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Films.Sturtup.Features.Wether;

public class GetFilmQuery : MediatR.IRequest<Film>
{
    [FromQuery]
    public long FilmId { get; set; }
}

public class GetFilmQueryHandler : MediatR.IRequestHandler<GetFilmQuery, Film>
{
    private readonly FilmDbContext _filmContext;

    public GetFilmQueryHandler(FilmDbContext filmContext)
    {
        _filmContext = filmContext;
    }
    
    public async Task<Film> Handle(GetFilmQuery request, CancellationToken cancellationToken)
    {
        var film = await _filmContext.Films.FirstOrDefaultAsync(x => x.Id == request.FilmId, cancellationToken);        
        return film;
    }
}
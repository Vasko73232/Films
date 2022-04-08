using Films.Sturtup.Features.Post;
using Films.Sturtup.Features.Wether;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Films.Sturtup.Controllers;

public class FilmController : Controller
{
    private readonly ILogger<FilmController> _logger;
    private readonly IMediator _mediator;

    public FilmController(ILogger<FilmController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("~/getFilm")]
    public async Task<IActionResult> GetlisеFilm(GetFilmQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("~/createNewFilm")]
    public async Task<IActionResult> CreateNewFilm(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateNewFilmCommand(), cancellationToken);
        return Ok();
    }
}
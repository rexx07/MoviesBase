using Mb.Application.Common.Models;
using Mb.Application.Common.Security;
using Mb.Application.Movies.Commands;
using Mb.Application.Movies.Models;
using Mb.Application.Movies.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mb.WebApp.Controllers;

[Authorize]
public class MovieController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<MovieDto>>> GetMoviesWithPagination(
        [FromQuery] GetAllMoviesQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMovieById([FromRoute] GetMovieByIdQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateMovieCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateMovieCommand command)
    {
        if (id != command.Id)
            return BadRequest();
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteMovieCommand(id));

        return NoContent();
    }
}
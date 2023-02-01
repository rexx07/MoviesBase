using Mb.Application.Common.Exceptions;
using Mb.Application.Common.Interfaces;
using Mb.Domain.Events.Movie;
using MediatR;

namespace Mb.Application.Movies.Commands;

public record DeleteMovieCommand(Guid Id) : IRequest;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Id);

        _context.Movies.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new MovieDeletedEvent(entity));

        return Unit.Value;
    }
}
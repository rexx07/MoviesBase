using Mb.Application.Common.Exceptions;
using Mb.Application.Common.Interfaces;
using MediatR;

namespace Mb.Application.TvShows.Commands;

public record DeleteTvShowCommand(Guid Id) : IRequest;

public class DeleteTvShowCommandHandler : IRequestHandler<DeleteTvShowCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTvShowCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTvShowCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TvShows
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Id);

        _context.TvShows.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new TvS);
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mb.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Movies.Queries;

public record ExportMoviesQuery : IRequest<ExportMoviesVm>
{
    public Guid ListId { get; init; }
}

public class ExportMoviesQueryHandler : IRequestHandler<ExportMoviesQuery, ExportMoviesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly IMapper _mapper;

    public ExportMoviesQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportMoviesVm> Handle(ExportMoviesQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Movies
            .Where(t => t.ListId == request.ListId)
            .ProjectTo<MovieItemFileRecord>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var vm = new ExportMoviesVm(
            "MovieItems.csv",
            "text/csv",
            _fileBuilder.BuildMovieItemsFile(records));

        return vm;
    }
}
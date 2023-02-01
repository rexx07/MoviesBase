using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mb.Application.Common.Interfaces;
using Mb.Application.Common.Mappings;
using Mb.Application.Common.Models;
using Mb.Application.Common.Security;
using Mb.Application.Movies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Movies.Queries;

[Authorize]
public class GetAllMoviesQuery : IRequest<PaginatedList<MovieDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, PaginatedList<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var movieList = await _context.Movies
            .Include(m => m.ProductionCompanies)
            .AsNoTracking()
            .OrderBy(t => t.Title)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return movieList;
    }
}
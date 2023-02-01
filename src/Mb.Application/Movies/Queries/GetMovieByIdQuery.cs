using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mb.Application.Common.Interfaces;
using Mb.Application.Movies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Movies.Queries;

public class GetMovieByIdQuery : IRequest<MovieDto>
{
    public Guid Id { get; set; }
}

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .Where(m => m.Id == request.Id)
            .Include(m => m.GenreIds)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return movie;
    }
}
using FluentValidation;
using Mb.Application.Common.Interfaces;
using Mb.Domain.Entities;
using MediatR;

namespace Mb.Application.Members.Command;

public class CreateMemberCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string FName { get; set; }
    public string MName { get; set; }
    public string LName { get; set; }
    public string CountryOfOrigin { get; set; }
    public DateOnly DOB { get; set; }
    public DateOnly CareerStart { get; set; }
    public DateOnly? CareerEnd { get; set; }
    public List<Guid> MovieIds { get; set; }
    public List<Guid> TvShowIds { get; set; }
    public bool IsCast { get; set; }
}

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMemberCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var entity = new Member
        {
            FName = request.FName,
            MName = request.MName,
            LName = request.LName,
            CountryOfOrigin = request.CountryOfOrigin,
            DOB = request.DOB,
            CareerStart = request.CareerStart,
            CareerEnd = request.CareerEnd,
            MovieIds = request.MovieIds,
            TvShowIds = request.TvShowIds,
            IsCast = request.IsCast
        };

        await _context.Members.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

public class CreateMemberCommendValidator : AbstractValidator<CreateMemberCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMemberCommendValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.FName)
            .MaximumLength(50).WithMessage("First name must not be more than.")
            .NotEmpty().WithMessage("Please insert name.");
        RuleFor(m => m.LName)
            .MaximumLength(50).WithMessage("Last name must not be more than.")
            .NotEmpty().WithMessage("Please insert last name.");
    }
}
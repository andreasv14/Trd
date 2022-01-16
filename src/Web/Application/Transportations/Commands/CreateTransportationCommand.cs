using Application.Common.Interfaces;
using Domain.Enums;

namespace Application.Transportations.Commands;

public class CreateTransportationCommand : IRequest<int>
{
    public string Code { get; set; }

    public string Description { get; set; }

    public Region Region { get; set; }
}

public class CreateTransportationCommandHandler : IRequestHandler<CreateTransportationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTransportationCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTransportationCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
        {
            throw new ValidationException("Code is null or empty");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ValidationException("Description is null or empty");
        }

        var newTransportation = new Domain.Entities.Transportation
        {
            Code = request.Code,
            Description = request.Description,
            Region = 0,
        };


        await _context.Transportations.AddAsync(newTransportation);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}

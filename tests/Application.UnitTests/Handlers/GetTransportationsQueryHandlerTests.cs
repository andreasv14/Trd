using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Application.Common.Interfaces;
using Application.UnitTests.Helpers;
using Application.Transportations.Queries;

namespace Application.UnitTests.Handlers;

public class GetTransportationsQueryHandlerTests
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTransportationsQueryHandlerTests()
    {
        _context = DataSourceHelper.GetSetupInMemoryDbContext();

        DataSourceHelper.SeedData(_context);

        _mapper = AutoMapperHelper.CreateMapper();
    }

    [Fact]
    public async Task Handler_GetTransportations_ReturnTransportations()
    {
        var request = new GetTransportationsQuery();

        var getTransportationsQueryHandler = new GetTransportationsQueryHandler(_context, _mapper);
        var response = await getTransportationsQueryHandler.Handle(request, new System.Threading.CancellationToken());


        Assert.True(response.Any());
    }
}

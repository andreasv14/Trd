namespace Application.UnitTests.Handlers;

public class CreateTransportationCommandHandlerTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task Handle_TransportationCodeIsNullOrEmpty_ThrowsValidationExceptionException(string code)
    {
        var context = DataSourceHelper.GetSetupInMemoryDbContext();

        var createTransportationCommandHandler = new CreateTransportationCommandHandler(context);

        var command = new CreateTransportationCommand
        {
            Code = code,
            Description = "A11",
        };

        await Assert.ThrowsAsync<ValidationException>(async () => await createTransportationCommandHandler.Handle(command, new System.Threading.CancellationToken()));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task Handle_TransportationDescriptionIsNullOrEmpty_ThrowsValidationException(string description)
    {
        var context = DataSourceHelper.GetSetupInMemoryDbContext();

        var createTransportationCommandHandler = new CreateTransportationCommandHandler(context);

        var command = new CreateTransportationCommand
        {
            Code = "A100",
            Description = description,
        };

        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await createTransportationCommandHandler.Handle(command, new System.Threading.CancellationToken());
        });
    }

    [Fact]
    public async Task Handle_TransportationIsValid_AddTransportationIntoCollection()
    {
        var context = DataSourceHelper.GetSetupInMemoryDbContext();

        var createTransportationCommandHandler = new CreateTransportationCommandHandler(context);

        var command = new CreateTransportationCommand
        {
            Code = "A100",
            Description = "A100 - Limassol",
        };

        await createTransportationCommandHandler.Handle(command, new System.Threading.CancellationToken());

        Assert.True(context.Transportations.Any());
    }
}

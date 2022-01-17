namespace Application.Common.Mappings;

public class TransportationProfile : Profile
{
    public TransportationProfile()
    {
        CreateMap<Domain.Entities.Transportation, TransportationDto>().ReverseMap();
    }
}

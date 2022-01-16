using Domain.Entities;

namespace Application.Common.Mappings;

public class TransportationLocationProfile : Profile
{
    public TransportationLocationProfile()
    {
        CreateMap<TransportationLocation, TransportationLocationDto>()
            .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.Latitude))
            .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.Longitude))
            .ForMember(d => d.Timestamp, opt => opt.MapFrom(s => s.Timestamp))
            .ForMember(d => d.TransportationId, opt => opt.MapFrom(s => s.TransportationId));
    }
}

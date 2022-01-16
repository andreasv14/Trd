using Application.Common.Mappings;
using AutoMapper;

namespace Application.UnitTests.Helpers;

public class AutoMapperHelper
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransportationLocationProfile>();
                cfg.AddProfile<TransportationProfile>();
            });

        return config.CreateMapper();
    }
}

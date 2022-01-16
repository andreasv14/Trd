using Refit;
using System.Threading.Tasks;
using Transportation.Dtos;

namespace Trd.Mobile.Services
{
    public interface IRouteDataService
    {
        [Get("/routes/Trd-route")]
        Task<TransportationRouteDto> GetTrdRoute(int TrdId);
    }
}

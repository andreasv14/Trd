using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trd.Mobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Trd.Mobile
{
    public partial class MainPage : ContentPage
    {
        private CancellationTokenSource _cancellationTokenSource;

        public MainPage()
        {
            InitializeComponent();

            GetCurrentLocation();

            GetTrdRouteAsync();
        }

        private async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                
                _cancellationTokenSource = new CancellationTokenSource();
                
                var location = await Geolocation.GetLocationAsync(request, _cancellationTokenSource.Token);
                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(100)));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private async Task GetTrdRouteAsync()
        {
            try
            {
                var routeDataService = RestService.For<IRouteDataService>("http://10.0.2.2:5001");

                var route = await routeDataService.GetTrdRoute(1);
                foreach (var busStop in route.PinPointLocations)
                {
                    map.Pins.Add(new Pin() { Position = new Position(busStop.Latitude, busStop.Longitude) });
                }
            }
            catch (Exception e)
            {

                throw;
            }
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.Services
{
    public class LocationService : ILocationService
    {
        private Location _lastLocation;

        /// <summary>
        /// Gets the current location async, either from cached or current
        /// </summary>
        /// <param name="getCurrent">Set to true to force retrieving the current location</param>
        /// <returns>The current location</returns>
        public async Task<Location> GetLocationAsync(bool getCurrent = false)
        {
            if (!getCurrent)
            {
                // If a valid recent location is available, return it
                if (ValidateLocation(_lastLocation)) return _lastLocation;

                // If a cached location is available on the device
                // Check whether is valid and return it
                _lastLocation = await GetCachedLocationAsync();
                if (ValidateLocation(_lastLocation)) return _lastLocation;
            }

            // If cached locations are not valid, or if the current one is required
            // Use the geolocation service to retrieve it
            _lastLocation = await GetCurrentLocationAsync();
            if (ValidateLocation(_lastLocation)) return _lastLocation;

            return null;
        }
        
        private async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                return await Geolocation.Default.GetLocationAsync(request);
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }

            return null;
        }
        private async Task<Location> GetCachedLocationAsync()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (ValidateLocation(location)) return location;
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }

            return null;
        }
        private bool ValidateLocation(Location location)
        {
            // Location is not null
            if (location == null) return false;

            // Location is not from mocking provider
            if (location.IsFromMockProvider) return false;

            // Location is accurate enough
            if (location.Accuracy > 500) return false;

            // Location was recently updated
            TimeSpan elapsed = DateTimeOffset.UtcNow - location.Timestamp;
            if (elapsed > TimeSpan.FromMinutes(10)) return false;

            return true;
        }
        private void HandleExceptions(Exception ex)
        {
            switch (ex)
            {
                case FeatureNotSupportedException fnsEx:
                    // Handle not supported on device exception
                    break;

                case FeatureNotEnabledException fnsEx:
                    // Handle not enabled on device exception
                    break;

                case PermissionException fnsEx:
                    // Handle permission exception
                    break;

                default:
                    // Handle generic exception
                    break;
            }
        }
    }
}

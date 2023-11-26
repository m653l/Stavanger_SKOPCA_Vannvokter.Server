using Application.Common.Exceptions;
using Application.Dtos;
using Application.Producers.Dtos;
using Application.Services.Interfaces;
using Newtonsoft.Json;

namespace Application.Services
{
    public class GeolocationService : IGeolocationService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<CoordinatesDto> GetCoordinate(PlaceDto place)
        {
            if (place is not null)
            {
                return new CoordinatesDto(
                    double.Parse(place.lat),
                    double.Parse(place.lon)
                );
            }

            throw new Exception();
        }

        public async Task<PlaceDto[]> GetPlaces(AddressDto address)
        {
            string key = "pk.9549554b13be9182694a0bd3f28ae71b";
            string url = "https://us1.locationiq.com/v1/search";

            var urlParams = new Dictionary<string, string>
            {
                { "key", key },
                { "q", address.GetAddressInOneString() },
                { "format", "json" }
            };

            string queryString = string.Join("&", urlParams.Select(p => $"{p.Key}={p.Value}"));

            string requestUrl = $"{url}?{queryString}";

            var response = await _httpClient.GetStringAsync(requestUrl);

            PlaceDto[]? places = JsonConvert.DeserializeObject<PlaceDto[]>(response);

            if (places is null)
                throw new NotFoundException(typeof(PlaceDto[]), address);

            return places;
        }
    }
}

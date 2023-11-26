using Application.Dtos;
using Application.Producers.Dtos;

namespace Application.Services.Interfaces
{
    public interface IGeolocationService
    {
        Task<PlaceDto[]> GetPlaces(AddressDto address);
        Task<CoordinatesDto> GetCoordinate(PlaceDto place);
    }
}

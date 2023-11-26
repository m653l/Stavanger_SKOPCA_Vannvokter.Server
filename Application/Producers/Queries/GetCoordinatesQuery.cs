using Application.Dtos;
using Application.Producers.Dtos;
using Application.Services.Interfaces;
using MediatR;

namespace Application.Producers.Queries
{
    public record GetCoordinatesQuery(AddressDto Address) : IRequest<CoordinatesDto>
    { }

    public class GetCoordinatesCommandHandler : IRequestHandler<GetCoordinatesQuery, CoordinatesDto>
    {
        private readonly IGeolocationService _geolocationService;

        public GetCoordinatesCommandHandler(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        public async Task<CoordinatesDto> Handle(GetCoordinatesQuery request, CancellationToken cancellationToken)
        {
            PlaceDto[] places = await _geolocationService.GetPlaces(request.Address);

            return await _geolocationService.GetCoordinate(places[0]);
        }
    }
}

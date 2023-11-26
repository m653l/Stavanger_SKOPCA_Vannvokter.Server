using Application.Dtos;
using Application.Producers.Dtos;
using Application.Services.Interfaces;
using MediatR;

namespace Application.Producers.Queries
{
    public record GetPlacesQuery(AddressDto Address) : IRequest<PlaceDto[]>
    { }

    public class GetPlacesCommandHandler : IRequestHandler<GetPlacesQuery, PlaceDto[]>
    {
        private readonly IGeolocationService _geolocationService;

        public GetPlacesCommandHandler(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        public async Task<PlaceDto[]> Handle(GetPlacesQuery request, CancellationToken cancellationToken)
        {
            return await _geolocationService.GetPlaces(request.Address);
        }
    }
}

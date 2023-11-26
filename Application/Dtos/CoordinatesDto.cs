namespace Application.Dtos
{
    public class CoordinatesDto
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public CoordinatesDto(double lat, double lon)
        {
            latitude = lat;
            longitude = lon;
        }
    }
}

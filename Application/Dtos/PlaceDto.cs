namespace Application.Dtos
{
    public class PlaceDto
    {
        public string place_id { get; set; } = string.Empty;
        public string licence { get; set; } = string.Empty;
        public string osm_type { get; set; } = string.Empty;
        public string osm_id { get; set; } = string.Empty;
        public string[] boundingbox { get; set; }
        public string lat { get; set; } = string.Empty;
        public string lon { get; set; } = string.Empty;
        public string display_name { get; set; } = string.Empty;
        public string @class { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public double importance { get; set; }
        public string? icon { get; set; }
    }
}

using Newtonsoft.Json;

namespace weather_app
{
    public partial class ResponseModel
    {
        [JsonProperty("request")]
        public Request Request { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("current")]
        public Current Current { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("lon")]
        public string Longitude { get; set; }
        [JsonProperty("timezone_id")]
        public string TimezoneId { get; set; }
        [JsonProperty("localtime")]
        public string LocalTime { get; set; }
        [JsonProperty("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }
        [JsonProperty("utc_offset")]
        public string UtcOffset { get; set; }
    }

    public partial class Current
    {
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }
        [JsonProperty("temperature")]
        public int Temperature { get; set; }
        [JsonProperty("weather_code")]
        public int WeatherCode { get; set; }
        [JsonProperty("weather_icons")]
        public string[] WeatherIcons { get; set; }
        [JsonProperty("weather_descriptions")]
        public string[] WeatherDescriptions { get; set; }
        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("precip")]
        public double Precip { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("cloudcover")]
        public int CloudCover { get; set; }
        [JsonProperty("feelslike")]
        public int FeelsLike { get; set; }
        [JsonProperty("uv_index")]
        public int UVIndex { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
    }
}
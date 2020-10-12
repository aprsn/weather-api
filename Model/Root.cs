namespace WeatherAPI.Model
{
    public class Root
    {
        public Request request { get; set; } 
        public Location location { get; set; } 
        public Current current { get; set; } 
    }
}
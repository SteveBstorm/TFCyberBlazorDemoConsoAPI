namespace BlazorDemoConsoAPI.Models
{
    public class PokedexModel
    {
        public  int  Count { get; set; }
        public string? Previous { get; set; }
        public string? Next { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
        public  string Url { get; set; }
    }
}

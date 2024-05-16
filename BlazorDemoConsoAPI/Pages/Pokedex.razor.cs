using BlazorDemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDemoConsoAPI.Pages
{
    public partial class Pokedex
    {
        //string url = "https://pokeapi.co/api/v2/pokemon";
        string url2 = Config.url;

        public PokedexModel Poketruc { get; set; }
        public List<Result> Results { get; set; }

        [Inject]
        public HttpClient _client { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            Poketruc = new PokedexModel();
            Results = new List<Result>();
            await GetPokemon("https://pokeapi.co/api/v2/pokemon");
        }

        public async Task GetPokemon(string url)
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri(url);
            try
            {
                Poketruc = await _client.GetFromJsonAsync<PokedexModel>("");
                Results.AddRange(Poketruc.Results);
                StateHasChanged();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (string.IsNullOrEmpty(Poketruc.Next)) return;
            await GetPokemon(Poketruc.Next);
        }
    }
}

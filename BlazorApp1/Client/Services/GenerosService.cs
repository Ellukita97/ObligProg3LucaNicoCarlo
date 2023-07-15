using BlazorApp1.Shared;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class GenerosService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient? _httpClient;

        public List<Genero> ListaGeneros = new List<Genero>();

        public GenerosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetListaGeneros()
        {
            _httpClient = _httpClientFactory.CreateClient();
            ListaGeneros = await _httpClient.GetFromJsonAsync<List<Genero>>("https://localhost:7200/api/peliculas/generos");
           
        }
    }
}

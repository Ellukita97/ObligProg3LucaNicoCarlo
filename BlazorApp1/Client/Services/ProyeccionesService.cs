using BlazorApp1.Shared;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class ProyeccionesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient? _httpClient;

        //Esta lista solo tiene las proyecciones de la pelicula actualmente seleccionada
        public List<Proyeccion> ListaProyecciones = new List<Proyeccion>();


        public ProyeccionesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       

        public async Task GetListaProyeccion(int idPelicula)
        {
            ListaProyecciones.Clear();
            _httpClient = _httpClientFactory.CreateClient();
            ListaProyecciones = await _httpClient.GetFromJsonAsync<List<Proyeccion>>($"https://localhost:7200/api/Proyecciones/{idPelicula}");
        }
    }
}

using BlazorApp1.Shared;
using System.Net.Http.Json;


namespace BlazorApp1.Client.Services
{
    public class PeliculasService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient? _httpClient;

        public List<Pelicula> ListaPeliculas = new List<Pelicula>();

        public Pelicula PeliculaSeleccionada = new Pelicula();

        public event Action DataChanged;

        public PeliculasService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task GetListaPeliculas()
        {
            _httpClient = _httpClientFactory.CreateClient();
            ListaPeliculas = await _httpClient.GetFromJsonAsync<List<Pelicula>>("https://localhost:7200/api/peliculas");
            DataChanged?.Invoke();
        }

        public void SeleccionarPelicula(int id)
        {
            foreach(Pelicula unapel in ListaPeliculas)
            {
                if (unapel.IdPelicula == id)
                {
                    PeliculaSeleccionada = unapel;
                }
            }
        }
        public async Task GetPeliculaPorNombre(string nombre)
        {
            ListaPeliculas = await _httpClient.GetFromJsonAsync<List<Pelicula>>($"https://localhost:7200/api/peliculas/{nombre}");
            DataChanged?.Invoke();
        }
       
    }
}

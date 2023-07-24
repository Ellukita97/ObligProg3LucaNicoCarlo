using BlazorApp1.Shared;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class PeliculasService
    {
        //Sirve para hacer un cliente http para hacer peticion http
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient? _httpClient;

        public List<Pelicula> ListaPeliculas = new List<Pelicula>();

        public Pelicula PeliculaSeleccionada = new Pelicula();

        public List<Genero> ListaGenerosDePelSeleccionada = new();

        //Para actulizar cualquier pagina blazor cuando los datos cambien
        public event Action DataChanged;

        public PeliculasService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task GetListaPeliculas()
        {
            try
            {
                //se crea el cliente
                _httpClient = _httpClientFactory.CreateClient();

                List<Pelicula> Lista = await _httpClient.GetFromJsonAsync<List<Pelicula>>("https://localhost:7200/api/peliculas");
                if (Lista != null && Lista.Count > 0)
                {
                    ListaPeliculas = Lista;
                }
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {

            }

        }

        public void SeleccionarPelicula(int id)
        {
            foreach (Pelicula unapel in ListaPeliculas)
            {
                if (unapel.IdPelicula == id)
                {
                    PeliculaSeleccionada = unapel;
                }
            }
        }
        public async Task GetPeliculaPorNombre(string nombre)
        {
            try
            {
                _httpClient = _httpClientFactory.CreateClient();
                ListaPeliculas = await _httpClient.GetFromJsonAsync<List<Pelicula>>($"https://localhost:7200/api/peliculas/{nombre}");
                //Ejecuta los metodos de DataChanged(Patron observer)
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<HttpResponseMessage> PostPelicula(Pelicula pelicula)
        {
            try
            {
                _httpClient = _httpClientFactory.CreateClient();
                var res = await _httpClient.PostAsJsonAsync("https://localhost:7200/api/peliculas/Post", pelicula);
                DataChanged?.Invoke();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task GetGenerosDePelicula(int idPelicula)
        {
            try
            {
                ListaGenerosDePelSeleccionada.Clear();
                _httpClient = _httpClientFactory.CreateClient();
                ListaGenerosDePelSeleccionada = await _httpClient.GetFromJsonAsync<List<Genero>>($"https://localhost:7200/api/peliculas/generosPelicula/{idPelicula}");
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task GetPeliculasPorGenero(string nombreGenero)
        {
            try
            {
                _httpClient = _httpClientFactory.CreateClient();
                var List = await _httpClient.GetFromJsonAsync<List<Pelicula>>($"https://localhost:7200/api/peliculas/peliculaPorGenero/{nombreGenero}");
                if (List != null && List.Count > 0)
                {
                    ListaPeliculas = List;
                }
                DataChanged?.Invoke();
            }
            catch (Exception ex)
            {

            }



        }




    }

}

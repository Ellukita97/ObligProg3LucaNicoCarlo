using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private List<Pelicula> PeliculaList = new List<Pelicula>();

        private IDbContextFactory<DbContextBlazor> _ContextFactory;
        public PeliculasController(IDbContextFactory<DbContextBlazor> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas()
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                PeliculaList = context.Peliculas.ToList();
                if (PeliculaList.Count > 0)
                {
                    return Ok(PeliculaList);
                }
                return NotFound();
            }
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculasPorNombre(string nombre)
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                PeliculaList = context.Peliculas.FromSqlRaw($"Select * from Peliculas WHERE nombre like '%{nombre}%'").ToList();
                if (PeliculaList.Count > 0)
                {
                    return Ok(PeliculaList);
                }
                return NotFound();
            }
        }
        [HttpGet("byid/{id}")]
        public async Task<ActionResult<Pelicula>> GetPeliculasPorId(int id)
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                Pelicula unapel = await context.Peliculas.FindAsync(id);
                if (unapel != null)
                {
                    return Ok(unapel);
                }
                return NotFound();
            }
        }

        [HttpGet]
        [Route("generos")]
        public async Task<ActionResult<List<Genero>>> GetGeneros()
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                List<Genero> generos = context.Generos.ToList();
                if (generos.Count > 0)
                {
                    return Ok(generos);
                }
                return BadRequest();
            }
        }
        [Route("generosPelicula")]
        public async Task<ActionResult<List<Genero>>> GetGenerosPeliculas()
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                /*
                

                var peliculasG = context.GeneroPelicula.ToList();
                var generos = context.Generos.ToList();
                var pelicula = context.Peliculas.ToList();

                for (int i = 0; i < peliculasG.Count; i++)
                {
                    if () 
                    { 
                        
                    }
                }
                */
                string query = $"select GeneroPelicula.Id as Id, Peliculas.Nombre as NombrePelicula , Generos.Nombre from Peliculas inner join GeneroPelicula  on Peliculas.IdPelicula = GeneroPelicula.PeliculaId inner join Generos on Generos.IdGenero = GeneroPelicula.GeneroId";

                //FormattableString a = $@"{query}";

                var peliculasG = context.GeneroPelicula.FromSqlRaw(query).ToList();



                //if (peliculasG.Count > 0)

                return Ok(peliculasG);


            }
        }






    }
}

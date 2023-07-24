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

        //interfas que se llena con las propiedades y metodos de DbContextBlazor,
        //esta se crea para poder conectarse a la base de datos
        private IDbContextFactory<DbContextBlazor> _ContextFactory;
        public PeliculasController(IDbContextFactory<DbContextBlazor> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }


        //metodo que se ejecuta cuando se le llama a la api
        //Task == promesa?
        //ActionResult == http status code
        //List<Pelicula> lista de peliculas
        //el metodo devuelve una lista de Peliculas
        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas()
        {
            //crea el contexto y se guarda en la variable context
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
        [HttpGet]
        [Route("generosPelicula/{idPelicula}")]
        public async Task<ActionResult<List<Genero>>> GetGenerosPeliculas(int idPelicula)
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                List<Genero> ListaNombreGeneros = context.Generos.FromSqlRaw($"select g.* from Generos g inner join GeneroPelicula gp on gp.GeneroId=g.IdGenero inner join Peliculas p on p.IdPelicula=gp.PeliculaId where p.IdPelicula={idPelicula}").ToList();
                if (ListaNombreGeneros.Count > 0)
                {
                    return Ok(ListaNombreGeneros);
                }
                return BadRequest(ListaNombreGeneros);
            }
        }
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> PostPelicula(Pelicula PelAAgregar)
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                try
                {
                    context.Add(PelAAgregar);
                    await context.SaveChangesAsync();
                    return Ok(PelAAgregar);
                }
                catch (Exception ex)
                {
                    return BadRequest(PelAAgregar);
                }

            }
        }

        [HttpGet]
        [Route("peliculaPorGenero/{nombreGenero}")]
        public async Task<ActionResult<List<Genero>>> GetPeliculaPorGenero(string nombreGenero)
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                List<Pelicula> ListaPeliculas = context.Peliculas.FromSqlRaw($"select p.* from Peliculas p inner join GeneroPelicula gp on gp.PeliculaId=p.IdPelicula inner join Generos g on g.IdGenero=gp.GeneroId where g.Nombre='{nombreGenero}'").ToList();
                if (ListaPeliculas.Count > 0)
                {
                    return Ok(ListaPeliculas);
                }
                return BadRequest(ListaPeliculas);
            }
        }








    }
}

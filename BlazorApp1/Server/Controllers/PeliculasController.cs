using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Internal;
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
                return BadRequest();
            }
        }







    }
}

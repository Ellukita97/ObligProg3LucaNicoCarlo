using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/proyecciones")]
    public class ProyeccionController : ControllerBase
    {
        private List<Proyeccion> ProyeccionList = new List<Proyeccion>();

        private IDbContextFactory<DbContextBlazor> _ContextFactory;
        public ProyeccionController(IDbContextFactory<DbContextBlazor> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proyeccion>>> GetProyecciones()
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                ProyeccionList = context.Proyecciones.ToList();
                if (ProyeccionList.Count > 0)
                {
                    return Ok(ProyeccionList);
                }
                return BadRequest();
            }
        }

    }
}

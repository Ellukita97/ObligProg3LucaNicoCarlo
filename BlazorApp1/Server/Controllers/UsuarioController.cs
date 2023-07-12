using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private static List<Usuario> usuariosList = new List<Usuario>();

        private IDbContextFactory<DbContextBlazor> _ContextFactory;
        public UsuarioController(IDbContextFactory<DbContextBlazor> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            using (var context = _ContextFactory.CreateDbContext())
            {
                usuariosList = context.Usuarios.ToList();
                if (usuariosList.Count > 0)
                {
                    return Ok(usuariosList);
                }
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetSingleUser(int id)
        {
            using(var context= _ContextFactory.CreateDbContext())
            {
                Usuario user = context.Usuarios.FirstOrDefault(u=> u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
                
            }
        }
        [HttpPost]
        [Route("ingresar")]
        public async Task<ActionResult> PostUserToDB(Usuario user)
        {
            if (string.IsNullOrEmpty(user.Nombre))
            {
                return BadRequest("El usuario debe tener nombre y apellido");
            }
            else
            {
                try
                {
                    using (DbContextBlazor context = _ContextFactory.CreateDbContext())
                    {
                        context.Usuarios.Add(user);
                        await context.SaveChangesAsync();
                        return Ok(user);
                    }
                }
                catch (DbUpdateException ex)
                {
                    return BadRequest("Error al intentar ingresar usuario" + ex.Message);
                }
                
            }
        }
        
        


        

       
        

       

    }
}

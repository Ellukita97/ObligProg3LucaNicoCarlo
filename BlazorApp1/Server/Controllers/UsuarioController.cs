using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuariosList = new List<Usuario>();
        private IDbContextFactory<DbContextBlazor> _ContextFactory;

        public UsuarioController(IDbContextFactory<DbContextBlazor> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            using (var context = _ContextFactory.CreateDbContext())
            {
                usuariosList = context.Usuarios.Where(u => u.Email.Equals(login.Email) && u.Password.Equals(login.Password)).ToList();

                if (usuariosList.Count > 0)
                {
                    sesionDTO.Nombre = usuariosList[0].Nombre;
                    sesionDTO.Email = usuariosList[0].Email;
                    sesionDTO.Rol = usuariosList[0].Rol;

                    return StatusCode(StatusCodes.Status200OK, sesionDTO);
                }

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> postRegister(Usuario user)
        {
            if (string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("El usuario debe tener nombre , Email y contraseña");
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

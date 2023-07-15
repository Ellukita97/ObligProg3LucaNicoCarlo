using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    public class BoletoCompra
    {
        [Key]
        public int IdBoleto { get; set; }

        [ForeignKey(nameof(Proyeccion))]
        public int IdProyeccion { get; set; }
        public Proyeccion? Proyeccion { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey(nameof(Asiento))]
        public int IdAsiento { get; set; }
        public int Asiento { get; set; }
    }
}

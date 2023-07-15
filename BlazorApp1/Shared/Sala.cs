using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int CantTotalAsientos { get; set; }
    }
}

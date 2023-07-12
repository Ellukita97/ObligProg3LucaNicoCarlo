using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        [Required]
        public int CantTotalAsientos { get; set; }
    }
}

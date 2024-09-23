using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.DB.DATA.ENTITY
{
    public class Partido : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}")]
        public string Rival { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(10, ErrorMessage = "Maximo numero de caracteres {1}")]
        public string Resultado { get; set; }
    }
}

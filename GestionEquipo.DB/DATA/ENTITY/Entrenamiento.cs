using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.DB.DATA.ENTITY
{
    public class Entrenamiento : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(500, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }
    }
}

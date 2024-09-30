using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.Shared.DTO
{
    public class CrearJugadorDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres {1}")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Edad { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}")]
        public string Posicion { get; set; }
    }
}

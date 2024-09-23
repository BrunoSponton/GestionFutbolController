using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.DB.DATA.ENTITY
{
    [Index(nameof(JugadorID), nameof(EntrenamientoID), Name = "AsistEntrenamiento_UQ", IsUnique = true)]
    public class AsistEntrenamiento : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Asistio { get; set; }

        //RELACIONES--------------------------------------------
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int JugadorID { get; set; }
        public Jugador Jugador { get; set; } 

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int EntrenamientoID { get; set; }
        public Entrenamiento Entrenamiento { get; set; } 
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.DB.DATA.ENTITY
{
    [Index(nameof(JugadorID), nameof(PartidoID), Name = "EstPartido_UQ", IsUnique = true)]
    public class EstPartido : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Goles { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Asistencias { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int MinutosJugados { get; set; }

        //RELACIONES------------------------------------------------------
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int JugadorID { get; set; }
        public Jugador Jugador { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int PartidoID { get; set; }
        public Partido Partido { get; set; }
    }
}

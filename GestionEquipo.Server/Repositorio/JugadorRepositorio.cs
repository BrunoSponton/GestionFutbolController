using GestionEquipo.DB.DATA;
using GestionEquipo.DB.DATA.ENTITY;

namespace GestionEquipo.Server.Repositorio
{
    public class JugadorRepositorio : Repositorio<Jugador>, IJugadorRepositorio
    {
        public JugadorRepositorio (Context context): base(context)
        { 

        }
    }
}

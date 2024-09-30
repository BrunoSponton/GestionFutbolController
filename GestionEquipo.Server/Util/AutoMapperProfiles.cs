using AutoMapper;
using GestionEquipo.DB.DATA.ENTITY;
using GestionEquipo.Shared.DTO;
using System.Runtime.InteropServices;

namespace GestionEquipo.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearJugadorDTO, Jugador>();
        }
        
    }
}

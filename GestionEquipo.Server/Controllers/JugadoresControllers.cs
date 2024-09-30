using AutoMapper;
using GestionEquipo.DB.DATA;
using GestionEquipo.DB.DATA.ENTITY;
using GestionEquipo.Server.Repositorio;
using GestionEquipo.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEquipo.Server.Controllers
{
    [ApiController]
    [Route("api/Jugadores")]
    public class JugadoresControllers : ControllerBase
    {

        private readonly IJugadorRepositorio repositorio;
        private readonly IMapper mapper;
        private readonly Context context;

        public JugadoresControllers(IJugadorRepositorio repositorio, IMapper mapper, Context context)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet]    //api/Jugadores
        public async Task<ActionResult<List<Jugador>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{ID:int}")] //api/Jugadores/2
        public async Task<ActionResult<Jugador>>Get(int ID)
        {
            var jugador = await repositorio.SelectById(ID);

            if (jugador == null)
            {
                return NotFound($"El jugador con el ID: {ID} no fue encontrado");
            }
            return jugador;
        }

        [HttpGet("Existe/{ID:int}")] //api/Jugadores/existe
        public async Task<ActionResult<bool>> Existe(int ID)
        {
            var existe = await repositorio.Existe(ID);
                return existe;
        }

        [HttpGet("{Nombre}")] //api/Jugadores/Nombre
        public async Task<ActionResult<Jugador>> GetbyCod(string Nombre)
        {
            var jugador = await context.Jugadores.FirstOrDefaultAsync(x => x.Nombre==Nombre);

            if (jugador == null)
            {
                return NotFound($"El nombre {Nombre} no fue encontrado");
            }
            return jugador;
        }


        [HttpPost]
        public async Task<ActionResult<int>>Post(Jugador entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DTO
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearJugadorDTO entidadDTO)
        {
            try
            {
                //Jugador entidad = new Jugador();
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Edad = entidadDTO.Edad;
                //entidad.Posicion = entidadDTO.Posicion;

                Jugador entidad = mapper.Map<Jugador>(entidadDTO);

               
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }

        [HttpPut("{ID:int}")]  //api/Jugadores/2
        public async Task<ActionResult> Put(int ID, [FromBody] Jugador entidad) 
        {
            if (ID != entidad.ID)
            { 
                return BadRequest("Datos Incorrectos");
            }
            var jugador = await repositorio.SelectById(ID);

            if (jugador == null)
            {
                return NotFound("No existe el jugador buscado");
            }
            jugador.ID = entidad.ID;
            jugador.Nombre = entidad.Nombre;
            jugador.Edad = entidad.Edad;
            jugador.Posicion = entidad.Posicion;

            try
            {
                await repositorio.Update(ID,jugador);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{ID:int}")] //api/Jugadores/2
        public async Task<ActionResult> Delete(int ID)
        {
            var existe = await repositorio.Existe(ID);
            if (!existe)
            {
                return NotFound($"El Jugador {ID} no existe");
            }
           
           if( await repositorio.Delete(ID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

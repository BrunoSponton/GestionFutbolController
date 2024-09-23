using GestionEquipo.DB.DATA;
using GestionEquipo.DB.DATA.ENTITY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEquipo.Server.Controllers
{
    [ApiController]
    [Route("api/Jugadores")]
    public class JugadoresControllers : ControllerBase
    {
        private readonly Context context;
        public JugadoresControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]    //api/Jugadores
        public async Task<ActionResult<List<Jugador>>> Get()
        {
            return await context.Jugadores.ToListAsync();
        }

        [HttpGet("{ID:int}")] //api/Jugadores/2
        public async Task<ActionResult<Jugador>>Get(int ID)
        {
            var jugador = await context.Jugadores.FirstOrDefaultAsync(x => x.ID == ID);

            if (jugador == null)
            {
                return NotFound($"El jugador con el ID: {ID} no fue encontrado");
            }
            return jugador;
        }

        [HttpGet("Existe/{ID:int}")] //api/Jugadores/existe
        public async Task<ActionResult<bool>> Existe(int ID)
        {
            var existe = await context.Jugadores.AnyAsync(x => x.ID == ID);
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

        [HttpGet("Filtrar")] //metodo para filtrar jugadores por edad o posicion
        public async Task<ActionResult<List<Jugador>>> Filtrar(int? edad, string posicion)
        {
            var query = context.Jugadores.AsQueryable();
            if (edad.HasValue)
            {
                query = query.Where(x => x.Edad == edad);
            }
            if (!string.IsNullOrEmpty(posicion))
            {
                query = query.Where(x => x.Posicion.Contains(posicion));
            }
            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>>Post(Jugador entidad)
        {
            try
            {
                context.Jugadores.Add(entidad);
                await context.SaveChangesAsync();
                //para devolver el id del jugador recien agregado:
                return entidad.ID;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{ID:int}")]
        public async Task<ActionResult> Put(int ID, [FromBody] Jugador entidad) 
        {
            if (ID != entidad.ID)
            { 
                return BadRequest("Datos Incorrectos");
            }
            var jugador = await context.Jugadores
                .Where(e => e.ID == ID).FirstOrDefaultAsync();

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
                context.Jugadores.Update(jugador);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{ID:int}")]
        public async Task<ActionResult> Delete(int ID)
        {
            var existe = await context.Jugadores.AnyAsync(x=> x.ID == ID);
            if (!existe)
            {
                return NotFound($"El Jugador {ID} no existe");
            }
            Jugador EntidadABorrar = new Jugador();
            EntidadABorrar.ID = ID;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

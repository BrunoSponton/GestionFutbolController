using AutoMapper;
using GestionEquipo.DB.DATA;
using GestionEquipo.DB.DATA.ENTITY;
using GestionEquipo.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEquipo.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {

        private readonly Context context;

        public async Task<bool> Existe(int ID)
        {
            var existe = await context.Set<E>().AnyAsync(x => x.ID == ID);
            return existe;
        }

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<E> SelectById(int ID)
        {
            E? jugador = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == ID);

            return jugador;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        [HttpPost]
        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.ID;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public async Task<bool> Update(int ID, E entidad)
        {
            if (ID != entidad.ID)
            {
                return false;
            }
            var jugador = await SelectById(ID);


            if (jugador == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int ID)
        {
            var jugador = await SelectById(ID);


            if (jugador == null)
            {
                return false;
            }

            context.Set<E>().Remove(jugador);
            await context.SaveChangesAsync();
            return true;
        }

    }
}

 using GestionEquipo.DB.DATA;

namespace GestionEquipo.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Delete(int ID);
        Task<bool> Existe(int ID);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E> SelectById(int ID);
        Task<bool> Update(int ID, E entidad);
    }
}
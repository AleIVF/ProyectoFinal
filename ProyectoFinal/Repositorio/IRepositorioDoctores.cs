using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio
{
    public interface IRepositorioDoctores
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor?> Get(int id);
        Task<Doctor> Add(Doctor doctor);
        Task Update(int id, Doctor doctor);
        Task Delete(int id);
    }
}

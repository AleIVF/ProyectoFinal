using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio
{
    public interface IRepositorioPacientes
    {
        Task<List<Paciente>> GetAll();
        Task<Paciente?> Get(int id);
        Task<Paciente> Add(Paciente paciente);
        Task Update(int id, Paciente paciente);
        Task Delete(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio
{
    public class RepositorioPacientes: IRepositorioPacientes
    {
        private readonly AgendaDBContext _context;

        public RepositorioPacientes(AgendaDBContext context)
        {
            _context = context;
        }

        public async Task<Paciente> Add(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Paciente?> Get(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }
        public async Task<List<Paciente>> GetAll()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task Update(int id, Paciente paciente)
        {
            var pacienteactual = await _context.Pacientes.FindAsync(id);
            if (pacienteactual != null)
            {
                pacienteactual.Nombre = paciente.Nombre;
                pacienteactual.Telefono = paciente.Telefono;
                pacienteactual.Genero = paciente.Genero;
                await _context.SaveChangesAsync();
            }

        }
    }
}

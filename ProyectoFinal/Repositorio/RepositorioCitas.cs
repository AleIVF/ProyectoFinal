using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio
{
    public class RepositorioCitas : IRepositorioCitas
    {
        private readonly AgendaDBContext _context;

        public RepositorioCitas(AgendaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetAll()
        {
            return await _context.Set<Cita>().Include(c => c.Doctor).Include(c => c.Paciente).ToListAsync();
        }

        public async Task<Cita?> Get(int id)
        {
            return await _context.Set<Cita>().Include(c => c.Doctor).Include(c => c.Paciente).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cita> Add(Cita cita)
        {
            _context.Set<Cita>().Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task Update(int id, Cita cita)
        {
            var existingCita = await Get(id);
            if (existingCita != null)
            {
                existingCita.Fecha = cita.Fecha;
                existingCita.Motivo = cita.Motivo;
                existingCita.ResumenDiagnostico = cita.ResumenDiagnostico;
                existingCita.PacienteId = cita.PacienteId;
                existingCita.DoctorId = cita.DoctorId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var cita = await Get(id);
            if (cita != null)
            {
                _context.Set<Cita>().Remove(cita);
                await _context.SaveChangesAsync();
            }
        }
    }
}

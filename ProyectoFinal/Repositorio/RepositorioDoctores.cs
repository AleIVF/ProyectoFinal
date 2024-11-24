using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio
{
    public class RepositorioDoctores : IRepositorioDoctores
    {
        private readonly AgendaDBContext _context;

        public RepositorioDoctores(AgendaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctores.ToListAsync();
        }

        public async Task<Doctor?> Get(int id)
        {
            return await _context.Doctores.FindAsync(id);
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            await _context.Doctores.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task Update(int id, Doctor doctor)
        {
            var existingDoctor = await _context.Doctores.FindAsync(id);
            if (existingDoctor != null)
            {
                existingDoctor.Nombre = doctor.Nombre;
                existingDoctor.Especialidad = doctor.Especialidad;
                existingDoctor.Horario = doctor.Horario;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var doctor = await _context.Doctores.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctores.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
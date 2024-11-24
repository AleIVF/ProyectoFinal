using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProyectoFinal.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud máxima es 200 caracteres")]
        public string? Motivo { get; set; }

        [Required(ErrorMessage = "El resumen del diagnóstico es obligatorio")]
        public string? ResumenDiagnostico { get; set; }

        // Relación con Paciente
        [Required]
        public int PacienteId { get; set; }
        public virtual Paciente? Paciente { get; set; }

        // Relación con Doctor
        [Required]
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}

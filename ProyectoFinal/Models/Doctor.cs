using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud máxima es 100 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        public string? Especialidad { get; set; }

        [Required(ErrorMessage = "El horario de atención es obligatorio")]
        public string? Horario { get; set; }

        // Relación uno a muchos con Citas
        public virtual ICollection<Cita>? Citas { get; set; }
    }
}

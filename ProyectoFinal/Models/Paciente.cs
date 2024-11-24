using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud máxima es 100 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La longitud máxima es 10 caracteres")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string? Genero { get; set; }

        // Relación uno a muchos con Citas
        public virtual ICollection<Cita>? Citas { get; set; }
    }
}

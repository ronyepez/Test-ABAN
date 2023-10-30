using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ABAN.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [MaxLength (255, ErrorMessage = "El Nombre no puede tener más de 255 caracteres.")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        [MaxLength(255, ErrorMessage = "El Apellido no puede tener más de 255 caracteres.")]
        public string Apellidos { get; set; } = null!;

        [Column(TypeName ="Date")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        [MaxLength(11, ErrorMessage = "El CUIT no puede tener más de 11 caracteres.")]
        public string CUIT { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Dirección de correo electrónico no válida.")]
        public string Email { get; set; } = null!;

        [MaxLength(10, ErrorMessage = "El Número de Celular no puede tener más de 10 caracteres.")]
        public int Celular { get; set; }

        public bool DeletedAt { get; set; }


        public Direccion Direccion { get; set; } = null!;
    }
}

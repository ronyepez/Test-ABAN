using System.ComponentModel.DataAnnotations;

namespace API_ABAN.Models.Dtos
{
    public class ClienteUpdateDTO
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        public string CUIT { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Dirección de correo electrónico no válida.")]
        public string Email { get; set; } = null!;

        public int Celular { get; set; }


        public DireccionUpdateDTO Direccion { get; set; } = null!;
    }
}

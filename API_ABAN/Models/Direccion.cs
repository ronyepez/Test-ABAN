using System.ComponentModel.DataAnnotations;

namespace API_ABAN.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionId { get; set; }

        public string Calle { get; set; } = null!;

        public int Numero { get; set; }

        [MaxLength(50, ErrorMessage = "La Ciudad no puede tener más de 50 caracteres.")] 
        public string Ciudad { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "La Provincia no puede tener más de 50 caracteres.")] 
        public string Provincia { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El País no puede tener más de 50 caracteres.")] 
        public string Pais { get; set; } = null!;

        public bool DeletedAt { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}

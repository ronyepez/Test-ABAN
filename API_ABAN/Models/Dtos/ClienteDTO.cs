namespace API_ABAN.Models.Dtos
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string CUIT { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Celular { get; set; }

        public DireccionDTO Direccion { get; set; } = null!;
    }
}

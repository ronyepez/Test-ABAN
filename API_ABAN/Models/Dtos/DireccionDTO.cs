﻿namespace API_ABAN.Models.Dtos
{
    public class DireccionDTO
    {
        public int DireccionID { get; set; }

        public string Calle { get; set; } = null!;

        public int Numero { get; set; }

        public string Ciudad { get; set; } = null!;

        public string Provincia { get; set; } = null!;

        public string Pais { get; set; } = null!;

    }
}

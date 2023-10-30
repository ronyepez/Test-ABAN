using API_ABAN.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ABAN.Entidades.Seeding
{
    public static class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var pedro = new Cliente { ClienteId = 1, Nombres = "Pedro", Apellidos = "Pérez", FechaNacimiento = new DateTime(2000, 10, 23), CUIT = "252032546", Email = "pperez@gmail.com", Celular = 1125631478, DeletedAt = false };
            var maria = new Cliente { ClienteId = 2, Nombres = "María", Apellidos = "Santana", FechaNacimiento = new DateTime(1995, 02, 19), CUIT = "202054564", Email = "msantana@gmail.com", Celular = 1165231590, DeletedAt = false };
            var carmen = new Cliente { ClienteId = 3,  Nombres = "Carmen", Apellidos = "Contreras", FechaNacimiento = new DateTime(1999, 12, 19), CUIT = "252005569", Email = "ccontreras@gmail.com", Celular = 1161971590, DeletedAt = false };

            modelBuilder.Entity<Cliente>().HasData(pedro, maria, carmen);

            var Calle01 = new Direccion { DireccionId = 1, Calle = "Calle 2", Numero = 123, Ciudad = "Ciudad B", Provincia = "Provincia A", Pais = "Argentina", DeletedAt = false, ClienteId = 1 };
            var Calle02 = new Direccion { DireccionId = 2, Calle = "Calle 3", Numero = 321, Ciudad = "Ciudad A", Provincia = "Provincia B", Pais = "Argentina", DeletedAt = false, ClienteId = 3 };
            var Calle03 = new Direccion { DireccionId = 3, Calle = "Calle 1", Numero = 456, Ciudad = "Ciudad C", Provincia = "Provincia C", Pais = "Argentina", DeletedAt = false, ClienteId = 2 };

            modelBuilder.Entity<Direccion>().HasData(Calle01, Calle02, Calle03);

        }
    }
}
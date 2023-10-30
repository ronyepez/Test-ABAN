using API_ABAN.Data;
using API_ABAN.Models;
using API_ABAN.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace API_ABAN.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicatioDbContext _context;

        public ClienteRepository(ApplicatioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<IEnumerable<Cliente>> FilterClientesByNameAsync(string name)
        {
            return await _context.Clientes
                .Include(c => c.Direccion)
                .Where(c => c.Nombres.Contains(name))
                .ToListAsync();
        }

        public async Task<int> CreateClienteAsync(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.ClienteId;
        }

        public async Task UpdateClienteAsync(Cliente cliente, int id)
        {
            var clienteDB = await _context.Clientes
                .AsTracking()
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (clienteDB != null)
            {
                clienteDB.Nombres = cliente.Nombres;
                clienteDB.Apellidos = cliente.Apellidos;
                clienteDB.FechaNacimiento = cliente.FechaNacimiento;
                clienteDB.CUIT = cliente.CUIT;
                clienteDB.Email = cliente.Email;
                clienteDB.Celular = cliente.Celular;
                clienteDB.Direccion.Calle = cliente.Direccion.Calle;
                clienteDB.Direccion.Numero = cliente.Direccion.Numero;
                clienteDB.Direccion.Ciudad = cliente.Direccion.Ciudad;
                clienteDB.Direccion.Provincia = cliente.Direccion.Provincia;
                clienteDB.Direccion.Pais = cliente.Direccion.Pais;

                await _context.SaveChangesAsync();
            }
        }

        public async Task SoftDeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes
                .AsTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente != null)
            {
                cliente.DeletedAt = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RestoreClienteAsync(int id)
        {
            var cliente = await _context.Clientes
                .AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente != null)
            {
                cliente.DeletedAt = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}

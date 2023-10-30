using API_ABAN.Models;

namespace API_ABAN.Repositories.IRepositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<IEnumerable<Cliente>> FilterClientesByNameAsync(string name);
        Task<int> CreateClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente, int id);
        Task SoftDeleteClienteAsync(int id);
        Task RestoreClienteAsync(int id);
    }
}

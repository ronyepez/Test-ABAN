using API_ABAN.Models.Dtos;

namespace API_ABAN.Services.IServices
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<ClienteDTO> GetClienteByIdAsync(int id);
        Task<IEnumerable<ClienteDTO>> FilterClientesByNameAsync(string name);
        Task<int> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO);
        Task UpdateClienteAsync(ClienteUpdateDTO clienteUpdateDTO, int id);
        Task SoftDeleteClienteAsync(int id);
        Task RestoreClienteAsync(int id);
    }
}

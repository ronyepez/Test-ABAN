using API_ABAN.Models;
using API_ABAN.Models.Dtos;
using API_ABAN.Repositories.IRepositories;
using API_ABAN.Services.IServices;
using AutoMapper;

namespace API_ABAN.Services
{
    public class ClienteService: IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> FilterClientesByNameAsync(string name)
        {
            var clientes = await _clienteRepository.FilterClientesByNameAsync(name);
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<int> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            return await _clienteRepository.CreateClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(ClienteUpdateDTO clienteUpdateDTO, int id)
        {
            var cliente = _mapper.Map<Cliente>(clienteUpdateDTO);
            await _clienteRepository.UpdateClienteAsync(cliente, id);
        }

        public async Task SoftDeleteClienteAsync(int id)
        {
            await _clienteRepository.SoftDeleteClienteAsync(id);
        }

        public async Task RestoreClienteAsync(int id)
        {
            await _clienteRepository.RestoreClienteAsync(id);
        }
    }
}

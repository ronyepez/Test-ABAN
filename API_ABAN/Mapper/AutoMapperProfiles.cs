using API_ABAN.Models;
using API_ABAN.Models.Dtos;
using AutoMapper;

namespace API_ABAN.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Map Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();

            //Map Domicilio
            CreateMap<Direccion, DireccionDTO>().ReverseMap();
            CreateMap<Direccion, DireccionCreateDTO>().ReverseMap();
            CreateMap<Direccion, DireccionUpdateDTO>().ReverseMap();
        }
    }
}

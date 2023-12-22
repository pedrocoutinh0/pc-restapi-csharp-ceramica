using AutoMapper;
using CeramicaCSharp.Dto;
using CeramicaCSharp.Models;

namespace CeramicaCSharp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
        }    
    }
}

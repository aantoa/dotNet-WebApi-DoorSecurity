using AutoMapper;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;

namespace DoorsSecurity.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Door, DoorGetDto>();            
            CreateMap<Door, DoorWithCardsGetDto>();
            CreateMap<Card, CardGetDto>();
            CreateMap<Card, CardWithDoorsGetDto>();
        }
    }
}
using AutoMapper;
using ReviewApp.DTO;
using ReviewApp.Models;

namespace ReviewApp.Helper
{
    public class mappingProfiles :Profile
    {

        public mappingProfiles()
        {
            CreateMap<Character , CharacterDTO>();
        }
    }
}

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
            CreateMap<Category , CategoryDTO>();
            CreateMap<Country , CountryDTO>();
            CreateMap<Owner , OwnerDTO>();
            CreateMap<Reviews , ReviewsDTO>();
            CreateMap<Reviewers , ReviewersDTO>();
        }
    }
}

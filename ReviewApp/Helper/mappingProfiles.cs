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
            CreateMap<CharacterDTO , Character>();
            CreateMap<Category , CategoryDTO>();
            CreateMap<CategoryDTO , Category>();
            CreateMap<Country , CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<Owner , OwnerDTO>();
            CreateMap<OwnerDTO, Owner>();
            CreateMap<Reviews , ReviewsDTO>();
            CreateMap<ReviewsDTO, Reviews>();
            CreateMap<Reviewers , ReviewersDTO>();
            CreateMap<ReviewersDTO, Reviewers>();
        }
    }
}

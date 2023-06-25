using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface ICountryRespository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        bool CountryExists(int id);

        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromCountry(int countryId);


    }
}

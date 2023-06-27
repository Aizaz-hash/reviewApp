using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CountryRespository : ICountryRespository
    {
        private DataContext _context;
        public CountryRespository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.countries.Any(c => c.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);

            return save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.countries.Where(e => e.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.owners.Where(o=>o.Id == ownerId).Select(c=>c.country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.owners.Where(c => c.country.Id == countryId).ToList();

        }

        public bool save()
        {
            var save = _context.SaveChanges();

            return save > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);

            return save();
        }
    }
}

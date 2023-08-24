using UseCase1.Models;

namespace UseCase1.Services
{
    public interface IDataLoaderService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<Country>> GetCountriesByName(string name);
        Task<IEnumerable<Country>> GetCountriesByName(string name, string sortDirection);
        Task<IEnumerable<Country>> GetCountriesByPopulation(int millions);
    }
}

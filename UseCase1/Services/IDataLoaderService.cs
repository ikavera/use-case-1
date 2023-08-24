using UseCase1.Models;

namespace UseCase1.Services
{
    public interface IDataLoaderService
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}

using UseCase1.Models;

namespace UseCase1.Services
{
    public class OperationsService : IOperationsService
    {
        private const int MILLION = 1_000_000;
        private readonly IDataLoaderService _dataLoaderService;

        public OperationsService(IDataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService;
        }

        public async Task<IEnumerable<Country>> GetCountries(string? name, int? millions, string sortDirection, int? recordsPerPage, int? pageNumber)
        {
            var all = await _dataLoaderService.GetAllCountries();
            if (name is not null) all = FilterByName(all, name);
            if (millions is not null) all = FilterByPopulation(all, millions.Value);
            all = GetSorted(all, sortDirection);
            return GetPaginated(all, recordsPerPage, pageNumber);
        }

        public async Task<IEnumerable<Country>> GetAllCountriesPaged(int? recordsPerPage, int? pageNumber)
        {
            var all = await _dataLoaderService.GetAllCountries();
            return GetPaginated(all, recordsPerPage, pageNumber);
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            var all = await _dataLoaderService.GetAllCountries();
            return FilterByName(all, name);
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name, string sortDirection)
        {
            var countries = await GetCountriesByName(name);
            return GetSorted(countries, sortDirection);
        }

        public async Task<IEnumerable<Country>> GetCountriesByPopulation(int millions)
        {
            var all = await _dataLoaderService.GetAllCountries();
            return FilterByPopulation(all, millions);
        }

        #region Helpers
        private static IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int millions)
        {
            return countries.Where(x => x.Population <= millions * MILLION);
        }

        private static IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string name)
        {
            return countries.Where(x => !string.IsNullOrEmpty(x.Name.Common)
            && x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IEnumerable<Country> GetPaginated(IEnumerable<Country> countries, int? recordsPerPage, int? pageNumber)
        {
            recordsPerPage ??= countries.Count();
            pageNumber ??= 0;
            return countries.Skip(pageNumber.Value * recordsPerPage.Value).Take(recordsPerPage.Value);
        }

        private static IEnumerable<Country> GetSorted(IEnumerable<Country> countries, string sortDirection)
        {
            if (sortDirection.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
            {
                return countries.OrderBy(x => x.Name.Common);
            }
            return countries.OrderByDescending(x => x.Name.Common);
        }
        #endregion
    }
}

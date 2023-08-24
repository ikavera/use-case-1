using System.Diagnostics;
using UseCase1.Models;

namespace UseCase1.Services
{
    public class DataLoaderService : IDataLoaderService
    {
        private const string COUNTRIES_URL = "https://restcountries.com/v3.1/all";
        private const int MILLION = 1_000_000;
        private readonly IHttpClientFactory _httpClientFactory;

        public DataLoaderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await GetAll();
        }

        public async Task<IEnumerable<Country>> GetCountries(string? name, int? millions, string sortDirection, int? recordsPerPage, int? pageNumber)
        {
            var all = await GetAll();
            if (name is not null) all = FilterByName(all, name);
            if (millions is not null) all = FilterByPopulation(all, millions.Value);
            all = GetSorted(all, sortDirection);
            return GetPaginated(all, recordsPerPage, pageNumber);
        }

        public async Task<IEnumerable<Country>> GetAllCountriesPaged(int? recordsPerPage, int? pageNumber)
        {
            var all = await GetAll();
            return GetPaginated(all, recordsPerPage, pageNumber);
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            var all = await GetAll();
            return FilterByName(all, name);
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name, string sortDirection)
        {
            var countries = await GetCountriesByName(name);
            return GetSorted(countries, sortDirection);
        }

        public async Task<IEnumerable<Country>> GetCountriesByPopulation(int millions)
        {
            var all = await GetAll();
            return FilterByPopulation(all, millions);
        }

        #region Helpers
        private async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                using HttpClient httpClient = _httpClientFactory.CreateClient();
                var countries = await httpClient.GetFromJsonAsync<IEnumerable<Country>>(COUNTRIES_URL);
                return countries ?? new List<Country>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        private IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int millions)
        {
            return countries.Where(x => x.Population <= millions * MILLION);
        }

        private IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string name)
        {
            return countries.Where(x => !string.IsNullOrEmpty(x.Name.Common)
            && x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        private IEnumerable<Country> GetPaginated(IEnumerable<Country> countries, int? recordsPerPage, int? pageNumber)
        {
            recordsPerPage ??= countries.Count();
            pageNumber ??= 0;
            return countries.Skip(pageNumber.Value * recordsPerPage.Value).Take(recordsPerPage.Value);
        }

        private IEnumerable<Country> GetSorted(IEnumerable<Country> countries, string sortDirection)
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

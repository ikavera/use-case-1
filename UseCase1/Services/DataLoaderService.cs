using System.Diagnostics;
using UseCase1.Models;

namespace UseCase1.Services
{
    public class DataLoaderService : IDataLoaderService
    {
        private const string COUNTRIES_URL = "https://restcountries.com/v3.1/all";
        private readonly IHttpClientFactory _httpClientFactory;

        public DataLoaderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await GetAll();
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            var all = await GetAll();
            return all.Where(x => !string.IsNullOrEmpty(x.Name.Common) && x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        #region Helpers
        private async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                using HttpClient httpClient = _httpClientFactory.CreateClient();
                var countries = await httpClient.GetFromJsonAsync<IEnumerable<Country>>(COUNTRIES_URL);
                return countries;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        #endregion
    }
}

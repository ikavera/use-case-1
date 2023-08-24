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
    }
}

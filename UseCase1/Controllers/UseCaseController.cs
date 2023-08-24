using Microsoft.AspNetCore.Mvc;
using UseCase1.Services;

namespace UseCase1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UseCaseController : ControllerBase
    {
        private readonly IDataLoaderService _dataLoaderService;

        public UseCaseController(IDataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService;
        }

        [HttpGet]
        [ActionName("GetCountries")]
        public async Task<ActionResult> GetCountries(string? countryName = null, int? population = null, string? sortDirection = "asc", int? records = null, int? pageNumber = null)
        {
            if (countryName is not null)
            {
                if (sortDirection is not null)
                {
                    return Ok(await _dataLoaderService.GetCountriesByName(countryName, sortDirection));
                }

                return Ok(await _dataLoaderService.GetCountriesByName(countryName));
            }
            if (records is not null || pageNumber is not null)
            {
                return Ok(await _dataLoaderService.GetAllCountriesPaged(records, pageNumber));
            }
            if (population is not null)
            {
                return Ok(await _dataLoaderService.GetCountriesByPopulation(population.Value));
            }
            if (countryName is not null)
            {
                return Ok(await _dataLoaderService.GetCountriesByName(countryName));
            }

            return Ok(await _dataLoaderService.GetAllCountries());
        }
    }
}

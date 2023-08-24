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
            return Ok(await _dataLoaderService.GetCountries(countryName, population, sortDirection!, records, pageNumber));
        }
    }
}

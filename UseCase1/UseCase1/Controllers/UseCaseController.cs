using Microsoft.AspNetCore.Mvc;
using UseCase1.Services;

namespace UseCase1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UseCaseController : ControllerBase
    {
        private readonly IOperationsService _operationsService;

        public UseCaseController(IOperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        [HttpGet]
        [ActionName("GetCountries")]
        public async Task<ActionResult> GetCountries(string? countryName = null, int? population = null, string? sortDirection = "asc", int? records = null, int? pageNumber = null)
        {
            return Ok(await _operationsService.GetCountries(countryName, population, sortDirection!, records, pageNumber));
        }
    }
}

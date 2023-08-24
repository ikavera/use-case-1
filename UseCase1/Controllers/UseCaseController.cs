﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetCountries(string? countryName = null, int? a2 = null, string? a3 = null, string? a4 = null)
        {
            if (countryName == null)
            {
                return Ok(await _dataLoaderService.GetAllCountries());
            }
            return Ok(await _dataLoaderService.GetCountriesByName(countryName));
        }
    }
}

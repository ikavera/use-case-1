using NSubstitute;
using UseCase1.Models;
using UseCase1.Services;

namespace UseCase1.Tests
{
    public class DataLoaderService_Test
    {
        [Fact]
        public async Task GetAllCountries_EmptyList()
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(new List<Country>());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountriesByName("ir");
            Assert.Empty(countries);
        }

        [Theory]
        [MemberData(nameof(TestData.CountryExactNames), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.CountryPartialNames), MemberType = typeof(TestData))]
        public async Task GetCountriesByName_Passed(string countryNameToSearch, int expectedCount)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountriesByName(countryNameToSearch);
            Assert.Equal(expectedCount, countries.Count());
        }

        [Theory]
        [MemberData(nameof(TestData.CountryPartialNameSorting), MemberType = typeof(TestData))]
        public async Task GetCountriesByNameOrdered_Asc(string countryNameToSearch, string firstName, string lastName)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountriesByName(countryNameToSearch, "asc");
            Assert.Equal(firstName, countries.First().Name.Common);
            Assert.Equal(lastName, countries.Last().Name.Common);
        }

        [Theory]
        [MemberData(nameof(TestData.CountryPartialNameSorting), MemberType = typeof(TestData))]
        public async Task GetCountriesByNameOrdered_Desc(string countryNameToSearch, string firstName, string lastName)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountriesByName(countryNameToSearch, "desc");
            Assert.Equal(lastName, countries.First().Name.Common);
            Assert.Equal(firstName, countries.Last().Name.Common);
        }

        [Theory]
        [MemberData(nameof(TestData.CountryByPopulation), MemberType = typeof(TestData))]
        public async Task GetCountriesByPopulation(int populationMillions, int expectedCount)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountriesByPopulation(populationMillions);
            Assert.Equal(expectedCount, countries.Count());
        }

        [Theory]
        [MemberData(nameof(TestData.CountryForPagination), MemberType = typeof(TestData))]
        public async Task GetAllCountriesPaged(int? recordsPerPage, int? pageNumber, int expectedCount, string firstName, string lastName)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetAllCountriesPaged(recordsPerPage, pageNumber);
            Assert.Equal(expectedCount, countries.Count());
            Assert.Equal(firstName, countries.First().Name.Common);
            Assert.Equal(lastName, countries.Last().Name.Common);
        }

        [Theory]
        [MemberData(nameof(TestData.CountryForFullSearch), MemberType = typeof(TestData))]
        public async Task GetCountries(string? countryNameToSearch, int? millions, string sortDirection, int? recordsPerPage, int? pageNumber, int expectedCount, string firstName, string lastName)
        {
            var dataLoader = Substitute.For<IDataLoaderService>();
            dataLoader.GetAllCountries().Returns(GetTestCounties());
            var operationsService = new OperationsService(dataLoader);
            var countries = await operationsService.GetCountries(countryNameToSearch, millions, sortDirection, recordsPerPage, pageNumber);
            Assert.Equal(expectedCount, countries.Count());
            Assert.Equal(firstName, countries.First().Name.Common);
            Assert.Equal(lastName, countries.Last().Name.Common);
        }

        private IEnumerable<Country> GetTestCounties()
        {
            var list = new List<Country>
            {
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Ukraine"
                    },
                    Population = 44134693
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "British Virgin Islands"
                    },
                    Population = 30237
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Iran"
                    },
                    Population = 83992953
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Iraq"
                    },
                    Population = 40222503
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Ireland"
                    },
                    Population = 4994724
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Kiribati"
                    },
                    Population = 119446
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Pitcairn Islands"
                    },
                    Population = 56
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "United Arab Emirates"
                    },
                    Population = 9890400
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "United States Virgin Islands"
                    },
                    Population = 106290
                }
            };
            return list;
        }
    }
}
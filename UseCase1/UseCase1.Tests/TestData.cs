using System.Diagnostics.CodeAnalysis;

namespace UseCase1.Tests
{
    [ExcludeFromCodeCoverage]
    public class TestData
    {
        public static IEnumerable<object[]> CountryExactNames => new List<object[]>
        {
            new object[]{ "Ireland", 1 },
            new object[]{ "Ukraine", 1 },
            new object[]{ "dsfhshjdfsldhfhsdfhsf", 0 },
        };

        public static IEnumerable<object[]> CountryPartialNames => new List<object[]>
        {
            new object[]{ "ir", 8 },
            new object[]{ "dsfhshjdfsldhfhsdfhsf", 0 },
        };

        public static IEnumerable<object[]> CountryPartialNameSorting => new List<object[]>
        {
            new object[]{ "ir", "British Virgin Islands","United States Virgin Islands" },
        };

        public static IEnumerable<object[]> CountryByPopulation => new List<object[]>
        {
            new object[]{ 100, 9 },
            new object[]{ 1, 4 },
        };

        public static IEnumerable<object[]> CountryForPagination => new List<object[]>
        {
            new object[]{ null, null, 9, "Ukraine", "United States Virgin Islands" },
            new object[]{ 1, 4, 1, "Ireland", "Ireland" },
        };

        public static IEnumerable<object[]> CountryForFullSearch => new List<object[]>
        {
            new object[]{ null, null, "asc", null, null, 9, "British Virgin Islands", "United States Virgin Islands" },
            new object[]{ null, null, "desc", null, null, 9, "United States Virgin Islands", "British Virgin Islands" },
            new object[]{ "ir", null, "desc", null, null, 8, "United States Virgin Islands", "British Virgin Islands"  },
            new object[]{ "ir", 1, "desc", null, null, 4, "United States Virgin Islands", "British Virgin Islands"  },
            new object[]{ "ir", 1, "desc", 2, 1, 2, "Kiribati", "British Virgin Islands"  },
        };
    }
}

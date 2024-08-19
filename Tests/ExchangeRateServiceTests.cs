using BackendTaskPilot;
using Xunit;

namespace Tests
{
    public class ExchangeRateServiceTests
    {
        // SAR and KES currencies not returned
        [Theory]
        [MemberData(nameof(GetCurrencyTestData))]
        public void GetExchangeRates_Successful(List<string> currencies, string expectedResult)
        {
            var result = new ExchangeRateService().GetExchangeRates(currencies).Result;

            Assert.Equal(expectedResult, result?.FirstOrDefault()?.CurrencyCode);
        }

        public static IEnumerable<object[]> GetCurrencyTestData()
        {
            yield return new object[] { new List<string> { "USD" }, "USD" };
            yield return new object[] { new List<string> { "EUR" }, "EUR" };
            yield return new object[] { new List<string> { "JPY" }, "JPY" };
            yield return new object[] { new List<string> { "SAR" }, "SAR" };
            yield return new object[] { new List<string> { "KES" }, "KES" };
        }
    }
}

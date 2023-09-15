using IX.Library.Globalization;

namespace UnitTests.StandardExtensions.Globalization;

public class CountryCodesUnitTests
{
    [Fact(DisplayName = "Initializing the country codes dictionaries.")]
    public void Test1()
    {
        var roItem2 = CountryCodes.CountriesByAlpha2.Value["RO"];
        var roItem3 = CountryCodes.CountriesByAlpha3.Value["ROU"];
        var roItemN = CountryCodes.CountriesByInternationalName.Value["Romania"];
        var roItemT = CountryCodes.CountriesByTopLevelDomain.Value[".ro"];

        Assert.Equal(roItem2, roItem3);
        Assert.Equal(roItem2, roItemN);
        Assert.Equal(roItem2, roItemT);
        Assert.Equal(roItem3, roItemN);
        Assert.Equal(roItem3, roItemT);
        Assert.Equal(roItemN, roItemT);
    }
}
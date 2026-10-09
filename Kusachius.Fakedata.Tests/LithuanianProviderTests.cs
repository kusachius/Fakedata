using System.Text.RegularExpressions;
using Kusachius.Fakedata.Lt;

namespace Kusachius.Fakedata.Tests;

public class LithuanianProviderTests
{
    [Fact]
    public void PersonProvider_ReturnsNamesAndAValidEmailFormat()
    {
        var provider = new PersonProvider();

        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomMaleFirstName()));
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomFemaleFirstName()));
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomMaleLastName()));
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomFemaleLastName()));
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomLastName()));

        var name = provider.GetRandomName();
        var email = provider.GetRandomEmail(name);

        Assert.False(string.IsNullOrWhiteSpace(name));
        Assert.Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", email);
        Assert.Matches(@"^3\d{10}$", provider.GetRandomPersonNumber());
    }

    [Fact]
    public void CompanyProvider_ReturnsDataInExpectedFormats()
    {
        var provider = new CompanyProvider();

        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomCompany()));
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomTitle()));
        Assert.Matches(@"^\d{10}$", provider.GetRandomCompanyNumber());
        Assert.Matches(@"^\d{7}$", provider.GetRandomVatNumber());
    }

    [Fact]
    public void AddressProvider_ReturnsDataInExpectedFormats()
    {
        var provider = new AddressProvider();

        Assert.Matches(@"^.+ (g\.|pr\.|al\.) \d{1,2}(-\d{1,2})?$", provider.GetRandomAddress());
        Assert.False(string.IsNullOrWhiteSpace(provider.GetRandomCity()));
        Assert.Matches(@"^\d{5}$", provider.GetRandomZip());
        Assert.Matches(@"^8\d{8}$", provider.GetRandomPhone());
        Assert.Matches(@"^\+370\d{8}$", provider.GetRandomPhone("370"));
    }
}

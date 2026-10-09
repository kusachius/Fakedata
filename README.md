# Kusachius.Fakedata

`Kusachius.Fakedata` generates random Lithuanian data for tests and development.

## Installation

```shell
dotnet add package Kusachius.Fakedata
```

## Usage

```csharp
using Kusachius.Fakedata.Lt;

var people = new PersonProvider();
var companies = new CompanyProvider();
var addresses = new AddressProvider();

var name = people.GetRandomName();
var email = people.GetRandomEmail(name);
var company = companies.GetRandomCompany();
var address = addresses.GetRandomAddress();
var city = addresses.GetRandomCity();
```

The providers generate Lithuanian names, company names, company and VAT numbers,
addresses, postal codes, and phone numbers. Generated values are intended for
non-production test and development data.

## Publishing

The GitHub Actions workflow in [`.github/workflows/publish.yml`](.github/workflows/publish.yml)
builds and publishes the package to NuGet.org.

1. Push a version tag such as `v1.4.0`:

   ```shell
   git tag v1.4.0
   git push origin v1.4.0
   ```

The workflow uses the tag without its leading `v` as the NuGet package version.
It can also be run manually from the Actions tab by supplying a package version.

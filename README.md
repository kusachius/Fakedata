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

Before publishing, configure NuGet.org trusted publishing:

1. On NuGet.org, open **Trusted Publishing** and add a trusted publisher for
   the `kusachius/Fakedata` GitHub repository and the `publish.yml` workflow
   file. Select the NuGet.org account that owns `Kusachius.Fakedata` as the
   package owner.
2. Add a GitHub Actions secret named `NUGET_USER` containing that NuGet.org
   username. This is an account identifier, not an API key.
3. Push a version tag such as `v1.4.0`:

   ```shell
   git tag v1.4.0
   git push origin v1.4.0
   ```

The workflow uses the tag without its leading `v` as the NuGet package version.
It can also be run manually from the Actions tab by supplying a package version.
GitHub OIDC and `NuGet/login@v1` exchange the trusted publisher identity for a
short-lived key at publish time; no long-lived NuGet API key is stored in GitHub.

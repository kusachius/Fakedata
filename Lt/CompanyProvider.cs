using System;
namespace Kusachius.Fakedata.Lt
{
    /// <summary>
    /// 
    /// Data taken from https://github.com/fzaninotto/Faker
    /// 
    /// </summary>

    public class CompanyProvider
    {
        private Random random = new Random();
        private PersonProvider pers = new PersonProvider();

        protected string[] name = { "Moliūgas", "Ragai ir Kanopos", "Automaika", "Anodas", "Katodas", "Detis", "Tapu Tapu", "Super paslaugos",
            "Marketingo strategijos", "Gabun grupė", "Kept filialas", "Ekus", "Dideli Projektai" };

        protected string[] prefix = { "UAB", "UAB", "UAB", "UAB", "AB", "MB", "IĮ" };

        protected string[] titles = { "Direktorius", "Direktoriaus pavaduotojas", "Atstovas", "Vadybininkas", "CEO", "Įgaliotas asmuo", "Valytojas" };

        protected string GetRandom(string[] data)
        {
            return data[random.Next(data.Length)];
        }

        public string GetRandomCompany()
        {
            int r = random.Next(100);
            if (r < 20)
            {
                return GetRandom(prefix) + " " + GetRandom(name);
            }
            if (r < 40)
            {
                return "IĮ " + pers.GetRandomLastName();
            }

            return GetRandom(prefix) + " " + pers.GetRandomLastName() + " & " + pers.GetRandomLastName();
        }

        public string GetRandomCompanyNumber()
        {
            return random.Next(11111, 99999).ToString() + random.Next(11111, 99999).ToString();
        }

        public string GetRandomVatNumber(bool allowNull = false)
        {
            if (allowNull && random.Next(10) > 3)
            {
                return null;
            }
            return random.Next(1111111, 9999999).ToString();
        }

        public string GetRandomTitle()
        {
            return GetRandom(titles);
        }
    }
}

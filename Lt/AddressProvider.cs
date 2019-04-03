using System;
namespace Kusachius.Fakedata.Lt
{
    public class AddressProvider
    {
        private Random random = new Random();

        protected string[] city = { "Vilnius", "Kaunas", "Klaipėda", "Šiauliai", "Panevėžys",
        "Alytus", "Marijampolė", "Mažeikiai", "Jonava", "Utena", "Kėdainiai", "Telšiai", "Visaginas", "Tauragė",
        "Ukmergė" };
        protected string[] street = { "Klaipėdos", "Vilniaus", "Kauno", "Žalgirio", "Saltoniškių", "Laisvės", "Didžioji", "Liepų", "Gedimino",
            "Dzūkų", "Kovotojų", "Geležinio Vilko", "Antakalnio", "Kusačiaus", "Parko", "Ežero", "Upės" };


        protected string[] streetSuffix = { "g.", "g.", "g.", "g.", "g.", "pr.", "pr.", "al." };

        protected string GetRandomHouseNumber()
        {
            return random.Next(1, 100).ToString();
        }

        protected string GetRandom(string[] data)
        {
            return data[random.Next(data.Length)];
        }

        public string GetRandomAddress()
        {
            string ret = GetRandom(street) + ' ' + GetRandom(streetSuffix) + ' ' + GetRandomHouseNumber();
            if (random.Next(10) > 3)
            {
                ret += '-' + GetRandomHouseNumber();
            }
            return ret;
        }

        public string GetRandomCity()
        {
            return GetRandom(city);
        }

        public string GetRandomZip()
        {
            return random.Next(11111, 99999).ToString();
        }

        public string GetRandomPhone(string countryCode = null)
        {
            if (countryCode == null)
            {
                if (random.Next(10) > 3)
                {
                    return "86" + random.Next(111, 999).ToString() + random.Next(0, 9999).ToString("D4");
                }
                return "8" + random.Next(2111, 5999).ToString() + random.Next(0, 9999).ToString("D4");
            }
            return "+" + countryCode + random.Next(2111, 5999).ToString() + random.Next(0, 9999).ToString("D4");
        }
    }
}
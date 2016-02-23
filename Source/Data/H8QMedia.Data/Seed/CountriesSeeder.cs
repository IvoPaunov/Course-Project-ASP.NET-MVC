namespace H8QMedia.Data.Seed
{
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using H8QMedia.Data.Models;

    using Newtonsoft.Json.Linq;

    public class CountriesSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var countriesJsonAll = this.GetEmbeddedResourceAsString("H8QMedia.Data.Data.Countries.json");

            JArray jsonValCountries = JArray.Parse(countriesJsonAll) as JArray;
            dynamic countriesData = jsonValCountries;
            foreach (dynamic country in countriesData)
            {
                context.Countries.Add(new Country
                {
                    Name = country.Name,
                    Code = country.Code
                });
            }

            context.SaveChanges();
        }

        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}

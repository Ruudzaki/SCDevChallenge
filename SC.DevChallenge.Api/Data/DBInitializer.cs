using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;
using SC.DevChallenge.Api.Models;

namespace SC.DevChallenge.Api.Data
{
    public static class DBInitializer
    {


        public static void Seed(SCDevChallengeApiContext context)
        {
            using (var reader = new StreamReader("Input\\data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-AU")))
            {
                csv.Context.RegisterClassMap<InstrumentPriceMap>();
                var records = csv.GetRecords<InstrumentPrice>();
                context.Prices.AddRange(records);
                context.SaveChanges();
            }
        }
    }
}

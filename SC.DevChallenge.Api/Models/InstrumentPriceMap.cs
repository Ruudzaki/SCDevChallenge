using System.Globalization;
using CsvHelper.Configuration;

namespace SC.DevChallenge.Api.Models
{
    public class InstrumentPriceMap : ClassMap<InstrumentPrice>
    {
        public InstrumentPriceMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(p => p.Id).Ignore();
            Map(p => p.Date).TypeConverterOption.DateTimeStyles(DateTimeStyles.None);
        }
    }
}

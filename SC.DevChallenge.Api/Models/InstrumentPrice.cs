using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace SC.DevChallenge.Api.Models
{
    public class InstrumentPrice
    {
        public int Id { get; set; }
        public string Portfolio { get; set; }
        public string Owner { get; set; }
        public string Instrument { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyyTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [System.ComponentModel.TypeConverter(typeof(FrDateTimeConverter))]
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}

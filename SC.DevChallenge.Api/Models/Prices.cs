using System;

namespace SC.DevChallenge.Api.Models
{
    public class Prices
    {
        public int Id { get; set; }
        public string Portfolio { get; set; }
        public string InstrumentOwner { get; set; }
        public string Instrument { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}

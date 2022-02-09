using System;

namespace SC.DevChallenge.Api.Models
{
    public class InstrumentPrice
    {
        public int Id { get; set; }
        public string Portfolio { get; set; }
        public string Owner { get; set; }
        public string Instrument { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}

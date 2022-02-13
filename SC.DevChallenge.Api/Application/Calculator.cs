using System;
using System.Collections.Generic;
using System.Linq;
using SC.DevChallenge.Api.Data;
using SC.DevChallenge.Api.Models;

namespace SC.DevChallenge.Api.Application
{
    public class Calculator
    {

        public Calculator(SCDevChallengeApiContext context)
        {
            _context = context;
            _utills = new Utills();
        }

        private SCDevChallengeApiContext _context;
        private Utills _utills;

        public (double Average, DateTime StartDate) CalculateAveragePrice(string portfolio, string owner, string instrument,
            DateTime date)
        {
            var timeSlot = _utills.DateTimeToTimeSlot(date);
            var startPeriodDate = _utills.TimeSlotToDateTime(timeSlot);
            var endPeriodDate = _utills.TimeSlotToDateTime(++timeSlot);

            var prices = _context.Prices.Where(
                p => p.Portfolio.Equals(portfolio, StringComparison.CurrentCultureIgnoreCase)
                     && p.Instrument.Equals(instrument, StringComparison.CurrentCultureIgnoreCase)
                     && p.Owner.Equals(owner, StringComparison.CurrentCultureIgnoreCase)
                     && p.Date >= startPeriodDate
                     && p.Date < endPeriodDate);

            var average = Average(prices);

            return (average, startPeriodDate);
        }

        internal (double Average, DateTime StartDate) CalculateAveragePrice(string portfolio, string owner, string instrument)
        {
            var prices = _context.Prices.Where(
                p => p.Portfolio.Equals(portfolio)
                     && p.Instrument.Equals(instrument)
                     && p.Owner.Equals(owner));

            var average = Average(prices);
            
            return (average, _utills.InitDateTime);
        }

        private double Average(IQueryable<InstrumentPrice> prices)
        {
            double totalPrice = 0;
            double average = 0;

            if (prices.Count() != 0)
            {
                foreach (var price in prices)
                {
                    totalPrice += price.Price;
                }

                average = totalPrice / prices.Count();
            }

            return average;
        }
    }
}

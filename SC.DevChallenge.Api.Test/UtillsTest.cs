using System;
using NUnit.Framework;
using SC.DevChallenge.Api.Application;

namespace SC.DevChallenge.Api.Test
{
    [TestFixture]
    public class UtillsTest
    {
        [TestCase(0, ExpectedResult = "2018-01-01 00:00:00")]
        [TestCase(1, ExpectedResult = "2018-01-01 02:46:40")]
        [TestCase(2, ExpectedResult = "2018-01-01 05:33:20")]
        public DateTime TimeSlotToDateTime_TimeSlot_FirstDateTime(int timeSlot)
        {
            var utills = new Utills();
            return utills.TimeSlotToDateTime(timeSlot);
        }

        [TestCase("2018-01-01 00:00:00", ExpectedResult = 0)]
        [TestCase("2018-01-01 01:46:40", ExpectedResult = 0)]
        [TestCase("2018-01-01 02:46:40", ExpectedResult = 1)]
        [TestCase("2018-01-01 03:46:40", ExpectedResult = 1)]
        [TestCase("2018-01-01 05:46:40", ExpectedResult = 2)]
        public int DateTimeToTimeSlot_DateTimeInRange_TimeSlot(DateTime dateTime)
        {
            var utills = new Utills();
            return utills.DateTimeToTimeSlot(dateTime);
        }
    }
}

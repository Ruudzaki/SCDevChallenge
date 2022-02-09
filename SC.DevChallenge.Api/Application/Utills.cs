using System;

namespace SC.DevChallenge.Api.Application
{
    public class Utills
    {
        public Utills(DateTime initDate, int timeSlotRange)
        {
            InitDateTime = initDate;
            TimeSlotRange = timeSlotRange;
        }

        public int TimeSlotRange { get; }
        public DateTime InitDateTime { get; set; }

        public Utills() : this (new DateTime(2018, 1, 1), 10000) { }

        public int DateTimeToTimeSlot(DateTime dateTime)
        {
            int timeSlot = (int) (dateTime.Subtract(InitDateTime).TotalSeconds / 10000);

            return timeSlot;
        }

        public DateTime TimeSlotToDateTime(int timeSlot)
        {
            return InitDateTime.AddSeconds(10000 * timeSlot);
        }
    }
}

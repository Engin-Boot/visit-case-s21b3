//using System;
using Xunit;


namespace Receiver.Tests
{
    public class ReceiverTest
    {
        private readonly AggregateClass _aggregateObj = new AggregateClass();
        

        [Fact]
        public void WhenGivenNullStringInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateObj.SetDateAndTime("", "01:30:40");
            Assert.False(isStringInserted);

        }

        [Fact]
        public void WhenGivenNullStringInSetDayCountThenTheStringIsNotInserted()
        {
            bool isStringInserted = _aggregateObj.SetDayCount("");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenInsertedInvalidDayInSetDayCountThenTheStringIsNotInserted()
        {
            bool isStringInserted = _aggregateObj.SetDayCount("Tre");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenGivenInvalidDateAndTimeInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateObj.SetDateAndTime("32/09/2020", "28:30:40");
            Assert.False(isStringInserted);
        }

        
        [Fact]
        public void WhenGivenInvalidTimeInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateObj.SetDateAndTime("11/09/2020", "08:78:40");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenGivenInvalidTimeInSetDateAndTimeThenTheWholeStringIsNotAccepted()
        {
            bool isStringInserted = _aggregateObj.SetDateAndTime("11/09/2020", "08:45:63");
            Assert.False(isStringInserted);
        }
       
        [Fact]
        public void WhenGivenValidDateAndTimeThenCheckPeakInAMonth()
        {
            bool unused1 = _aggregateObj.SetDateAndTime("11/09/2020", "12:30:40");
            bool dummy = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool dummy1 = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool unused2 = _aggregateObj.SetDateAndTime("13/09/2020", "07:29:34");

            string peakInAMonth = _aggregateObj.GetPeakInMonth();
            Assert.Equal("12/09/2020", peakInAMonth);
        }

        [Fact]
        public void WhenGivenValidDateAndTimeThenCheckAvgPerDayInAWeek()
        {
            bool unused = _aggregateObj.SetDayCount("Mon");
            bool dummy = _aggregateObj.SetDayCount("Mon");
            bool dummy1 = _aggregateObj.SetDayCount("Tue");
            bool dummy2 = _aggregateObj.SetDayCount("Wed");

            double avgPerDayInAWeek = _aggregateObj.GetAvgPerDayInWeek("Mon");
            Assert.Equal(0.5, avgPerDayInAWeek);
        }
       /*
        [Fact]
        public void WhenGivenValidDateAndTimeThenCheckAvgPerHourInDay()
        {
            bool unused1 = _aggregateObj.SetDateAndTime("11/09/2020", "03:00:40");
            bool unused2 = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool unused3 = _aggregateObj.SetDateAndTime("13/09/2020", "03:30:20");
            bool unused4 = _aggregateObj.SetDateAndTime("14/09/2020", "07:29:34");
            bool unused5 = _aggregateObj.SetDateAndTime("15/09/2020", "15:45:19");
            bool unused6 = _aggregateObj.SetDateAndTime("16/09/2020", "09:34:04");
            bool unused7 = _aggregateObj.SetDateAndTime("17/09/2020", "08:29:34");

            double avgPerHourInDay = _aggregateObj.GetAvgPerHourInDay(3);
            Assert.Equal(0.43, avgPerHourInDay);
        }
       */
    }
}

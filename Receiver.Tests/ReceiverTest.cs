using System;
using Xunit;

namespace Receiver.Tests
{
    public class ReceiverTest
    {
        private readonly Receiver.AggregateClass _aggregateObj = new Receiver.AggregateClass();
        

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
            bool isStringInserted1 = _aggregateObj.SetDateAndTime("11/09/2020", "12:30:40");
            bool isStringInserted3 = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted4 = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted5 = _aggregateObj.SetDateAndTime("13/09/2020", "07:29:34");

            string peakInAMonth = _aggregateObj.GetPeakInMonth();
            Assert.Equal("12/09/2020", peakInAMonth);
        }

        [Fact]
        public void WhenGivenValidDateAndTimeThenCheckAvgPerDayInAWeek()
        {
            bool isStringInserted1 = _aggregateObj.SetDayCount("Mon");
            bool isStringInserted3 = _aggregateObj.SetDayCount("Mon");
            bool isStringInserted4 = _aggregateObj.SetDayCount("Tue");
            bool isStringInserted5 = _aggregateObj.SetDayCount("Wed");

            double avgPerDayInAWeek = _aggregateObj.GetAvgPerDayInWeek("Mon");
            Assert.Equal(0.5, avgPerDayInAWeek);
        }

        [Fact]
        public void WhenGivenValidDateAndTimeThenCheckAvgPerHourInDay()
        {
            bool isStringInserted1 = _aggregateObj.SetDateAndTime("11/09/2020", "03:00:40");
            bool isStringInserted3 = _aggregateObj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted4 = _aggregateObj.SetDateAndTime("13/09/2020", "03:30:20");
            bool isStringInserted5 = _aggregateObj.SetDateAndTime("14/09/2020", "07:29:34");
            bool isStringInserted6 = _aggregateObj.SetDateAndTime("15/09/2020", "15:45:19");
            bool isStringInserted7 = _aggregateObj.SetDateAndTime("16/09/2020", "09:34:04");
            bool isStringInserted8 = _aggregateObj.SetDateAndTime("17/09/2020", "08:29:34");

            double avgPerHourInDay = _aggregateObj.GetAvgPerHourInDay(03);
            Assert.Equal(0.43, avgPerHourInDay);
        }
    }
}

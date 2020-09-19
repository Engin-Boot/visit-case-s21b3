using System;
using Xunit;

namespace Receiver.Tests
{
    public class ReceiverTest
    {
        private Receiver.AggregateClass _aggregateobj = new Receiver.AggregateClass();
        

        [Fact]
        public void WhenGivenNullStringInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateobj.SetDateAndTime("", "01:30:40");
            Assert.False(isStringInserted);

        }

        [Fact]
        public void WhenGivenNullStringInSetDayCountThenThetringIsNotInserted()
        {
            bool isStringInserted = _aggregateobj.SetDayCount("");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenInsertedInvalidDayInSetDayCountThenTheStringIsNotInserted()
        {
            bool isStringInserted = _aggregateobj.SetDayCount("Tre");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenGivenInvalidDateAndTimeInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateobj.SetDateAndTime("32/09/2020", "28:30:40");
            Assert.False(isStringInserted);
        }

        
        [Fact]
        public void WhenGivenInvalidTimeInSetDateAndTimeThenTheWholeStringIsNotInserted()
        {
            bool isStringInserted = _aggregateobj.SetDateAndTime("11/09/2020", "08:78:40");
            Assert.False(isStringInserted);
        }

        [Fact]
        public void WhenGivenInvalidTimeInSetDateAndTimeThenTheWholeStringIsNotAccepted()
        {
            bool isStringInserted = _aggregateobj.SetDateAndTime("11/09/2020", "08:45:63");
            Assert.False(isStringInserted);
        }
       
        [Fact]
        public void WhenGivenvalidDateAndTimeThenCheckPeakInAMonth()
        {
            bool isStringInserted1 = _aggregateobj.SetDateAndTime("11/09/2020", "12:30:40");
            bool isStringInserted3 = _aggregateobj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted4 = _aggregateobj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted5 = _aggregateobj.SetDateAndTime("13/09/2020", "07:29:34");

            string peakInAMonth = _aggregateobj.GetPeakInMonth();
            Assert.Equal("12/09/2020", peakInAMonth);
        }

        [Fact]
        public void WhenGivenvalidDateAndTimeThenCheckAvgPerDayInAWeek()
        {
            bool isStringInserted1 = _aggregateobj.SetDayCount("Mon");
            bool isStringInserted3 = _aggregateobj.SetDayCount("Mon");
            bool isStringInserted4 = _aggregateobj.SetDayCount("Tue");
            bool isStringInserted5 = _aggregateobj.SetDayCount("Wed");

            double avgPerDayInAWeek = _aggregateobj.GetAvgPerDayInWeek("Mon");
            Assert.Equal(0.5, avgPerDayInAWeek);
        }

        [Fact]
        public void WhenGivenvalidDateAndTimeThenCheckAvgPerHourInDay()
        {
            bool isStringInserted1 = _aggregateobj.SetDateAndTime("11/09/2020", "03:00:40");
            bool isStringInserted3 = _aggregateobj.SetDateAndTime("12/09/2020", "03:08:20");
            bool isStringInserted4 = _aggregateobj.SetDateAndTime("13/09/2020", "03:30:20");
            bool isStringInserted5 = _aggregateobj.SetDateAndTime("14/09/2020", "07:29:34");
            bool isStringInserted6 = _aggregateobj.SetDateAndTime("15/09/2020", "15:45:19");
            bool isStringInserted7 = _aggregateobj.SetDateAndTime("16/09/2020", "09:34:04");
            bool isStringInserted8 = _aggregateobj.SetDateAndTime("17/09/2020", "08:29:34");

            double AvgPerHourInDay = _aggregateobj.GetAvgPerHourInDay(03);
            Assert.Equal(0.43, AvgPerHourInDay);
        }
    }
}

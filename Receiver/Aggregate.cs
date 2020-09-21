using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Receiver
{
   public class AggregateClass
    {
        readonly Dictionary<string, ArrayList> _dateAndTime = new Dictionary<string, ArrayList>();
        readonly Dictionary<string, Int32> _dayAndCount = new Dictionary<string, int>();

        private bool IsDateValid(string date)
        {
           // var formats = new[] { "dd/MM/yyyy" }; 
            if (DateTime.TryParse(date, out DateTime unused))
            { 
                return true;
            } 
            else
            { 
                return false;
            }
        }

        private bool IsTimeValid(string time)
        { 
            return TimeSpan.TryParse(time, out TimeSpan unused);
        }

        private void AddDateAndTime(string date, string time)
        {
            if (_dateAndTime.TryGetValue(date, out ArrayList timeForDate))
            {
                timeForDate.Add(time);
            }
            else 
            {
                ArrayList arr2 = new ArrayList { time };
                _dateAndTime.Add(date, arr2);

            }
        }

        public bool SetDateAndTime(string date, string time)

        {
            bool isDateValid = IsDateValid(date);
            bool isTimeValid = IsTimeValid(time);

            if (isDateValid && isTimeValid)
            {
                AddDateAndTime(date, time);
                return true;
            }

            return false;
        }

        private bool IsDayValid(string day)
        {
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};

            bool validDay = false;
            foreach (string tempDay in days)
            {
                if (string.Equals(day, tempDay))
                {
                    validDay = true;
                }
            }

            return validDay;

        }

        private void AddDayCount(string day)
        {
            if (_dayAndCount.TryGetValue(day, out int count))
            {
                _dayAndCount[day] = count + 1;
            }
            else 
            {
                _dayAndCount.Add(day, 1);
            }

        }
        public bool SetDayCount(String day)
        {
            bool isDayValid = IsDayValid(day);

            if (isDayValid)
            {
                AddDayCount(day);
            }

            return isDayValid;
        }

        private bool CompareTime(string time , int start)
        {
            bool ans = false;
            //string s = time.Substring(0, 2);
            char[] separator = new char[] {':'};
            Int32 noOfString = 3;
            string[] s = time.Split(separator, noOfString, StringSplitOptions.None);
            int timeGiven= Int32.Parse(s[0]);
            if (timeGiven == start)
            {
                ans = true;
            }
            return ans;
        }

        private int GetVisitCountOfAnHour(ArrayList timeList, int start)
        {
            int count2 = 0;
            foreach (string time in timeList)
            {
                if (CompareTime(time, start))
                {
                    count2++;
                }
            }

            return count2;
        }
        public double GetAvgPerHourInDay(int start)
        {
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
               // string date = _dateAndTime.ElementAt(i).Key;
                ArrayList timeList = _dateAndTime.ElementAt(i).Value;
                
                count += GetVisitCountOfAnHour(timeList, start);

            }

            double ans = (count * 1.0) / 7;
            double value = Math.Round(ans, 2, MidpointRounding.ToEven);
            return value;

        }

        public double GetAvgPerDayInWeek(string day)
        {
            Console.WriteLine(day);
            Int32 sumOfFootFallInDay = _dayAndCount[day];
            double ans = (sumOfFootFallInDay*1.0) / 4;
            double value = Math.Round(ans, 2, MidpointRounding.ToEven);
            return value;
        }

        public string GetPeakInMonth()
        {
            int max= Int32.MinValue;
            string maxFootFallDate = "";
            for (int i = 0; i < _dateAndTime.Count; i++)
            {
                String key = _dateAndTime.ElementAt(i).Key;
                ArrayList value = _dateAndTime.ElementAt(i).Value;
                int len = value.Count;
                if (len > max)
                {
                    maxFootFallDate = key;
                    max = len;
                }
            }

            return maxFootFallDate;
        }

    }
}

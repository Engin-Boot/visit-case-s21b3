using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Collections;

namespace Receiver
{
   public class AggregateClass
    {
        readonly Dictionary<string, ArrayList> _dateAndTime = new Dictionary<string, ArrayList>();
        readonly Dictionary<string, Int32> _dayAndCount = new Dictionary<string, int>();

        private bool IsDateValid(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                return false;
            }
            else if  (Int32.Parse(date.Substring(0,2)) <= 0 || (Int32.Parse(date.Substring(0,2)) > 31))
            {
                return false;
            }

            return true;
        }

        private bool IsTimeValid(string time)
        {
            if (Int32.Parse(time.Substring(0, 2)) < 0 || Int32.Parse(time.Substring(0, 2)) >= 24 || Int32.Parse(time.Substring(3, 2)) < 0 || Int32.Parse(time.Substring(3, 2)) >= 60 || Int32.Parse(time.Substring(6, 2)) < 0 || Int32.Parse(time.Substring(6, 2)) >= 60)
            {
                return false;
            }

            return true;
        }
        public bool SetDateAndTime(string date, string time)

        {
            bool isDateValid = IsDateValid(date);
            bool isTimeValid = IsTimeValid(time);
            
            if (_dateAndTime.TryGetValue(date, out ArrayList timeForDate) && isTimeValid && isDateValid)
            {
                timeForDate.Add(time);
                return true;

            }
            else if(isTimeValid && isDateValid)
            {
                ArrayList arr2 = new ArrayList { time };
                _dateAndTime.Add(date, arr2);
                return true;

            }

            return false;
        }

        private bool IsDayValid(string day)
        {
            if (String.IsNullOrEmpty(day))
            {
                return false;
            }
            string[] _Days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};

            bool validDay = false;
            for (int i = 0; i < _Days.Length; i++)
            {
                if (string.Equals(day, _Days[i]))
                {
                    validDay = true;
                }
            }

            return validDay;

        }

        public bool SetDayCount(String day)
        {
            bool isDayValid = IsDayValid(day);

            if (_dayAndCount.TryGetValue(day, out int count) && isDayValid )
            {
                _dayAndCount[day] = count + 1;
                
            }
            else if(isDayValid)
            {
                _dayAndCount.Add(day, 1);
               
            }

            return isDayValid;
        }

        private bool CompareTime(string time , int start)
        {
            bool ans = false;
            int timeGiven= Int32.Parse(time.Substring(0, 2));
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

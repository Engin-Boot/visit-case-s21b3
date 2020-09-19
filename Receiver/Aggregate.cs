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

        
        public bool SetDateAndTime(string date, string time)

        {  bool isDateTimeInserted = false;
           
            if (String.IsNullOrEmpty(date) || String.IsNullOrEmpty(time))
            {
                return isDateTimeInserted;
            }
            else if  (Int32.Parse(date.Substring(0,2)) <= 0 || (Int32.Parse(date.Substring(0,2)) > 31))
            {
                return isDateTimeInserted;
            }

            else if (Int32.Parse(time.Substring(0, 2)) < 0 || Int32.Parse(time.Substring(0, 2)) >= 24)
            {
                return isDateTimeInserted;
            }

            else if (Int32.Parse(time.Substring(3, 2)) < 0 || Int32.Parse(time.Substring(3, 2)) >= 60)
            {
                return isDateTimeInserted;
            }
            else if (Int32.Parse(time.Substring(6, 2)) < 0 || Int32.Parse(time.Substring(6, 2)) >= 60)
            {
                return isDateTimeInserted;
            }
            
            else if (_dateAndTime.TryGetValue(date, out ArrayList timeForDate))
            {
                timeForDate.Add(time);
                isDateTimeInserted = true;

            }
            else 
            {
                ArrayList arr2 = new ArrayList { time };
                _dateAndTime.Add(date, arr2);
                isDateTimeInserted = true;
            }

            return isDateTimeInserted;
        }

        public bool SetDayCount(String day)
        {
            string[] _Days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};

            bool isDayInserted = false;
            for (int i = 0; i < _Days.Length; i++)
            {
                if (string.Equals(day, _Days[i]))
                {
                    isDayInserted = true;
                }
            }
           if (String.IsNullOrEmpty(day))
            {
                return isDayInserted;
            }
            else if (_dayAndCount.TryGetValue(day, out int count) && isDayInserted )
            {
                _dayAndCount[day] = count + 1;
                
            }
            else if (isDayInserted)
            {
                _dayAndCount.Add(day, 1);
               
            }

            return isDayInserted;
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

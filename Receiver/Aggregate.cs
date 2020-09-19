using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Receiver
{
    class Aggregate
    {
        readonly Dictionary<string, ArrayList> _dateAndTime = new Dictionary<string, ArrayList>();
        readonly Dictionary<string, Int32> _dayAndCount = new Dictionary<string, int>();


        public void SetDateAndTime(string date, string time)
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

        public void SetDayCount(String day)
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

        public bool CompareTime(string time , int start)
        {
            bool ans = false;
            int timeGiven= Int32.Parse(time.Substring(0, 2));
            if (timeGiven == start)
            {
                ans = true;
            }
            return ans;
        }

        public int GetVisitCountOfAnHour(ArrayList timeList, int start)
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
                string date = _dateAndTime.ElementAt(i).Key;
                ArrayList timeList = _dateAndTime.ElementAt(i).Value;
                
                count += GetVisitCountOfAnHour(timeList, start);

            }

            double ans = (count * 1.0) / 7;
            return ans;

        }

        public double GetAvgPerDayInWeek(string day)
        {
            Console.WriteLine(day);
            Int32 sumOfFootFallInDay = _dayAndCount[day];
            double ans = (sumOfFootFallInDay*1.0) / 4;
            return ans;
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

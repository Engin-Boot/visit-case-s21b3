using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Receiver
{
    class AggregateClass
    {
        IDictionary<string, int> _DayAndCount = new Dictionary<string, int>();
        IDictionary<string, ArrayList> _DateAndTime = new Dictionary<string, ArrayList>();
        string currentdate = null;
        ArrayList _time = new ArrayList();

        public void StoreString(string StringFromConsole)
        { char[] separator = { ',' };
            Int32 NoOfString = 3;
            String[] StringAfterSplit = StringFromConsole.Split(separator, NoOfString); //0-date 1-day 2-time

            SetDayAndCount(StringAfterSplit[1]);
            SetDateAndTime(StringAfterSplit[0], StringAfterSplit[2]);

        }
        
        private void SetDayAndCount(string DayFromString)
        {
            int CounterOfDays;
            if (_DayAndCount.ContainsKey(DayFromString))
            {
                if (_DayAndCount.TryGetValue(DayFromString, out CounterOfDays))
                {
                    _DayAndCount[DayFromString] = CounterOfDays + 1;
                }

            }
            else
            {
                _DayAndCount.Add(DayFromString, 1);
            }
            

        }

        private void SetDateAndTime(string DateFromString, string TimefromString)
        {
                if (String.IsNullOrEmpty(currentdate))
            { 
                currentdate = DateFromString;
                _time.Add(TimefromString);
                _DateAndTime.Add(DateFromString, _time);
               
            }
            else
            {
                 if (currentdate.Equals(DateFromString))
                {
                    ArrayList _time2;
                    if (_DateAndTime.ContainsKey(DateFromString))
                    {
                        if (_DateAndTime.TryGetValue(DateFromString, out _time2))
                        {
                            _time2.Add(TimefromString);
                        }

                    }
                }
                 else
                {
                    currentdate = DateFromString; //0-date 1-day 2-time
                    ArrayList _time = new ArrayList();
                    _time.Add(TimefromString);
                    _DateAndTime.Add(DateFromString, _time);
                }

            }

           }
    }
}

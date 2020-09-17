using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Receiver
{
    class AggregateClass
    {
        IDictionary<string, string> _DateAndDay = new Dictionary<string, string>();
        IDictionary<string, ArrayList> _DateAndTime = new Dictionary<string, ArrayList>();
        string currentdate = null;
        ArrayList _time = new ArrayList();
        
        public void SetDateAndDay(string StringFromConsole)
        {
            char[] separator = { ' ' };
            Int32 NoOfString = 3;
            String[] StringAfterSplit = StringFromConsole.Split(separator, NoOfString);
            if (String.IsNullOrEmpty(currentdate))
            {
                currentdate = StringAfterSplit[0]; //0-date 1-day 2-time
                _DateAndDay.Add(StringAfterSplit[0], StringAfterSplit[1]);
                
            }
            else
            {
                if (currentdate.Equals(StringAfterSplit[0]))
                {
                    return;
                }
                else
                {
                    currentdate = StringAfterSplit[0]; //0-date 1-day 2-time
                    _DateAndDay.Add(StringAfterSplit[0], StringAfterSplit[1]);

                }
            }

        }

        public void SetDateAndTime(string StringFromConsole)
            {
            char[] separator = { ' ' };
            Int32 NoOfString = 3;
            String[] StringAfterSplit = StringFromConsole.Split(separator, NoOfString);
            if (String.IsNullOrEmpty(currentdate))
            { 
                currentdate = StringAfterSplit[0];
                _time.Add(StringAfterSplit[2]);
                _DateAndTime.Add(StringAfterSplit[0], _time);
               
            }
            else
            {
                 if (currentdate.Equals(StringAfterSplit[0]))
                {
                    ArrayList _time2;
                    if (_DateAndTime.ContainsKey(StringAfterSplit[0]))
                    {
                        if (_DateAndTime.TryGetValue(StringAfterSplit[0], out _time2))
                        {
                            _time2.Add(StringAfterSplit[2]);
                        }

                    }
                }
                 else
                {
                    currentdate = StringAfterSplit[0]; //0-date 1-day 2-time
                    ArrayList _time = new ArrayList();
                    _time.Add(StringAfterSplit[2]);
                    _DateAndTime.Add(StringAfterSplit[0], _time);
                }

            }

           }
    }
}

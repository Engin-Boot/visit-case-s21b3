using System;
using System.Collections.Generic;

namespace Receiver
{
    abstract class Program
    {
        
        static void GetAvgPerHourInDayForAWeek(List<double> avgPerHourInDayList, AggregateClass inputObj)
        {
            for (int i = 0; i < 12; i++)
            {
                avgPerHourInDayList.Add(inputObj.GetAvgPerHourInDay(i));
            }
        }

        static void GetAvgPerDayInWeekForAMonth(List<double> avgPerDayInWeekList, AggregateClass inputObj)
        {
            string[] daysName = { "Mon", "Tue", "Wed","Thu","Fri","Sat","Sun" };
            for (int i = 0; i < 7; i++)
            {
                avgPerDayInWeekList.Add(inputObj.GetAvgPerDayInWeek(daysName[i]));
            }
        }
        
   
        static void Main()
        {
            AggregateClass inputObj = new AggregateClass();
            
            //var listofinputstring = new List<string>();
                while (true)
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) // Check string
                    {
                        break;
                    }
                    char[] separator = new char[] {','};
                    Int32 noOfString = 3;
                    string[] stringfromconsole = line.Split(separator, noOfString, StringSplitOptions.None);
                    bool unused = inputObj.SetDateAndTime(stringfromconsole[0], stringfromconsole[2]);
                    bool dummy = inputObj.SetDayCount(stringfromconsole[1]);
                    
                }
                #region comment
           
             #endregion
             
            
            List<double> avgPerHourInDayList = new List<double>();
            List<double> avgPerDayInWeekList = new List<double>();
           // String peakDayInMonth = "";

           

            GetAvgPerHourInDayForAWeek(avgPerHourInDayList, inputObj);
            GetAvgPerDayInWeekForAMonth(avgPerDayInWeekList, inputObj);
            string peakDayInMonth=inputObj.GetPeakInMonth();

            #region comment

           
            #endregion

            WriteCsvOutputFile outputData= new WriteCsvOutputFile();
            outputData.WriteCsv(avgPerHourInDayList, avgPerDayInWeekList, peakDayInMonth);
            
        }
    }
}

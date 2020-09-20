using System;
using System.Collections.Generic;

namespace Receiver
{
   abstract class Program
    {
        static void GetAvgPerHourInDayForAWeek(List<double> avgPerHourInDayList, AggregateClass inputObj)
        {
            for (int i = 0; i < 24; i++)
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
            AggregateClass inputObj= new AggregateClass();
            
            string input;
            
            while ((input = Console.ReadLine()) != null)
            {
                var dayDayTime = input.Split(new[] {','}, 3);
                bool unused = inputObj.SetDateAndTime(dayDayTime[0],dayDayTime[2]);
                bool dummy = inputObj.SetDayCount(dayDayTime[1]);
            }
            #region comment
            /*
            inputObj.SetDateAndTime("01-09-2020", "09:10:11");
            inputObj.SetDayCount("Mon");
            inputObj.SetDateAndTime("01-09-2020", "10:10:11");
            inputObj.SetDayCount("Mon");
            inputObj.SetDateAndTime("02-09-2020", "09:10:11");
            inputObj.SetDayCount("Tue");
            inputObj.SetDateAndTime("03-09-2020", "09:10:11");
            inputObj.SetDayCount("Wed");
            inputObj.SetDateAndTime("04-09-2020", "09:10:11");
            inputObj.SetDayCount("Thu");
            inputObj.SetDateAndTime("05-09-2020", "09:10:11");
            inputObj.SetDayCount("Fri");
            inputObj.SetDateAndTime("06-09-2020", "09:10:11");
            inputObj.SetDayCount("Sat");
            inputObj.SetDateAndTime("07-09-2020", "09:10:11");
            inputObj.SetDayCount("Sun");
            inputObj.SetDateAndTime("08-09-2020", "09:10:11");
            inputObj.SetDayCount("Mon");
            inputObj.SetDateAndTime("09-09-2020", "09:10:11");
            inputObj.SetDayCount("Tue");
            */
             #endregion

            List<double> avgPerHourInDayList = new List<double>();
            List<double> avgPerDayInWeekList = new List<double>();
           // String peakDayInMonth = "";

           

            GetAvgPerHourInDayForAWeek(avgPerHourInDayList, inputObj);
            GetAvgPerDayInWeekForAMonth(avgPerDayInWeekList, inputObj);
            string peakDayInMonth=inputObj.GetPeakInMonth();

            #region comment

            /*
            Console.WriteLine("----------per hour------------");
            foreach (double item in avgPerHourInDayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------per day----------");
            foreach (double item2 in avgPerDayInWeekList)
            {
                Console.WriteLine(item2);
            }
            Console.WriteLine("------peak------");
            Console.WriteLine(peakDayInMonth);

            Console.WriteLine("--------csv file--------");
            */
            #endregion

            WriteCsvOutputFile outputData= new WriteCsvOutputFile();
            outputData.WriteCsv(avgPerHourInDayList, avgPerDayInWeekList, peakDayInMonth);
        }
    }
}

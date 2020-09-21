//using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Receiver
{
    class WriteCsvOutputFile
    {
       readonly StringBuilder _output = new StringBuilder();
       string path = @"c:\Result.csv";
      // private readonly string Separator = ",";
       readonly string s = "E04";
        private void WriteToCsvFromList(string heading, List<double> input)
        {
            _output.AppendLine(heading);
            _output.AppendLine();
            foreach (var t in input)
            {
                var k = t.ToString(s);
                // _output.Append(string.Join(Separator, k));
                _output.AppendLine(k);
            }

            _output.AppendLine();
        }
        public void WriteCsv(List<double> avgPerHourInDayList, List<double> avgPerDayInWeekList, string peakDayInMonth)
        {
            
            WriteToCsvFromList("Average per hour in a day", avgPerHourInDayList);
            _output.AppendLine();

            WriteToCsvFromList("Average per day in a week", avgPerDayInWeekList);
            _output.AppendLine();

            _output.Append("Peak day in a month");
            _output.Append(peakDayInMonth);

            
            File.WriteAllText(path, _output.ToString());

        }
    }
}

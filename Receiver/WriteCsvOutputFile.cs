using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

/*using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
*/
namespace Receiver
{
    class WriteCsvOutputFile
    {
       readonly StringBuilder _output = new StringBuilder();
       string path = @"c:\Result.csv";
       private string _seperator = ",";
       readonly string s = "E04";
        private void WriteToCsvFromList(string heading, List<double> Input)
        {
            _output.AppendLine(heading);
            _output.AppendLine();
            foreach (var t in Input)
            {
                var k = t.ToString(s);
                 _output.Append(string.Join(_seperator, k));
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

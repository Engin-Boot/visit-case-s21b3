using System;
using System.IO;
using System.Reflection;

namespace Sender
{
    public class GetInputFilePath
    {
        public string InputFilePath()
        {
            string csvFilePath = "";
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (executableLocation != null)
            {
                csvFilePath = Path.Combine(executableLocation, "SenderInputCsv.csv");
            }

            return csvFilePath;
        }
    }
}

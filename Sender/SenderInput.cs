using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Sender
{
    class SenderInput
    {
        public ArrayList readSensorData(String csvFilePath)
        {
            StreamReader source = new StreamReader(csvFilePath);
            ArrayList footFallData = new ArrayList();
            string line;
            while ((line = source.ReadLine()) != null)
            {
                footFallData.Add(line);
                // Console.WriteLine(line);
            }
            return footFallData;

        }
    }
}

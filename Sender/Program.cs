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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string executableLocation = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location);
                string csvFilePath = Path.Combine(executableLocation, "SenderInputCsv.csv");

                SenderInput inputData = new SenderInput();
                ArrayList footFallData = inputData.readSensorData(csvFilePath);

                PrintOnConsole printOnConsole = new PrintOnConsole();
                printOnConsole.printListData(footFallData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

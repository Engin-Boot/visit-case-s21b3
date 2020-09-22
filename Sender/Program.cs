using System;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Sender
{
   public class Program
    {
        private void CallCsvFile( string executableLocation , string csvFilePath)
        {
            //csvFilePath = Path.Combine(executableLocation, "SenderInputCsv.csv");
            CheckInputFileValid checkFile = new CheckInputFileValid();
            if (checkFile.CheckFileExists(csvFilePath))
            {
                StreamReader source = new StreamReader(csvFilePath);
                ArrayList footFallData = new ArrayList();
                string line;
                while ((line = source.ReadLine()) != null)
                {
                    footFallData.Add(line);
                }

                foreach (string data in footFallData)
                {
                    Console.WriteLine(data);
                }
            }

        }
        
        static void Main()
        {
            try
            {
                string FilePath = "";
                string Location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (Location != null)
                {
                    Program p = new Program(); 
                    FilePath = Path.Combine(Location, "SenderInputCsv.csv");
                    p.CallCsvFile(Location ,FilePath);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

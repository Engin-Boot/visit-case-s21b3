﻿using System;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Sender
{
   abstract class Program
    {
        public static string GetInputFilePath()
        {
            string csvFilePath = "";
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (executableLocation != null)
            {
                csvFilePath = Path.Combine(executableLocation, "SenderInputCsv.csv");

            }

            return csvFilePath;
        }
        static void Main()
        {
            try
            {
                string csvFilePath = GetInputFilePath();

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

﻿using System;
using System.IO;
using System.Collections;
//using System.Reflection;

namespace Sender
{
    class Program
    {
        static void Main()
        {
            try
            {
                GetInputFilePath inputPath = new GetInputFilePath();
                string csvFilePath = inputPath.InputFilePath();

                StreamReader source = new StreamReader(csvFilePath);
                ArrayList footFallData = new ArrayList();
                string line;
                while ((line = source.ReadLine()) != null)
                {
                    footFallData.Add(line);
                    // Console.WriteLine(line);
                }
                
                foreach (string data in footFallData)
                {
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

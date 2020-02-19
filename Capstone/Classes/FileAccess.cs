using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class FileAccess
    {

        public Dictionary<string, CateringItem> ReadItems()
        {
            Dictionary<string, CateringItem> menuItems = new Dictionary<string, CateringItem>();
            string line = "";
            string menuFile = @"c:/users/larryx/team8-c-sharp-week4-pair-exercises/19_Mini-Capstone/cateringsystem.csv";
            try
            {
                using (StreamReader sr = new StreamReader(menuFile))
                {

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        string[] lineArray = line.Split('|');
                        CateringItem item = new CateringItem(lineArray);
                        menuItems.Add(lineArray[0], item);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error reading the file. Please check file path in FileAccess class.");
                Console.WriteLine(e.Message);
            }
            
            return menuItems;
        }

        public void WriteItems(string log)
        {
            string logPath = @"c:/users/larryx/team8-c-sharp-week4-pair-exercises/19_Mini-Capstone/log.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.Write(log);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error writing log file. Check the file path in FileAccess class.");
                Console.WriteLine(e.Message);
            }
        }
    }
}

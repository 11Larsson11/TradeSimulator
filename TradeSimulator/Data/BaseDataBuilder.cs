using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSimulator.Data
{
    public class BaseDataBuilder
    {

        public static string[,] inputValues = new string[6000, 17];
        public static int fileLength = 0;

        public static void BaseValues(string link)
        {

            var linesList = File.ReadAllLines(link).ToList();
            fileLength = linesList.Count();
            int lineNr = 0;


            foreach (var line in linesList)
            {

                string[] array = line.Split(',');

                for (int i = 0; i < 7; i++)
                {
                    inputValues[lineNr, i] = array[i];
                }

                lineNr++;
            }
        }

    }
}

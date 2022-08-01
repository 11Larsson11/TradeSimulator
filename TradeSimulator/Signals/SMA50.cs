using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSimulator.Data;

namespace TradeSimulator.Signals
{
    public class SMA50
    {
        public static void Generate()
        {
            int smaValue = 50;
            int arrayPos = 7;
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
            var fileLength = BaseDataBuilder.fileLength;
            int arraySequence = smaValue - 1;


            for (int i = 1; i < fileLength; i++)
            {
                double[] tempValues = new double[smaValue];
                arraySequence++;
                int serial = 0;

                for (int j = i; j <= arraySequence; j++)
                {
                    var close = Convert.ToDouble(BaseDataBuilder.inputValues[j, 4], cultureUS);
                    tempValues[serial] = close;
                    serial++;
                }

                double sma = tempValues.Sum() / tempValues.Count();
                BaseDataBuilder.inputValues[arraySequence, arrayPos] = Convert.ToString(sma);
            }
        }
    }
}

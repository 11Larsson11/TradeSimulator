using TradeSimulator.Data;
using TradeSimulator.Signals;
using TradeSimulator.TradingModels;

namespace TradeSimulator
{
    public class Program
    {
        public static void Main()
        {


            string afry = (@"\Users\richa\OneDrive\Documents\Textfiler\AFRY.txt");

            //Data obtained from Yahoo Finance, historical data ( saved as .txt-file )


            BaseDataBuilder.BaseValues(afry);

            SMA.Generate(20,7);
            SMA.Generate(50,8);

            Crossover.Generate();



        }
    }
}







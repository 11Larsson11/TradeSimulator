

namespace TradeSimulator
{
    public class Program
    {
        public static void Main()
        {
            string afry = (@"\Users\richa\OneDrive\Documents\Textfiler\AFRY.txt");


            Data.BaseDataBuilder.BaseValues(afry);

            Signals.SMA50.Generate();
            Signals.SMA200.Generate();
            




        }
    }
}







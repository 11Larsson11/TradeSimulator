using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSimulator.Models;

namespace TradeSimulator.TradingModels
{
    public class Crossover
    {
        public static List<Models.Trade> trades = new List<Models.Trade>();
        public static double availableFunds = 500000;
        public static double currentStop = 0;
        public static int tradeID = 0;
        public static bool tradeExist = false;


        public static void Generate()
        {
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
            var fileLength = Data.BaseDataBuilder.fileLength;

            var inputVal = Data.BaseDataBuilder.inputValues;

            for (int i = 52; i < fileLength; i++)
            {

                string dateT = inputVal[i, 0];
                double closeT = Convert.ToDouble(inputVal[i, 4], cultureUS);
                double highT = Convert.ToDouble(inputVal[i, 2], cultureUS);
                double lowT = Convert.ToDouble(inputVal[i, 3], cultureUS);

                double e20T = Convert.ToDouble(inputVal[i, 7]);
                double e20Y = Convert.ToDouble(inputVal[i - 1, 7]);
                double e50T = Convert.ToDouble(inputVal[i, 8]);
                double e50Y = Convert.ToDouble(inputVal[i - 1, 8]);



                if (e20Y < e50Y && e20T > e50T && tradeExist == false) //A simple crossover trigger for open and close
                {
                    OpenPosition(closeT, dateT);
                    
                }

                if (e20Y > e50Y && e20T < e50T && tradeExist == true)
                {
                    ClosePosition(closeT, tradeID);
                }

                if (lowT < currentStop && tradeExist == true)
                {
                    ClosePosition(closeT, tradeID);
                }


            }

            Console.WriteLine("Of your 500 000 invested in the beginning, " + availableFunds + " remains.");

        }

        public static void OpenPosition(double closeToday, string dateT)
        {

            double risk = 0;
            double stopLevel = 0;
            double totalCost = 0;
            double amountStocks = 0;

            risk = availableFunds * 0.003;  //Each trade risk 0.3 % of the total capital
            double stopRange = closeToday * 0.05;   //Stop level 5 % of opening price

            amountStocks = risk / stopRange;



            stopLevel = closeToday - stopRange;
            currentStop = stopLevel;
            totalCost = (closeToday * amountStocks);

            availableFunds -= totalCost;
            

            Trade trade = new Trade();

            trade.Date = Convert.ToDateTime(dateT);
            trade.TradeId = tradeID;
            trade.OpenPrice = closeToday;
            trade.NumOfStocks = (int)Math.Round(amountStocks);

            trades.Add(trade);

            tradeExist = true;

        }

        public static void ClosePosition(double closeToday, int id)
        {
            var closeTrade = trades.FirstOrDefault(trade => trade.TradeId == id);

            if (closeTrade != null)
            {
                closeTrade.ClosePrice = closeToday;

                var returnVal = closeTrade.NumOfStocks * closeToday;
                availableFunds += returnVal;
                tradeExist = false;
            }

            else
            {
                Console.WriteLine("Trade not found.");
            }

            tradeID++;
            currentStop = 0;
        }
    }
}

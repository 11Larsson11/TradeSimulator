using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSimulator.Models
{
    public class Trade
    {
        public DateTime Date { get; set; }
        public int TradeId { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public int NumOfStocks { get; set; }
        public double StopLossValue { get; set; }

    }
}

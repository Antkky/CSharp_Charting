using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMREAPER
{
    public class PData
    {
        private dynamic best_bid_price;
        private dynamic best_ask_price;

        public double Bid {  get; set; }
        public double Ask { get; set; }

        public PData(dynamic best_bid_price, dynamic best_ask_price)
        {
            this.best_bid_price = best_bid_price;
            this.best_ask_price = best_ask_price;
        }
    }
}

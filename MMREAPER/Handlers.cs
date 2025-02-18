using rtChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMREAPER
{
    public class Handlers
    {
        public void HandleUpdate(dynamic Response)
        {
            PData pData = new PData(Response.data.best_bid_price, Response.data.best_ask_price);
        }
    }
}

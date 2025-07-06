using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.StockData
{
    public class UpdateStockDTORequests
    {
         public string ? Symbol { get; set; } 
        public string ? CompanyName { get; set; } 
       
        public decimal ? Purchase { get; set; }
       
        public decimal ? LastDiv { get; set; }
        public string ? Industry { get; set; } 
        public long ? MarketCap { get; set; }
    }
}
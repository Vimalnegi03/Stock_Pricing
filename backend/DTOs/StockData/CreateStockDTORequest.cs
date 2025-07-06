using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.StockData
{
    public class CreateStockRequestDto
    {
        [Required]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
       [Required]
        public decimal Purchase { get; set; }
       [Required]
        public decimal LastDiv { get; set; }
        [Required]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1,100000)]
        public long MarketCap { get; set; }
    }
}
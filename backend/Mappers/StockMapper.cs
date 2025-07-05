using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Stock;
using backend.DTOs.StockData;
using backend.Models;
using backend.StockData;

namespace backend.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
               Comments = stockModel.Comments?
    .Select(s => s.CommentToCommentDto())
    .ToList()

            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,


            };
        }

       public static void UpdateStockFromDTO(this Stock stock, UpdateStockDTORequests dto)
{
    if (dto.Symbol != null) stock.Symbol = dto.Symbol;
    if (dto.CompanyName != null) stock.CompanyName = dto.CompanyName;
    if (dto.Purchase.HasValue) stock.Purchase = dto.Purchase.Value;
    if (dto.LastDiv.HasValue) stock.LastDiv = dto.LastDiv.Value;
    if (dto.Industry != null) stock.Industry = dto.Industry;
    if (dto.MarketCap.HasValue) stock.MarketCap = dto.MarketCap.Value;
}

    }
}
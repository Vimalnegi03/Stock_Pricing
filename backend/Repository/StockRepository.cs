using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.DTOs.StockData;
using backend.Helpers;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.EntityFrameworkCore;
namespace backend.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> Create(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }


      public async Task<Stock?> DeleteByIdAsync(int id)
{
    var stock = await _context.Stocks.FindAsync(id);
    if (stock == null)
        return null; // ✅ return null if not found

    _context.Stocks.Remove(stock); // ✅ EF Core way to delete
    await _context.SaveChangesAsync();

    return stock; // ✅ return the deleted entity
}
        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
                if (query.SortBy.Equals("CompanyName",StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
                }
            }
            var skipNumber=(query.PageNumber-1)*query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

      public async Task<Stock?> GetByIdAsync(int id)
{
    return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(i=>i.Id==id);
}

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s=>s.Symbol==symbol);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDTORequests stockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
                return null;
            if (stockDto.Symbol != null)
            {
                    stock.Symbol = stockDto.Symbol;
                }
            if (stockDto.CompanyName != null)
            {
                    stock.CompanyName = stockDto.CompanyName;
                }
            if (stockDto.Purchase!=null)
            {
                stock.Purchase = (decimal)stockDto.Purchase;
                }
            if (stockDto.MarketCap != null)
            {
                    stock.MarketCap = (long)stockDto.MarketCap;
                }
            if (stockDto.LastDiv != null)
            {
                    stock.LastDiv = (decimal)stockDto.LastDiv;
                }
            if (stockDto.Industry != null)
            {
                    stock.Industry = stockDto.Industry;
                }

            stock.UpdateStockFromDTO(stockDto);
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
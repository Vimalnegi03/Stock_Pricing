using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.DTOs.StockData;
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
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks
                 .ToListAsync();
        }

      public async Task<Stock?> GetByIdAsync(int id)
{
    return await _context.Stocks.FindAsync(id);
}

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDTORequests stockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
                return null;
            stock.UpdateStockFromDTO(stockDto);
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
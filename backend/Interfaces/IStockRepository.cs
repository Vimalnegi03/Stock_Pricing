using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.StockData;
using backend.Helpers;
using backend.Models;

namespace backend.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> Create(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockDTORequests stockDto);
        Task<Stock?> DeleteByIdAsync(int id);
    }
}
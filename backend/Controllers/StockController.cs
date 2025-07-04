using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
    {
        var stocks = await _context.Stocks
            .Select(s => s.ToStockDto())
            .ToListAsync();

        if (stocks.Count == 0)
        {
            return BadRequest("No user found");
        }

        return Ok(stocks);
    }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stockDto = await _context.Stocks
                .Where(s => s.Id == id)
                .Select(s => s.ToStockDto())
                .FirstOrDefaultAsync();

            if (stockDto == null)
            {
                return NotFound();
            }

            return Ok(stockDto);
        }
    
        


    }
}
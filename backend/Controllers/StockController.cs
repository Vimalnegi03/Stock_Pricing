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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
       
        private readonly IStockRepository _repository;

        public StockController( IStockRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _repository.GetAllAsync(query);
            var stocksDto = stocks.Select(s => s.ToStockDto());

            if (stocksDto == null)
            {
                return BadRequest("No user found");
            }

            return Ok(stocksDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id == null)
            {
                return BadRequest("please enter an id");
            }
            var stock = await _repository.GetByIdAsync(id);
            var stockDto = stock.ToStockDto();
            if (stockDto == null)
            {
                return NotFound();
            }

            return Ok(stockDto);
        }
        
       [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var stockModel = stockDto.ToStockFromCreateDTO();
                Console.WriteLine(stockModel.Id);

                var createdStock = await _repository.Create(stockModel);

                return CreatedAtAction(nameof(GetById), new { id = createdStock.Id }, createdStock.ToStockDto());
            }
            catch (Exception ex)
            {
                Console.WriteLine("💥 Exception: " + ex);
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }
        }



        [HttpPatch("{id:int}")]
            public async Task<IActionResult> UpdateDto([FromRoute] int id, [FromBody] UpdateStockDTORequests dto)
            {
                  if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                try
            {
                var stock = await _repository.UpdateAsync(id, dto);
                return Ok(stock.ToStockDto());
            }
            catch (Exception ex)
            {

                Console.WriteLine("💥 Exception: " + ex);
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }
            }
            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                await _repository.DeleteByIdAsync(id);

            return Ok("Stock deleted successfully."); // ✅ Response
        }

    }
}
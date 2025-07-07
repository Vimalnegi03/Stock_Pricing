using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Extension;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.StockData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository repository, IStockRepository stockRepo, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _stockRepo = stockRepo;
            _userManager = userManager;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetComment()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _repository.GetAllComments();
            if (comments == null)
            {
                return NotFound("No comment found");
            }
            var comment_dtos = comments.Select(s => s.CommentToCommentDto());
            return Ok(comment_dtos);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repository.GetById(id);
            if (comment == null)
                return BadRequest("No comment found with this id");
            var comment_dto = comment.CommentToCommentDto();
            return Ok(comment_dto);
        }

        [HttpPost("{id:int}")]
        [Authorize]
        public async Task<IActionResult> CreateCommentt([FromRoute] int id, [FromBody] CreateCommentDto dTO)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var _appUser = await _userManager.FindByNameAsync(username);
            var data = await _repository.CreateComment(id, dTO);

            if (data == null)
                return BadRequest("Something went wrong");
            data.AppUserId = _appUser.Id;
            return Ok(data.CommentToCommentDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCommentt([FromRoute] int id)
        {
              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repository.DeleteComment(id);
            if (comment == null)
            {
                BadRequest("Please provide a valid id");
            }
            return Ok("Successfully deleted comment");
        }

        [HttpPatch("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateCommentt([FromRoute] int id, [FromBody] UpdateCommentDTo dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repository.UpdateComment(id, dTO);
            if (comment == null)
            {
                NotFound("please provide a valid id");
            }
            var commentDto = comment.CommentToCommentDto();
            return Ok(commentDto);
        }
    }
        
}
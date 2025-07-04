using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Interfaces;
using backend.Mappers;
using backend.StockData;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComment()
        {
            var comments = await _repository.GetAllComments();
            if (comments == null)
            {
                return NotFound("No comment found");
            }
            var comment_dtos = comments.Select(s => s.CommentToCommentDto());
            return Ok(comment_dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _repository.GetById(id);
            if (comment == null)
                return BadRequest("No comment found with this id");
            var comment_dto = comment.CommentToCommentDto();
            return Ok(comment_dto);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateCommentt([FromRoute] int id, [FromBody] CreateCommentDto dTO)
        {
            var data = await _repository.CreateComment(id, dTO);
            if (data == null)
                return BadRequest("Something went wrong");
            return Ok(data.CommentToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentt([FromRoute] int id)
        {
            var comment = await _repository.DeleteComment(id);
            if (comment == null)
            {
                BadRequest("Please provide a valid id");
            }
            return Ok("Successfully deleted comment");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCommentt([FromRoute] int id, [FromBody] UpdateCommentDTo dTO)
        {
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Interfaces;
using backend.Mappers;
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
            var comment_dtos=comments.Select(s=>s.CommentToCommentDto());
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

    }
        
}
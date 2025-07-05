using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.StockData;

namespace backend.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO CommentToCommentDto(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                Title = comment.Title,
                StockId = comment.StockId,
                CreatedOn = comment.CreatedOn,
            };
        }

       
    }
}
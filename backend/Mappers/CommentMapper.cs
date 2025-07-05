using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Comment;
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
        public static Comment CreateCommentToComment(this CreateCommentDto comment)
        {
            return new Comment
            {
                Content = comment.Content,
                Title = comment.Title,
              
            };
        } 
       public static Comment UpdateCommentToComment(this UpdateCommentDTo comment)
        {
            return new Comment
            {
                
                Content = comment?.Content,
                Title = comment?.Title,
              
            };
        } 
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Models;
using backend.StockData;

namespace backend.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment?> GetById(int id);
        Task<Comment> CreateComment(int id,CreateCommentDto dto);
        Task<Comment?> UpdateComment(int id, UpdateCommentDTo dto);
        Task<Comment> DeleteComment(int id);
    }
}
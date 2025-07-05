using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.DTOs.Comment;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.StockData;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateComment(int id, CreateCommentDto dto)
        {
            var stocks = await _context.Stocks.FindAsync(id);
            if (stocks == null)
                return null;

            var comment = dto.CreateCommentToComment();
            comment.StockId = id;
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            var Comment = await _context.Comments.FindAsync(id);
            if (Comment == null)
            {
                return null;
            }
            _context.Comments.Remove(Comment);
            await _context.SaveChangesAsync();
            return Comment;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateComment(int id, UpdateCommentDTo dto)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
                return null;
            if (dto.Title != null)
            {
                comment.Title = dto.Title;
            }
            if (dto.Content != null)
            {
                comment.Content = dto.Content;
            }

            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Interfaces;
using backend.Models;
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
        public Task<Comment> CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public Task<Comment?> UpdateComment(int id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Stock_Market_WebAPI.Data;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreatePost(Comment comment)
        {
                 await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public Task<Comment> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllCommennt()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommenntById(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null)
            {
                return null;
            }
            return comment;

        }

        public Task<Comment> UpdatePost(int id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<Comment?> DeletePost(Guid id)
        {
            var existingComment= await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            _context.Comments.Remove(existingComment);
            await _context.SaveChangesAsync();
            return existingComment;

        }

        public async Task<List<Comment>> GetAllCommennt()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommenntById(Guid id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null)
            {
                return null;
            }
            return comment;

        }

        public async Task<Comment?> UpdatePost(Guid id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;


            await _context.SaveChangesAsync();
            return existingComment;

        }



    }
}

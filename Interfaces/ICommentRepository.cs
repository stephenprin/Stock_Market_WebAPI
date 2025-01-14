using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommennt();

         Task<Comment?> GetCommenntById(int id);
        Task<Comment> CreatePost(Comment comment);
        Task<Comment> UpdatePost(int id, Comment comment);
        Task<Comment> DeletePost(int id);
    }
}

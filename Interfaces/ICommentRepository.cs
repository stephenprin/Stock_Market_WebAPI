using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommennt();

         Task<Comment?> GetCommenntById(Guid id);
        Task<Comment> CreatePost(Comment comment);
        Task<Comment?> UpdatePost(Guid id, Comment comment);
        Task<Comment?> DeletePost(Guid id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Mappers;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await commentRepository.GetAllCommennt();
            var commentsDto = comments.Select(x => x.toCommentDto());
            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            var comment = await commentRepository.GetCommenntById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }
    }
}

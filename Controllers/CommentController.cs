using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Dtos.Comment;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Mappers;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IStockRepository stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            this.commentRepository = commentRepository;
            this.stockRepository = stockRepository;
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

        [HttpPost("{stockId}/create")]
        public async Task<IActionResult> AddComment([FromRoute] int stockId ,[FromBody] CreateCommentDto commentDto)
        {
            if( !await stockRepository.StockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var commentModel= commentDto.toCommentModel(stockId);
            var comment = await commentRepository.CreatePost(commentModel);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment.toCommentDto());

        }
    }
}

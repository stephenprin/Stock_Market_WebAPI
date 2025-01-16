using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Dtos.Comment;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Mappers;
using Stock_Market_WebAPI.Models;

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
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            var comments = await commentRepository.GetAllCommennt();
            var commentsDto = comments.Select(x => x.toCommentDto());
            return Ok(commentsDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetComment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await commentRepository.GetCommenntById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }

        [HttpPost("{stockId:Guid}/create")]
        public async Task<IActionResult> AddComment([FromRoute] Guid stockId ,[FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ( !await stockRepository.StockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var commentModel= commentDto.toCommentModel(stockId);
            var comment = await commentRepository.CreatePost(commentModel);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment.toCommentDto());

        }

        [HttpPut("{id:Guid}/update")]
        public async Task<IActionResult> UpdateComment([FromRoute] Guid id, [FromBody] UpdateCommentDto commentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedComment = await commentRepository.UpdatePost(id, commentDto.toCommenUpdatetModel());
            if (updatedComment == null)
            {
                return NotFound();
            }
            
            return Ok(updatedComment.toCommentDto());
        }

        [HttpDelete("{id:Guid}/delete")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await commentRepository.DeletePost(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }
    }
}

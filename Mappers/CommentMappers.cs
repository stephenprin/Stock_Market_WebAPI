using Stock_Market_WebAPI.Dtos.Comment;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto toCommentDto(this Comment commentmodel)
        {

            return new CommentDto
            {
                Id = commentmodel.Id,
                Title = commentmodel.Title,
                Content = commentmodel.Content,
                CreatedOn = commentmodel.CreatedOn,
                StockId = commentmodel.StockId
            };



        }

        public static Comment toCommentModel(this CreateCommentDto createCommentDto, Guid stockId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId
            };
        }
        public static Comment toCommenUpdatetModel(this UpdateCommentDto updateCommentDto)
        {
            return new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
               
            };
        }

    }
}

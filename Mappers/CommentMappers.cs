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

        //public static Comment toCommentModel(this CreateCommentRequestDto createCommentRequestDto)
        //{
        //    return new Comment
        //    {
        //        Title = createCommentRequestDto.Title,
        //        Content = createCommentRequestDto.Content,
        //        StockId = createCommentRequestDto.StockId
        //    };
        //}
    }
}

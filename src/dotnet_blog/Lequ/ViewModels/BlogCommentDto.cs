namespace Lequ.ViewModels
{
    public class BlogCommentDto
    {
        public int BlogID { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}
namespace Lequ.ViewModels
{
    public class BlogCommentListViewModel
    {
        public int BlogID { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}
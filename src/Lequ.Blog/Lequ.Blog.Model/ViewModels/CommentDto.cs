namespace Lequ.Blog.Model.ViewModels
{
	public class CommentDto : ViewModelBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int BlogID { get; set; }
        public BlogDto? Blog { get; set; }
        public int? ParentID { get; set; }
        public CommentDto? Parent { get; set; }
    }
}

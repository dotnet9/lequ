namespace Lequ.Blog.Model.ViewModels
{
	public class CategoryDto : ViewModelBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentID { get; set; }
        public CategoryDto? Parent { get; set; }

        public List<BlogDto>? Blogs { get; set; }
    }
}

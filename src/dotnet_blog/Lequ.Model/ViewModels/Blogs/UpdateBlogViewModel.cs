namespace Lequ.Model.ViewModels.Blogs
{
    public class UpdateBlogViewModel : ViewModelBase
    {
        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Content { get; set; }

        public List<CheckBoxModel>? Albums { get; set; }
        public List<CheckBoxModel>? Categories { get; set; }
        public List<CheckBoxModel>? Tags { get; set; }
    }
}
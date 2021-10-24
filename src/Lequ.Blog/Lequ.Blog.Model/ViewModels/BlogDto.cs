using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lequ.Blog.Model.ViewModels
{
	public class BlogDto:ViewModelBase
	{

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Image { get; set; }
        public List<CategoryDto>? Categories { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Blog : ModelBase
    {
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(200)]
        public string? Image { get; set; } 

        public string? Content { get; set; }

		public List<BlogCategory>? BlogCategories { get; set; }

        public List<BlogTag>? BlogTags { get; set; }

        public List<BlogAlbum>? BlogAlbums { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}

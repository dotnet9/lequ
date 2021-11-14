namespace Lequ.ViewModels
{
    public class BlogForCreationDto : DtoBase
    {
        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Content { get; set; }

        public List<CheckBoxDto>? Albums { get; set; }
        public List<CheckBoxDto>? Categories { get; set; }
        public List<CheckBoxDto>? Tags { get; set; }
    }
}
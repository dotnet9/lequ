namespace Lequ.ViewModels
{
	public class BaseItem
	{
		public string? Name { get; set; }

		public string? Cover { get; set; }
	}
    public class BlogBaseDto
    {
	    public List<BaseItem>? Categories { get; set; }
	    public List<BaseItem>? Tags { get; set; }
	    public List<BaseItem>? Albums { get; set; }
	}
}

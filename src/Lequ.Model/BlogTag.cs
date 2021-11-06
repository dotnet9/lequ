namespace Lequ.Model
{
	public class BlogTag : ModelBase
	{
		public int BlogID { get; set; }

		public Blog? Blog { get; set; }

		public int TagID { get; set; }

		public Tag? Tag { get; set; }
	}
}

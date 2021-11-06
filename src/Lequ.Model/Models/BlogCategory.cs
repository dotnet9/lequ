namespace Lequ.Model.Models
{
	public class BlogCategory : ModelBase
	{
		public int BlogID { get; set; }

		public Blog? Blog { get; set; }

		public int CategoryID { get; set; }

		public Category? Category { get; set; }
	}
}

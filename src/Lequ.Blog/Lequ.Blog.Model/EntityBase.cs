using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model
{
	public class EntityBase
	{
		[Key]
		public int ID { get; set; }
		public bool Status { get; set; }
		public int? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public int? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}

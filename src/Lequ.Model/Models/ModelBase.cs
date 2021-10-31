using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class ModelBase
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

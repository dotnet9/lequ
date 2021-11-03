using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Model.Models
{
	public class ModelBase
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public ModelStatus? Status { get; set; } = ModelStatus.Disable;

		public int? CreateBy { get; set; }

		public DateTime? CreateDate { get; set; }

		public int? UpdateBy { get; set; }

		public DateTime? UpdateDate { get; set; }
	}

	public enum ModelStatus
	{
		IsDeleted, Normal, Disable, Check
	}
	public enum SortDirection
	{
		Ascending, Descending
	}
}

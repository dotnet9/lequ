using Lequ.Model;

namespace Lequ.Models
{
    public class ViewModelBase
	{
		public int ID { get; set; }

		public ModelStatus? Status { get; set; } = ModelStatus.Disable;

		public int? CreateBy { get; set; }

		public DateTime? CreateDate { get; set; }

		public int? UpdateBy { get; set; }

		public DateTime? UpdateDate { get; set; }
	}
}

namespace Lequ.Model.ViewModels
{
    public class ViewModelBase
	{
		public int ID { get; set; }

		public ModelStatus? Status { get; set; } = ModelStatus.Disable;

		public int? CreateUserID { get; set; }

		public DateTime? CreateDate { get; set; }

		public int? UpdateUserID { get; set; }

		public DateTime? UpdateDate { get; set; }
	}
}

namespace Lequ.Common.Helper
{
	public static class DateHelper
	{
		public static string ToDateString(this DateTime? datetime, string format = "yyyy-MM-dd HH:mm:ss")
		{
			return datetime != null ? datetime.Value.ToString(format) : "-";
		}
	}
}

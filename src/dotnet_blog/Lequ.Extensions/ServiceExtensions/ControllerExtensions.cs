using Microsoft.AspNetCore.Http;
using System.Net;

namespace Lequ.Extensions.ServiceExtensions
{
    public static class ControllerExtensions
    {
        public static string? RequestReferer(this HttpContext context)
        {
            return context.Request.Headers[HttpRequestHeader.Referer.ToString()].IsNullOrEmpty()
                ? null
                : context.Request.Headers[HttpRequestHeader.Referer.ToString()].ToString();
        }
    }

	public static class IEnumerableExtensions
	{
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
		{
			if (list == null)
			{
				return true;
			}

			if (!list.Any())
			{
				return true;
			}

			return false;
		}

		public static bool HasDuplicates<T, TProp>(this IEnumerable<T> list, Func<T, TProp> selector)
		{
			HashSet<TProp> hashSet = new HashSet<TProp>();
			foreach (T item in list)
			{
				if (!hashSet.Add(selector(item)))
				{
					return true;
				}
			}

			return false;
		}
	}
}

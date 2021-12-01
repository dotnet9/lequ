using System.Net;

namespace Lequ.ViewModels
{
	public class MessageDto<T>
	{
		public static MessageDto<T> CreateMessageDto(int code, string? message = null, T? data = default)
		{
			return new MessageDto<T>() { Code = code, Message = message, Data = data };
		}

		public static MessageDto<T> Success(string? msg = "success", T? response = default)
		{
			return CreateMessageDto((int)HttpStatusCode.OK, msg, response);
		}

		public static MessageDto<T> Fail(string? msg = "fail", T? response = default)
		{
			return CreateMessageDto((int)HttpStatusCode.BadRequest, msg, response);
		}

		public int Code { get; set; }

		public string? Message { get; set; }

		public T? Data { get; set; }

		public override string ToString()
		{
			return $"code: {Code}，message：{Message}，data：{Data}";
		}
	}
}
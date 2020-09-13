namespace WebClient
{
	public class Response
	{
		public bool Success { get; }
		public string JSON { get; }

		public int ErrorNumber { get; }

		public string ErrorCode { get; }

		public string ErrorMessage { get; }

		public Response(string json)
		{
			JSON = json;
			Success = true;
		}

		public Response(int number, string code, string message)
		{
			ErrorMessage = message;
			ErrorNumber = number;
			ErrorCode = code;
			Success = false;
		}
	}
}
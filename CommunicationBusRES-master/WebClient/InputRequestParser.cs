using DataModel;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WebClient.Interfaces;

namespace WebClient
{
	public class InputRequestParser : IInputRequestParser
	{
		private static readonly List<string> ALLOWED_REQUESTS = new List<string>() { "GET", "POST", "PATCH", "DELETE" };

		public ParseResult Parse(string userRequest, string query, string fields, string connectedTo, string contentedType)
		{
			try
			{
				string[] split = userRequest.Split(' ', '/');
				string operation = split[0].ToUpper();
				string noun = split[1];
				bool isGetAllOrPost = (string.Equals(operation, ALLOWED_REQUESTS[0]) || string.Equals(operation, ALLOWED_REQUESTS[1])) && split.Length == 2;

				string id = "0";
				if (!isGetAllOrPost)
				{
					id = split[2];
				}

				if (!ALLOWED_REQUESTS.Contains(operation))
				{
					return new ParseResult(5000, "BAD_FORMAT", $"Requested operation: {operation} is not supported!");
				}

				if (!isGetAllOrPost && !int.TryParse(id, out int intResult) && !string.Equals(operation, ALLOWED_REQUESTS[1]))
				{
					return new ParseResult(5000, "BAD_FORMAT", "Request parameter 'id' must be number!");
				}

				if (!string.IsNullOrEmpty(query))
				{
					string[] queryParts = query.Split(';');
					foreach (string part in queryParts)
					{
						string[] parts = part.Split('=');
						if (parts.Length < 2)
						{
							return new ParseResult(5000, "BAD_FORMAT", "Something is wrong with the 'query' parameter!");
						}
					}
				}

				if (!string.IsNullOrEmpty(fields) && string.Equals(operation, ALLOWED_REQUESTS[0]) && fields.Split(';').Length == 0)
				{
					return new ParseResult(5000, "BAD_FORMAT", "Something is wrong with the 'fileds' parameter!");
				}

				string finalNoun = isGetAllOrPost ? $"/{noun}" : $"/{noun}/{id}";
				var request = new Request(operation, finalNoun, query, fields, connectedTo, contentedType);
				string json = new JavaScriptSerializer().Serialize(request);

				return new ParseResult(json);
			}
			catch(Exception exception)
			{
				return new ParseResult(5000, "BAD_FORMAT", "ERROR: " + exception.Message);
			}
			
		}
	}
}
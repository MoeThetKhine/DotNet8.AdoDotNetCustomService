namespace DotNet8.AdoDotNetCustomService;

#region CustomException

public class CustomException : Exception
{
	public CustomException(string? message) : base(message) { }
}

#endregion
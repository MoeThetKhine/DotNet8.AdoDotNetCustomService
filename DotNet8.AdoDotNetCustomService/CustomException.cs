namespace DotNet8.AdoDotNetCustomService
{
	public class CustomException : Exception
	{
		public CustomException(string? message) : base(message) { }
	}
}

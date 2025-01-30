namespace DotNet8.AdoDotNetCustomService;

public class Program
{
	public static async Task Main(string[] args)
	{
		DotNetEnv.Env.Load(".env");
		await Read();
	}

	public static async Task Read()
	{
		try
		{
			AdoDotNetService adoDotNetService = new();
			string query = Query.GetAllBlogsQuery;
			List<BlogModel> lst = await adoDotNetService.QueryAsync<BlogModel>(query);

			foreach (var item in lst)
			{
				Console.WriteLine($"Blog Id : {item.BlogId}");
				Console.WriteLine($"Blog Title : {item.BlogTitle}");
				Console.WriteLine($"Blog Author : {item.BlogAuthor}");
				Console.WriteLine($"Blog Content : {item.BlogContent}");
			}
		}
		catch(CustomException ex)
		{
			throw new CustomException(ex.Message);
		}
	}
}
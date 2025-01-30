namespace DotNet8.AdoDotNetCustomService;

public class Program
{

	#region Main

	public static async Task Main(string[] args)
	{
		await Read();
		await Create("Sample Title", "Sample Author", "Sample Content", false);
	}

	#endregion

	#region Read

	public static async Task Read()
	{
		try
		{
			AdoDotNetService adoDotNetService = new();
			string query = Query.GetAllBlogsQuery;  
			List<BlogModel> lst = await adoDotNetService.QueryAsync<BlogModel>(query);

			foreach (var item in lst)
			{
				Console.WriteLine($"Blog Id: {item.BlogId}");
				Console.WriteLine($"Blog Title: {item.BlogTitle}");
				Console.WriteLine($"Blog Author: {item.BlogAuthor}");
				Console.WriteLine($"Blog Content: {item.BlogContent}");
			}
		}
		catch (Exception ex)  
		{
			Console.WriteLine($"Error reading data: {ex.Message}");
		}
	}

	#endregion

	#region Create

	public static async Task Create(string blogTitle, string blogAuthor, string blogContent, bool deleteFlag)
	{
		try
		{
			AdoDotNetService adoDotNetService = new();

			string query = "INSERT INTO dbo.Tbl_Blog (BlogTitle, BlogAuthor, BlogContent, DeleteFlag) " +
						   "VALUES (@BlogTitle, @BlogAuthor, @BlogContent, @DeleteFlag);"; // <-- Ensure DeleteFlag is here

			List<SqlParameter> parameters = new()
			{
				new("@BlogTitle", blogTitle),
				new("@BlogAuthor", blogAuthor),
				new("@BlogContent", blogContent),
				new("@DeleteFlag", deleteFlag)  
			};

			int result = await adoDotNetService.ExecuteAsync(query, parameters.ToArray());

			Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error creating blog: {ex.Message}");
		}
	}

	#endregion

}

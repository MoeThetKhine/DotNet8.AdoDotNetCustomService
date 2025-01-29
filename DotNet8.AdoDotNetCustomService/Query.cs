namespace DotNet8.AdoDotNetCustomService;

#region Query

public class Query
{

	#region GetAllBlogsQuery

	public static string GetAllBlogsQuery { get; } =
		@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] ORDER BY BlogId DESC";

	#endregion

	#region CreateBlogQuery

	public static string CreateBlogQuery { get; } =
   @"INSERT INTO Tbl_Blog (BlogTitle, BlogAuthor, BlogContent)
VALUES(@BlogTitle, @BlogAuthor, @BlogContent)";

	#endregion
}

#endregion

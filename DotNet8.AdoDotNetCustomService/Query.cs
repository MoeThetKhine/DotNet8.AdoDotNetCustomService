using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AdoDotNetCustomService
{
	public class Query
	{
		public static string GetAllBlogsQuery { get; } =
			@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] ORDER BY BlogId DESC";
	}
}

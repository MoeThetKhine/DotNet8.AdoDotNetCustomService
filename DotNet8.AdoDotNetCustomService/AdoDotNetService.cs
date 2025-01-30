namespace DotNet8.AdoDotNetCustomService;

public class AdoDotNetService
{
	private readonly string _connStr = "Data Source=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

	#region QueryAsync

	public async Task<List<T>> QueryAsync<T>(string query, SqlParameter[]? parameters = null, SqlTransaction? transaction = null)
	{
		using SqlConnection conn = GetConnection();
		await conn.OpenAsync();
		using SqlCommand cmd = new(query, conn, transaction);

		if (parameters is not null)
		{
			cmd.Parameters.AddRange(parameters);
		}

		SqlDataAdapter adapter = new(cmd);
		DataTable dt = new();
		adapter.Fill(dt);
		await conn.CloseAsync();

		string jsonStr = JsonConvert.SerializeObject(dt);
		var lst = JsonConvert.DeserializeObject<List<T>>(jsonStr)!;

		return lst;
	}

	#endregion

	#region QueryFirstOrDefaultAsync

	public async Task<DataTable> QueryFirstOrDefaultAsync(string query, SqlParameter[]? parameters = null, SqlTransaction? transaction = null)
	{
		using SqlConnection conn = GetConnection();
		await conn.OpenAsync();
		using SqlCommand cmd = new(query, conn, transaction);

		if (parameters is not null)
		{
			cmd.Parameters.AddRange(parameters);
		}

		SqlDataAdapter adapter = new(cmd);
		DataTable dt = new();
		adapter.Fill(dt);
		await conn.CloseAsync();

		return dt;
	}

	#endregion

	#region ExecuteAsync

	public async Task<int> ExecuteAsync(string query, SqlParameter[]? parameters = null, SqlTransaction? transaction = null)
	{
		using SqlConnection conn = GetConnection();
		await conn.OpenAsync();
		using SqlCommand cmd = new(query, conn, transaction);

		if (parameters is not null)
		{
			cmd.Parameters.AddRange(parameters);
		}

		int result = await cmd.ExecuteNonQueryAsync();
		await conn.CloseAsync();

		return result;
	}

	#endregion

	private SqlConnection GetConnection() => new(_connStr);
}

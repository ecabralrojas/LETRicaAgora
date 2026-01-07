using System.Data.SqlClient;
using System.Data;

namespace LET.Agora.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
    HttpClient CreateHttpAGORAConnectionAsync();
    string AgoraToken();
}

public class MSqlDbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    private readonly string _agoraApiBaseAddress;
    private readonly string _agoraToken;

    public MSqlDbConnectionFactory(string connectionString, string agoraApiBaseAddress,  string agoraToken)
    {
        _connectionString = connectionString;
        _agoraApiBaseAddress =  agoraApiBaseAddress;    
        _agoraToken = agoraToken;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }

    public HttpClient CreateHttpAGORAConnectionAsync()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_agoraApiBaseAddress);
        return httpClient;
    }

    public string AgoraToken()
    {
        return _agoraToken;
    }

}

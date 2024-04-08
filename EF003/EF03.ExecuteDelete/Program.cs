using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03.ExecuteDelete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();

            IDbConnection dbConnection =
                new SqlConnection(configuration.GetSection("constr").Value);

            var walletToUpdate = new Wallet
            {
                Id = 4,
            };

            var sql = "DELETE FROM Wallets WHERE Id = @Id;";

            var parameters = new
            {
                Id = walletToUpdate.Id,
            };

            dbConnection.Execute(sql, parameters);

            Console.ReadKey();
        }
    }
}

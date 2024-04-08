using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03.ExecuteInsertReturnIdentity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json").Build();

            IDbConnection dbConnection =
                new SqlConnection(configuration.GetSection("constr").Value);

            var walletToInsert = new Wallet
            {
                Holder = "Hayam",
                Balance = 17000,
            };

            var sql = "INSERT INTO Wallets (Holder, Balance) " +
                "VALUES(@Holder, @Balance) SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new
            {
                Holder = walletToInsert.Holder,
                Balance = walletToInsert.Balance
            };

            walletToInsert.Id = dbConnection.Query<int>(sql, parameters).Single();

            Console.WriteLine(walletToInsert);
            Console.ReadKey();
        }
    }
}

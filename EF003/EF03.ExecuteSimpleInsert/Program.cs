using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03.ExecuteSimpleInsert
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
                Holder = "Sara",
                Balance = 20000,
            };

            var sql = "INSERT INTO Wallets (Holder, Balance) " +
                "VALUES(@Holder, @Balance)";

            dbConnection.Execute(sql, new { Holder = walletToInsert.Holder, 
                Balance = walletToInsert.Balance});
            Console.ReadKey();
        }
    }
}

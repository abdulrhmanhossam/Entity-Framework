using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03.ExecuteUpdate
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
                Id = 11,
                Holder = "Zezo",
                Balance = 11000,
            };

            var sql = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance " +
                "WHERE Id = @Id;";

            var parameters = new
            {
                Id = walletToUpdate.Id,
                Holder = walletToUpdate.Holder,
                Balance = walletToUpdate.Balance
            };

            dbConnection.Execute(sql, parameters);

            Console.ReadKey();
        }
    }
}

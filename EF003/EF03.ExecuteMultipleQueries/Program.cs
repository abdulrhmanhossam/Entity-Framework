using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03.ExecuteMultipleQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json").Build();

            IDbConnection dbConnection =
                new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT MIN(Balance) FROM WALLETS;" +
                      "SELECT MAX(Balance) FROM WALLETS;";

            var result = dbConnection.QueryMultiple(sql);

            Console.WriteLine($"MIN: {result.ReadSingle<decimal>()} \n" +
                $"MAX: {result.ReadSingle<decimal>()}"); 

            Console.ReadKey();
        }
    }
}

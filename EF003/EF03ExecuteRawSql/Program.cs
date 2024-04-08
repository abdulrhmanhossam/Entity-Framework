using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF03ExecuteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();

            IDbConnection dbConnection =
                new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT * FROM WALLETS";

            Console.WriteLine("------- Using Dynamic Query --------");
            var resultAsDynamic = dbConnection.Query(sql);
            foreach (var result in resultAsDynamic)
                Console.WriteLine(result);


            Console.WriteLine("------- Using Typed Query --------");
            var wallets = dbConnection.Query<Wallet>(sql);
            foreach (var wallet in wallets)
                Console.WriteLine(wallet);

            Console.ReadKey();
        }
    }
}

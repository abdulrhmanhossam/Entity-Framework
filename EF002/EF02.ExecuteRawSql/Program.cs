using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF02.ExecuteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            SqlConnection connection = 
                new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT * FROM WALLETS";

            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            //Wallet wallet;

            while (reader.Read())
            {
                //wallet = new Wallet
                //{
                //    Id = reader.GetInt32("Id"),
                //    Holder = reader.GetString("Holder"),
                //    Balance = reader.GetDecimal("Balance")
                //};

                //Console.WriteLine(wallet);
                Console.WriteLine($"ID: {reader.GetInt32("ID")}, Holder: {reader.GetString
                    ("Holder")}, Balance: {reader.GetDecimal("Balance")}");
            }

            connection.Close();

            Console.ReadKey();
        }
    }
}

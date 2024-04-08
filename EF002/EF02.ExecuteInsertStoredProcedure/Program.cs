using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EF02.ExecuteInsertStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var walletToInsert = new Wallet
            {
                Holder = "Hassan",
                Balance = 4500,
            };

            SqlConnection connection =
                new SqlConnection(configuration.GetSection("constr").Value);

            //var sql = "INSERT INTO WALLETS (Holder, Balance) VALUES" +
            //    "(@Holder, @Balance);" +
            //    "SELECT CAST(scope_identity() AS int)";

            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Holder,
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Balance,
            };

            SqlCommand command = new SqlCommand("AddWallet", connection);

            command.Parameters.Add(holderParameter);
            command.Parameters.Add(balanceParameter);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Wallet For {walletToInsert.Holder}");
            }
            else
            {
                Console.WriteLine("ERORR");
            }

            connection.Close();

            Console.ReadKey();
        }
    }
}

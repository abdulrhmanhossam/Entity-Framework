using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;

namespace EF02.ExecuteInsertRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var walletToInsert = new Wallet
            {
                Holder = "Menna",
                Balance = 5000,
            };
            //var walletToInsert = new List<Wallet> 
            //{
            //    new Wallet
            //    {
            //    Holder = "Menna",
            //    Balance = 5000,
            //    }
            //};

            SqlConnection connection =
                new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "INSERT INTO WALLETS (Holder, Balance) VALUES" +
                "(@Holder, @Balance)";

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

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add(holderParameter);
            command.Parameters.Add(balanceParameter);

            command.CommandType = CommandType.Text;

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

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;

namespace EF02.ExecuteUpdateRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            SqlConnection connection =
                new SqlConnection(configuration.GetSection("constr").Value);
            Console.WriteLine(connection);

            var sql = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance " +
                $"WHERE Id = @Id";


            SqlParameter idParameter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 1,
            };

            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "Ahmed",
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = 9000,
            };

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add(idParameter);
            command.Parameters.Add(holderParameter);
            command.Parameters.Add(balanceParameter);

            command.CommandType = CommandType.Text;

            connection.Open();
            
            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Wallet Update Successuflly");
            }

            connection.Close();

            Console.ReadKey();
        }
    }
}

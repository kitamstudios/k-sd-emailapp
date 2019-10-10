using System;
using System.Data.SqlClient;
using System.Text;

namespace EmailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestReadFromSql();
            Console.WriteLine("Hello World!");
        }

        private static void TestReadFromSql()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Server=tcp:c-acc-edmi-ho-1.database.windows.net,1433;Initial Catalog=EmailContents;Persist Security Info=False;User ID=edmi;Password=X-c-acc-ho-1#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT *");
                    sb.Append("FROM [dbo].[Table]");
                    var sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}

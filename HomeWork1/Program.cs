using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = @"Data Source = DESKTOP-8TM07RL\SQLEXPRESS; Initial Catalog = GameStore;
            Integrated Security = SSPI; ";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Успешное подключение");
                string queryString = "select * from Game";
                SqlCommand query = new SqlCommand(queryString, connection);
                SqlDataReader result = query.ExecuteReader();
                Console.WriteLine();

                while (result.Read())
                {
                    for (int i = 0; i < result.FieldCount - 1; i++)
                    {
                        Console.Write($"{result[i]} - ");
                    }
                    Console.WriteLine(result[result.FieldCount - 1]);
                }






                if (result.HasRows == false) Console.WriteLine("No records");
                connection.Close();
                Console.WriteLine("Соединение завершено");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Что-то пошло не так: {ex.Message}");
            }
        }
    }
}
              
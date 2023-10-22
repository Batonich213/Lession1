using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = @"Data Source = DESKTOP-8TM07RL\SQLEXPRESS; Initial Catalog = CinemaDB;
            Integrated Security = SSPI; ";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Успешное подключение");
                // 4.1) подготовить SQL-код команды
                string queryString = "SELECT * FROM Film\r\nWhere releseYear>2023";
                // 4.2) сформировать объект DbCommand
                SqlCommand query = new SqlCommand(queryString, connection);
                // 4.3) выполнить команду
                SqlDataReader result = query.ExecuteReader();
                //for (int i = 0; i < result.FieldCount - 1; i++)
                //{
                //    Console.WriteLine($"{result.GetName(result.FieldCount-1)} - ");
                //}
                Console.WriteLine();
                while (result.Read())
                {
                    // цикл чтения результата запроса, на каждой итерации внутри result будет сохранятся 
                    // очередная строка табличного результата
                    //int id = (int)result[0];
                    //string title = (string)result[1];
                    //int ageRating = (int)result[2];
                    //int duration = (int)result[3];
                    //int releaseYear = (int)result[4];
                    //Console.WriteLine($"{id} - {title} - {ageRating} - {duration} - {releaseYear}");

                    // универсальный код чтения столбцов

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
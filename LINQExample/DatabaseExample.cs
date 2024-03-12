using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    internal class DatabaseExample
    {
        MySqlConnection connection;
        MySqlCommand command;

        void CreateConnection()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = root";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        void InsertIntoDB(string sqlQuery)
        {
            command = new MySqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("\n*************************\nOperation performed successfully!!\n*************************\n");
        }

        static void Main()
        {
            DatabaseExample databaseExample = new DatabaseExample();

            try
            {
                // Creating connection to MySQL database
                databaseExample.CreateConnection();

                // Defining variables for storing student data
                string firstName = "";
                string lastName = "";
                int id = 0;
                int regNo;

                Console.Write("Enter first name of student:\n>> ");
                firstName = Console.ReadLine();

                Console.Write("Enter last name of student:\n>> ");
                lastName = Console.ReadLine();

                Console.Write("Enter registration number of student:\n>> ");
                regNo = Convert.ToInt32(Console.ReadLine());

                string sqlQuery = "INSERT INTO college.students (reg_id, first_name, last_name) VALUES (" + regNo + ",'" + firstName + "','" + lastName + "')";
                databaseExample.InsertIntoDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}

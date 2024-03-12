using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class FullExample
    {
        MySqlConnection connection;
        MySqlCommand command;

        void CreateConnection()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = root";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        void InsertUpdateDelete(string sqlQuery)
        {
            command = new MySqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("\n****************************************\nOperation performed successfully!!\n****************************************\n");
        }

        void SelectRecords(string sql)
        {
            command = new MySqlCommand (sql, connection);  
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if(dt.Rows.Count > 0) {
                Console.WriteLine("\nid\t RegNo\t FirstName\t LastName");
                Console.WriteLine("---------------------------------------------");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string? studentId = dt.Rows[i]["id"].ToString();
                    string? studentRegNo = dt.Rows[i]["reg_id"].ToString();
                    string? studentFirstName = dt.Rows[i]["first_name"].ToString();
                    string? studentLastName = dt.Rows[i]["last_name"].ToString();

                    Console.WriteLine($"{studentId}\t {studentRegNo}\t {studentFirstName}\t\t {studentLastName}");
                }
                Console.WriteLine("---------------------------------------------\n");
            }
            else { Console.WriteLine("\n****************\nNo record found\n****************\n"); }
        }
        static void Main(string[] args)
        {
            FullExample obj = new FullExample();

            try
            {
                obj.CreateConnection();
                x: Console.WriteLine("1.Insert\t 2.Update \t3.Delete \t4.Select \t5.Exit");

                Console.Write("\nEnter your choice:\n>> ");
                int n = Convert.ToInt32(Console.ReadLine());
                string sql = "", firstName = "", lastName = "";
                int id = 0, regNo;

                switch (n)
                {
                    case 1:
                        Console.Write("\nEnter first name of student: \n>> ");
                        firstName = Console.ReadLine();

                        Console.Write("\nEnter last name of student: \n>> ");
                        lastName = Console.ReadLine();

                        Console.Write("\nEnter registration number of student: \n>> ");
                        regNo = Convert.ToInt32(Console.ReadLine());

                        sql = "INSERT INTO college.students (reg_id, first_name, last_name) VALUES (" + regNo + ",'" + firstName + "','" + lastName + "')";
                        obj.InsertUpdateDelete(sql);
                        break;

                    case 2:
                        Console.Write("\nEnter student id to be updated: \n>> ");
                        id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nEnter first name of student: \n>> ");
                        firstName = Console.ReadLine();

                        Console.Write("\nEnter last name of student: \n>> ");
                        lastName = Console.ReadLine();

                        Console.Write("\nEnter registration number of student: \n>>");
                        regNo = Convert.ToInt32(Console.ReadLine());

                        sql = "UPDATE college.students SET reg_id=" + regNo + ",first_name='" + firstName + "',last_name='" + lastName + "' WHERE id=" + id + "";
                        obj.InsertUpdateDelete(sql);
                        break;

                    case 3:
                        Console.Write("\nEnter studnet id to be deleted:\n>>");
                        id = Convert.ToInt32(Console.ReadLine());
                        sql = "DELETE FROM college.students WHERE id=" + id;
                        obj.InsertUpdateDelete(sql);
                        break;

                    case 4:
                        sql = "SELECT * FROM college.students";
                        obj.SelectRecords(sql);
                        break;

                    case 5:
                        goto y;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

                goto x;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        y: Console.WriteLine("Exiting application");
        }
    }
}

using MySql.Data.MySqlClient;
using System.Data;


namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = root";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Specify your SQL query
            string query = "SELECT * FROM studentinformation.student";

            // Create a MySqlDataAdapter
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

            // Create a DataSet to store the retrieved data
            DataSet dataSet = new DataSet();

            try
            {
                // Open the database connection
                connection.Open();

                // Fill the DataSet with data from the database
                adapter.Fill(dataSet, "student");

                // Iterate through the rows in the DataTable
                foreach (DataRow row in dataSet.Tables["student"].Rows)
                {
                    // Access data using column names or indices
                    int studentId = Convert.ToInt32(row["id"]);
                    string studentName = row["FirstName"].ToString() + " " + row["LastName"].ToString();

                    // Print or process the retrieved data
                    Console.WriteLine($"Student ID: {studentId}, Student Name: {studentName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }


        }
    }
}
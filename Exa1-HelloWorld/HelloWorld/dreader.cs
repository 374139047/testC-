using System;
using System.Data;
using System.Data.SqlClient;

namespace DataReader1App2
{
	class DataReader1
	{
		[STAThread]
		static void Main(string[] args)
		{
			SqlConnection connection = new SqlConnection(@"Data Source=(local);Integrated Security=SSPI;"+
				"Initial Catalog = NorthWind");

			connection.Open();

			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT CategoryID, CategoryName from Categories";

			SqlDataReader reader = command.ExecuteReader();

			while(reader.Read())
			{
				Console.WriteLine("\t{0}\t{1}",reader["CategoryID"],reader["CategoryName"]);

			}

			reader.Close();
			connection.Close();
			Console.ReadLine();
		}
	}
}

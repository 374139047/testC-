using System;
using System.Data;
using System.Data.OleDb;

namespace DataReader2App
{
	class DataReader2
	{
		[STAThread]
		static void Main(string[] args)
		{
			OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SimpleBank.mdb");

			connection.Open();

			OleDbCommand command = connection.CreateCommand();

			command.CommandText = "SELECT AccountID, Owner from Account";

			OleDbDataReader reader = command.ExecuteReader();

			while(reader.Read())
			{
				Console.WriteLine("\t{0}\t{1}",reader["AccountID"],reader["Owner"]);

			}

			reader.Close();
			connection.Close();

			Console.ReadLine();
		}
	}
}

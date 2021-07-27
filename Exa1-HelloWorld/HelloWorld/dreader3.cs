using System;
using System.Data;
using System.Data.OleDb;

namespace DataUpdateApp
{
	class DataUpdate
	{
		[STAThread]
		static void Main(string[] args)
		{
			OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SimpleBank.mdb");
			connection.Open();

			OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Account",connection);

			OleDbCommandBuilder builder2 = new OleDbCommandBuilder(adapter);

			
			DataSet dataset = new DataSet();
			
			adapter.Fill(dataset,"Account");

			Console.WriteLine("name before change:{0}",dataset.Tables["Account"].Rows[5]["Owner"]);
			dataset.Tables["Account"].Rows[5]["Owner"] = "Andrew5";

			adapter.Update(dataset,"Account");

			Console.WriteLine("name after change:{0}",dataset.Tables["Account"].Rows[5]["Owner"]);
			
			connection.Close();
			Console.ReadLine();

		}
	}
}

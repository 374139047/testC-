using System;
using System.Data;
using System.Data.OleDb;

namespace RowOperationApp
{
	class RowOperation
	{
		[STAThread]
		static void Main(string[] args)
		{
			OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SimpleBank.mdb");

			connection.Open();

			OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Account",connection);

			OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

			DataSet dataset = new DataSet();
			
			adapter.Fill(dataset,"Account");
			
			Console.WriteLine("rows before change:{0}",dataset.Tables["Account"].Rows.Count);
			
			DataColumn[] keys = new DataColumn[2];
			keys[0] = dataset.Tables["Account"].Columns["AccountID"];
			keys[1] = dataset.Tables["Account"].Columns["Owner"];
			dataset.Tables["Account"].PrimaryKey = keys;
			
			string[] name = {"333","jin2"};

			DataRow findRow = dataset.Tables["Account"].Rows.Find(name);
			if (findRow == null)
			{
				Console.WriteLine("Row {0}  {1} don't exist, add it to Employees table",name[0],name[1]);

				DataRow newRow = dataset.Tables["Account"].NewRow();
				newRow["AccountID"] = name[0];
				newRow["Owner"] = name[1];
				dataset.Tables["Account"].Rows.Add(newRow);

				Console.WriteLine("Row {0}  {1} successfully added it into Account table",name[0],name[1]);
				
			}
			else
			{
				Console.WriteLine("Row {0}  {1} already exist in Account table",name[0],name[1]);
			}



			adapter.Update(dataset,"Account");

			connection.Close();
			Console.ReadLine();

		}
	}
}

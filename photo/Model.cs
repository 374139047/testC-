using System;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace photo
{
	public class Model
	{
		public ArrayList idList,categoryList,nameList,descList,searchMark,albumList,timeList,observer;
		private SqlConnection sqlConn;
		public Image image;
		public int ListIndex;

		~Model()
		{
			if(sqlConn.State == ConnectionState.Open)
				sqlConn.Close();
		}

		public Model()
		{
			

			sqlConn=new SqlConnection("data source=Localhost;initial catalog=EAlbum;User ID=sa;Password=sa;");

			if(sqlConn.State == ConnectionState.Closed)
				sqlConn.Open();

			
		}


		public void addphoto2(string file)
		{
			System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			byte[] buffer = new byte[stream.Length];
			stream.Read(buffer, 0, (int)stream.Length);
			stream.Close();

			string strName = System.IO.Path.GetFileNameWithoutExtension(file);

			SqlCommand cmd = new SqlCommand("sp_InsertPhoto2", sqlConn);
			cmd.CommandType = CommandType.StoredProcedure;

			SqlParameter param = cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
				
			cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = strName;
			cmd.Parameters.Add("@image", SqlDbType.Image).Value = buffer;

			cmd.ExecuteNonQuery();
			

			buffer = null;

			dataUpdate("4",cateid);
			return nID;
			*/
		}
		


		

	}
}

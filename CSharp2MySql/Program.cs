using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace CSharp2MySql {
	class Program {
		static void Main(string[] args) {
			var connStr = "Server=localhost;Database=db_example;Uid=root;Pwd=il0v3cnk;";
			var conn = new MySqlConnection(connStr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Failed to open connection!");
			}
			var cmd = new MySqlCommand("select * from user;", conn);
			var reader = cmd.ExecuteReader();
			while(reader.Read()) {
				var name = reader.GetString(reader.GetOrdinal("name"));
				var email = reader.GetString(reader.GetOrdinal("email"));
				System.Diagnostics.Debug.WriteLine($"{name}:{email}");
			}
			reader.Close();
			conn.Close();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Consumer
{
    class BDConnect
    {
        private string connectionString = @"Data Source=DELL-ALINKA;Initial Catalog=Beers;Integrated Security=True";
        private SqlConnection connect;
        private int id = 0;

        public BDConnect()
        {
            connect = new SqlConnection(connectionString);
        }

        public void AddToBD(string[] elements)
        {
            ++id;
            string sql1 = "INSERT Beer (Id, Name, Type, Manufactures, Ai) VALUES (@Id, @Name, @Type, @Manufacture, @Ai)";
            SqlCommand cmd_SQL1 = new SqlCommand(sql1, connect);
            cmd_SQL1.Parameters.AddWithValue("@Id", elements[0]);
            cmd_SQL1.Parameters.AddWithValue("@Name", elements[1]);
            cmd_SQL1.Parameters.AddWithValue("@Type", elements[2]);
            cmd_SQL1.Parameters.AddWithValue("@Manufacture", elements[4]);
            cmd_SQL1.Parameters.AddWithValue("@Ai", elements[3]);

            string sql2 = "INSERT Chars (Id, BeerId, Transparency, Energy, Alcohol, Pitcher, Spill) VALUES (@Id, @BeerId, @Transparency, @Energy, @Alcohol, @Pitcher, @Spill)";
            SqlCommand cmd_SQL2 = new SqlCommand(sql2, connect);
            cmd_SQL2.Parameters.AddWithValue("@Id", id);
            cmd_SQL2.Parameters.AddWithValue("@BeerId", elements[0]);
            cmd_SQL2.Parameters.AddWithValue("@Transparency", elements[9]);
            cmd_SQL2.Parameters.AddWithValue("@Energy", elements[10]);
            cmd_SQL2.Parameters.AddWithValue("@Alcohol", elements[11]);
            cmd_SQL2.Parameters.AddWithValue("@Pitcher", elements[14]);
            cmd_SQL2.Parameters.AddWithValue("@Spill", elements[12] + elements[13]);

            string sql3 = "INSERT Ingredients (Id, BeerId, Water, Sugar, Hop, Malt) VALUES (@Id, @BeerId, @Water, @Sugar, @Hop, @Malt)";
            SqlCommand cmd_SQL3 = new SqlCommand(sql3, connect);
            cmd_SQL3.Parameters.AddWithValue("@Id", id);
            cmd_SQL3.Parameters.AddWithValue("@BeerId", elements[0]);
            cmd_SQL3.Parameters.AddWithValue("@Water", elements[5]);
            cmd_SQL3.Parameters.AddWithValue("@Sugar", elements[6]);
            cmd_SQL3.Parameters.AddWithValue("@Hop", elements[7]);
            cmd_SQL3.Parameters.AddWithValue("@Malt", elements[8]);

            try
            {
                connect.Open();
                cmd_SQL1.ExecuteNonQuery();
                cmd_SQL2.ExecuteNonQuery();
                cmd_SQL3.ExecuteNonQuery();
            }

            finally
            {
                connect.Close();
            }
        }
    }
}

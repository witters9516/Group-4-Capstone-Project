using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace concept_0_03
{
    class FillQuestionsListClass
    {
        
        int count;

        SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
        SqlDataReader reader;
        SqlCommand cmd = new SqlCommand();

        public FillQuestionsListClass()
        {
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }
    }
}
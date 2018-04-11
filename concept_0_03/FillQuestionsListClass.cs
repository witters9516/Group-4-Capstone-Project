using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace concept_0_03
{
    class FillQuestionsListClass
    {
        //Text files to be tokenized to create in game questions.
        const string HIRAGANA_A = "Hiragana_a.txt"; //Txt File for letters using a.
        const string HIRAGANA_E = "Hiragana_e.txt"; //Txt File for letters using e.
        const string HIRAGANA_I = "Hiragana_i.txt"; //Txt File for letters using i.
        const string HIRAGANA_O = "Hiragana_o.txt"; //Txt File for letters using o.
        const string HIRAGANA_U = "Hiragana_u.txt"; //Txt File for letters using u.



        //Global Variables
        List<LetterClass> LetterQuestionList = new List<LetterClass>();


        

        public FillQuestionsListClass()
        {
            #region Using database connection
            ////do this with an ODBC connection string instead.
            ////Object wrapper does low level stuff for you
            ////
            //SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS;Database=QuestionDatabase");

            ////Open the connection
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM [Hiragana]");
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.WriteLine(reader[i].ToString());
            //    }
            //}
            //con.Close();
            #endregion

            //Using Text files.
            StreamReader reader = File.OpenText(HIRAGANA_A);

            char[] delim = {','};
            string[] token = new string[16];


            while (!reader.EndOfStream)
            {
                string temp = reader.ReadLine().ToString();
                token = temp.Split(delim);

                LetterClass tempLetter = CreateLetterObject(token);
                LetterQuestionList.Add(tempLetter);
            }
        }

        private LetterClass CreateLetterObject(string[] array)
        {
            return new LetterClass(array[1], array[2], array[3], array[4], array[5], array[6], array[7],
                array[8], array[9], array[10], array[11], array[12], array[13], array[14], array[15]);
        }
    }
}
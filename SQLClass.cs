using MySql.Data.MySqlClient;
using System;
using System.Data;

/* SQLQuery é usada para realizar busca (Select). Essa função retorna uma tabela (DataTable)
 * SQLCommand é usada para realizar Insert, Update e Delete*/

namespace ReferenciaArtigo
{
    internal class SQLClass
    {
        public string stringConn;
        public MySqlConnection connDB;

        public SQLClass()
        {
            try
            {
                stringConn = ""; /* Insera a string de conexão do seu banco de dados*/ 
                connDB = new MySqlConnection(stringConn);
                connDB.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new MySqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;

                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public void SQLCommand(string SQL)
        {
            try
            {
                MySqlCommand myCommand = new MySqlCommand(SQL, connDB)
                {
                    CommandTimeout = 0
                };

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

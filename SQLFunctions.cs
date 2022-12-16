using System.Data;

/*  
    CREATE TABLE `ToDoList` (
	    `Texto` char(64),
	    `Status` char(10)
    ) 
*/

/* Exmplo de tabela Utilizada (Tabela simplificada) */

namespace ReferenciaArtigo
{
    internal class SQLFunctions
    {
        private readonly SQLClass db;

        public SQLFunctions()
        {
            db = new SQLClass();
        }
        public void Insere(string Texto, string Status)
        {
            string insert = $"INSERT INTO ToDoList (Texto, Status) VALUES ('{Texto}', '{Status}')";
            db.SQLCommand(insert);
        }
        public DataTable Buscar(string Status)
        {
            string busca = $"SELECT (Texto) FROM ToDoList WHERE Status = '{Status}'";
            DataTable dt = db.SQLQuery(busca);

            return dt;
        }
        public void Limpa()
        {
            string Deleta = "DELETE FROM ToDoList";
            db.SQLCommand(Deleta);
        }
    }
}
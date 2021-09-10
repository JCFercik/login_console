using System.Data;
using System.Data.SqlClient;

namespace Course
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        // Constutor
        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9BSJQQJ\SQLEXPRESS;Initial Catalog=AppTelNet;Integrated Security=True";
        }
        // Método conectar
        public SqlConnection Conectar()
        {
            // Validando se existe uma conexão aberta
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        // Método desconectar
        public void Desconectar()
        {
            // Validando se esta desconectado
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

using System.Data;
using System.Data.SqlClient;

namespace Course
{
    public class Usuario
    {
        Conexao conexao = new Conexao(); //instanciando uma conexão (obj da classe Conexao)
        SqlCommand cmd = new SqlCommand(); //instanciando um comando (obj da classe SqlCommand)
        SqlDataReader dr; //armazenar a resposta do banco
        public bool tem = false;
        public string mensagem = "";

        //Construtores
        public Usuario() { }
        public Usuario(string nomeUsuario, string userName, string senhaUsuario)
        {
            //comando sql -- SqlCommand
            cmd.CommandText = "insert into usuarios (NomeUsuario, UserName, SenhaUsuario) values (@nomeUsuario, @userName, @senhaUsuario)";

            //parametros
            cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@senhaUsuario", senhaUsuario);

            try
            {
                //conectar com o banco -- conexao(obj)
                cmd.Connection = conexao.Conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Desconectar();
                //mostrar msg de erro ou sucesso
                mensagem = "Cadastrado com sucesso!!!";
            }
            catch (SqlException)
            {
                mensagem = "Erro ao conectar com banco de dados";
            }
        }

        public bool VerifcarLogin(string login, string senha)
        { //procurar no banco login e senha
            cmd.CommandText = "select * from usuarios where UserName=@login and SenhaUsuario=@senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = conexao.Conectar();
                dr = cmd.ExecuteReader(); //ler e capturar dados
                if (dr.HasRows) //tem linhas
                {
                    tem = true;                
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return tem;
        }
    }
}

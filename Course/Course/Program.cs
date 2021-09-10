using System;
using System.Windows.Forms;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** LOGIN **********\n");
            Console.WriteLine("USUÁRIO");
            string usuarioT = Console.ReadLine();
            Console.WriteLine("SENHA");
            string senhaT = Console.ReadLine();

            Usuario login = new Usuario();
            login.VerifcarLogin(usuarioT, senhaT);

            if (login.mensagem.Equals(""))
            {
                if (login.tem)
                {
                    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.Clear();

                    Console.WriteLine("Breve mais cód...");
                    Console.WriteLine();
                }
                else
                {
                    MessageBox.Show("Login não encontrado", "Erro ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(login.mensagem);
            }

            Console.Write("Deseja fazer um novo cadastro [s/n]? ");
            char resp = char.Parse(Console.ReadLine());

            if (resp != 's' || resp != 'S')
            {
                Console.WriteLine();
                Console.WriteLine("Cadastro finalizado com sucesso\n");
            }
            else
            {
                Usuario user = new Usuario();
            
                Console.WriteLine("*** CADASTRO DE USUÁRIOS ***\n");
                Console.WriteLine("Digite seu nome");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite um nome de usuário");
                string usuario = Console.ReadLine();
                Console.WriteLine("Digite uma senha");
                string senha = Console.ReadLine();

                user = new Usuario(nome, usuario, senha);
                MessageBox.Show(user.mensagem);

                Console.Write("Deseja fazer outro cadastro [s/n]? ");
                char res = char.Parse(Console.ReadLine());

                if(res != 's' || res != 'S')
                {
                    Console.WriteLine();
                    Console.WriteLine("Cadastro finalizado com sucesso\n");
                }

                while(res == 's' || res == 'S')
                {
                    Console.WriteLine();
                    Console.WriteLine("*** CADASTRO DE USUÁRIOS ***\n");
                    Console.WriteLine("Digite seu nome");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite um nome de usuário");
                    usuario = Console.ReadLine();
                    Console.WriteLine("Digite uma senha");
                    senha = Console.ReadLine();

                    user = new Usuario(nome, usuario, senha);
                    MessageBox.Show(user.mensagem);

                    Console.Write("Deseja fazer um novo cadastro [s/n]? ");
                    res = char.Parse(Console.ReadLine());

                    if (res != 's' || res != 'S')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cadastro finalizado com sucesso\n");
                    }
                }
            }
            Console.Clear();
        }
    }
}

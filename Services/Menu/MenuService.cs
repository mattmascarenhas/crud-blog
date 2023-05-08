using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Services.Menu {
    public class MenuService {

        public static void Menu(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Vincular");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Deletar");
            Console.WriteLine("5- Exibir");
            Console.WriteLine("0- Sair");

            option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    RegisterMenu.Register(_connection);
                    break;
                case 2:
                    LinkMenu.Link(_connection);
                    break;
                case 3:
                    UpdateMenu.Update(_connection);
                    break;
                case 4:
                    RemoveMenu.Remove(_connection);
                    break;
                case 5:
                    ShowTableMenu.Show(_connection);
                    break;
                case 0:
                    System.Environment.Exit(0);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Menu(_connection);
                }
                break;
            }
        }
    }
}

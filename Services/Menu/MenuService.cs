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
                    RegisterMenu(_connection);
                    break;
                case 2:
                    LinkMenu(_connection);
                    break;
                case 3:
                    UpdateMenu(_connection);
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

        public static void RegisterMenu(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Cadastrar um usuário");
            Console.WriteLine("2- Cadastrar um perfil");
            Console.WriteLine("3- Cadastrar uma Categoria");
            Console.WriteLine("4- Cadastrar uma Tag");
            Console.WriteLine("5- Cadastrar um post");
            Console.WriteLine("0- Voltar ao menu inicial");

            option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    CreateService.CreateUser(_connection);
                    break;
                case 2:
                    CreateService.CreateRole(_connection);
                    break;
                case 3:
                    CreateService.CreateCategory(_connection);
                    break;
                case 4:
                    CreateService.CreateTag(_connection);
                    break;
                case 5:
                    CreateService.CreatePost(_connection);
                    break;
                case 0:
                    Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    RegisterMenu(_connection);
                }
                break;
            }
        }

        public static void UpdateMenu(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Atualizar um usuário");
            Console.WriteLine("2- Atualizar um perfil");
            Console.WriteLine("3- Atualizar uma Categoria");
            Console.WriteLine("4- Atualizar uma Tag");
            Console.WriteLine("5- Atualizar um post");
            Console.WriteLine("0- Voltar ao menu inicial");

            option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    CreateService.CreateUser(_connection);
                    break;
                case 2:
                    CreateService.CreateRole(_connection);
                    break;
                case 3:
                    CreateService.CreateCategory(_connection);
                    break;
                case 4:
                    CreateService.CreateTag(_connection);
                    break;
                case 5:
                    CreateService.CreatePost(_connection);
                    break;
                case 0:
                    Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    RegisterMenu(_connection);
                }
                break;
            }
        }

        public static void LinkMenu(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Vincular um usuário a um perfil");
            Console.WriteLine("2- Vincular um post a uma tag");
            Console.WriteLine("0- Sair");

            option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                   LinkService.LinkUserRole(_connection);
                    break;
                case 2:
                    LinkService.LinkPostTag(_connection);
                    break;
                case 0:
                    Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    LinkMenu(_connection);
                }
                break;
            }
        }

    }
}

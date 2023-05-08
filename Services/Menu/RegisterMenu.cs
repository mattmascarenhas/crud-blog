using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Menu {
    public class RegisterMenu {
        public static void Register(SqlConnection _connection) {
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
                    MenuService.Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Register(_connection);
                }
                break;
            }
        }

    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Menu {
    public class ShowTableMenu {
        public static void Show(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Exibir a tabela de usuário");
            Console.WriteLine("2- Exibir a tabela de perfil");
            Console.WriteLine("3- Exibir a tabela de Categoria");
            Console.WriteLine("4- Exibir a tabela de Tag");
            Console.WriteLine("5- Exibir a tabela de post");
            Console.WriteLine("0- Voltar ao menu inicial");

            option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1: {
                    ReadService.ReadUsers(_connection);
                    Console.ReadLine();
                    MenuService.Menu(_connection);
                }
                break;
                case 2: {
                    ReadService.ReadRoles(_connection);
                    Console.ReadLine();
                    MenuService.Menu(_connection);
                }
                break;
                case 3: {
                    ReadService.ReadUsers(_connection);
                    Console.ReadLine();
                    MenuService.Menu(_connection);
                }
                break;
                case 4: {
                    ReadService.ReadCategories(_connection);
                    Console.ReadLine();
                    MenuService.Menu(_connection);
                }
                break;
                case 5: {
                    ReadService.ReadPosts(_connection);
                    Console.ReadLine();
                    MenuService.Menu(_connection);
                }
                break;
                case 0:
                    MenuService.Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Show(_connection);
                }
                break;
            }


        }

    }
}

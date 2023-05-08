using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Menu {
    public class LinkMenu {
        public static void Link(SqlConnection _connection) {
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
                    MenuService.Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Link(_connection);
                }
                break;
            }
        }

    }
}

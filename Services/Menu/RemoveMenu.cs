using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Menu {
    public class RemoveMenu {
        public static void Remove(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Deletar um usuário");
            Console.WriteLine("2- Deletar um perfil");
            Console.WriteLine("3- Deletar uma Categoria");
            Console.WriteLine("4- Deletar uma Tag");
            Console.WriteLine("5- Deletar um post");
            //Console.WriteLine("6- Deletar um vinculo de usuário com um perfil");
            //Console.WriteLine("7- Deletar um vinculo de post com uma tag");
            Console.WriteLine("0- Voltar ao menu inicial");

            option = int.Parse(Console.ReadLine());


            switch (option) {
                case 1:
                    RemoveService.DeleteUser(_connection);
                    break;
                case 2:
                    RemoveService.DeleteUser(_connection);
                    break;
                case 3:
                    RemoveService.DeleteCategory(_connection);
                    break;
                case 4:
                    RemoveService.DeleteTag(_connection);
                    break;
                case 5:
                    RemoveService.DeletePost(_connection);
                    break;
                //case 6:
                //    RemoveService.DeleteUserRole(_connection);
                //    break;
                //case 7:
                //    break;
                case 0:
                    MenuService.Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Remove(_connection);
                }
                break;
            }
        }

    }
}

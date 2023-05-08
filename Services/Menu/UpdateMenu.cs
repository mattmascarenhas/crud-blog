using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Menu {
    public class UpdateMenu {
        public static void Update(SqlConnection _connection) {
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
                    UpdateService.UpdateUser(_connection);
                    break;
                case 2:
                    UpdateService.UpdateRole(_connection);
                    break;
                case 3:
                    UpdateService.UpdateCategory(_connection);
                    break;
                case 4:
                    UpdateService.UpdateTag(_connection);
                    break;
                case 5:
                    UpdateService.UpdatePost(_connection);
                    break;
                case 0:
                    MenuService.Menu(_connection);
                    break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Update(_connection);
                }
                break;
            }
        }

    }
}

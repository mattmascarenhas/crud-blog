using Blog.Models;
using Blog.Services.Menu;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Services {
    public class LinkService {
        public static void LinkUserRole(SqlConnection _connection) {
            Console.Clear();
            var userRole = new UserRole();
            Console.WriteLine("===== Vinculo de Usuário com Perfil =====");

            Console.WriteLine("");
            ReadService.ReadUsers(_connection);
            Console.WriteLine("");

            Console.Write("Id do usuário: ");
            userRole.UserId = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            ReadService.ReadRoles(_connection);
            Console.WriteLine("");

            Console.Write("Id do Perfil: ");
            userRole.RoleId = int.Parse(Console.ReadLine());

            using (_connection) {
                _connection.Insert<UserRole>(userRole);
                Console.WriteLine("Vinculo realizado com sucesso.");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void LinkPostTag(SqlConnection _connection) {
            Console.Clear();
            var postTag = new PostTag();
            Console.WriteLine("===== Vinculo de Post com Tag =====");

            Console.WriteLine("");
            ReadService.ReadPosts(_connection);
            Console.WriteLine("");

            Console.Write("Id do Post: ");
            postTag.PostId = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            ReadService.ReadTags(_connection);
            Console.WriteLine("");

            Console.Write("Id da Tag: ");
            postTag.TagId = int.Parse(Console.ReadLine());

            using (_connection) {
                _connection.Insert<PostTag>(postTag);
                Console.WriteLine("Vinculo realizado com sucesso.");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

    }
}

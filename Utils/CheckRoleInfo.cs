
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils {
    internal class CheckRoleInfo {
        public static void SlugCheck(SqlConnection _connection, Role role) {
            //verificar se ja existe o slug, o slug deve ser unico
            var repository = new Repository<Role>(_connection);
            var items = repository.GetAll();
            foreach (var item in items) {
                while (item.Slug == role.Slug) {
                    Console.WriteLine("O slug já existe, insira novamente");
                    Console.Write("Slug: ");
                    role.Slug = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }

        public static bool IdExistRole(SqlConnection _connection, int id) {
            //verificar se o Id existe
            var repository = new Repository<Role>(_connection);
            var items = repository.GetAll();
            return repository.GetAll().Any(item => item.Id == id);
        }
    }
}

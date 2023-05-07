using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils {
    public class CheckCategoryInfo {
        public static void SlugCheck(SqlConnection _connection, Category category) {
            //verificar se ja existe o slug, o slug deve ser unico
            var repository = new Repository<Category>(_connection);
            var items = repository.GetAll();
            foreach (var item in items) {
                while (item.Slug == category.Slug) {
                    Console.WriteLine("O slug já existe, insira novamente");
                    Console.Write("Slug: ");
                    category.Slug = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }

        public static bool IdExistCategory(SqlConnection _connection, int id) {
            //verificar se o Id existe
            var repository = new Repository<Category>(_connection);
            var items = repository.GetAll();
            return repository.GetAll().Any(item => item.Id == id);
        }
    }
}

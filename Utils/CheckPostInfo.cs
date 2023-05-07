using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Utils {
    internal class CheckPostInfo {
        public static void SlugCheck(SqlConnection _connection, Post post) {
            //verificar se ja existe o slug, o slug deve ser unico
            var repository = new Repository<Post>(_connection);
            var items = repository.GetAll();
            foreach (var item in items) {
                while (item.Slug == post.Slug) {
                    Console.WriteLine("O slug já existe, insira novamente");
                    Console.Write("Slug: ");
                    post.Slug = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }

        public static bool IdExistPost(SqlConnection _connection, int id) {
            //verificar se o Id existe
            var repository = new Repository<Post>(_connection);
            var items = repository.GetAll();
            return repository.GetAll().Any(item => item.Id == id);
        }
    }
}

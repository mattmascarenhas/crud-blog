using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Utils {
    public class CheckUserInfo {

        public static void SlugCheck(SqlConnection _connection, User user) {
            //verificar se ja existe o slug, o slug deve ser unico
            var repository = new UserRepository(_connection);
            var items = repository.GetWithRole();
            foreach (var item in items) {
                while (item.Slug == user.Slug) {
                    Console.WriteLine("O slug já existe, insira novamente");
                    Console.Write("Slug: ");
                    user.Slug = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }

        public static bool IdExistUser(SqlConnection _connection, int id) {
            //verificar se o Id existe
            var repository = new UserRepository(_connection);
            var items = repository.GetWithRole();
            return repository.GetWithRole().Any(item => item.Id == id);
        }


    }
}

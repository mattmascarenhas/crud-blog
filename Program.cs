using Blog.Models;
using Blog.Services.Menu;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog {
    internal class Program {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root;TrustServerCertificate=True";
        static void Main(string[] args) {
            var _connection = new SqlConnection(CONNECTION_STRING);
             MenuService.Menu(_connection);
        }


        //daqui pra baixo nao foi implementado 
        public static void ReadUser(int userId) {
            using (var connection = new SqlConnection()) {
                var user = connection.Get<User>(userId);
                Console.WriteLine(user.Name);
            }
        }

        public static void UpdateUser() {
            var user = new User() {
                Id= 2,
                Bio = "MVP ",
                Email = "hello@.com",
                Image = "https://....",
                Name = "io",
                PasswordHash = "HASH",
                Slug = "-io"
            };
            using (var connection = new SqlConnection()) {
                connection.Update<User>(user);
                Console.WriteLine($"{user.Name} foi atualizado");
            }
        }

        public static void DeleteUser() {
            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine($"Exclusão realizada com sucesso");
            }
        }  
    }
}
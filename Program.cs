using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog {
    internal class Program {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root;TrustServerCertificate=True";
        static void Main(string[] args) {
            var connnection = new SqlConnection(CONNECTION_STRING);
            connnection.Open();
            ReadUsers(connnection);
            //ReadRoles(connnection);
            //ReadTags(connnection);
            //ReadUser(1);
            CreateUser();
            //UpdateUser();
            //DeleteUser();
            connnection.Close();

        }
        public static void ReadUsers(SqlConnection connection) {
            var repository = new UserRepository(connection);
            var users = repository.GetWithRole();

            foreach (var user in users) {
                Console.WriteLine(user.Name);
                foreach (var role in user.Roles) {
                    Console.WriteLine($" - {role.Name}");

                }
            }
        }

        public static void ReadUser(int userId) {
            using (var connection = new SqlConnection()) {
                var user = connection.Get<User>(userId);
                Console.WriteLine(user.Name);
            }
        }

        public static void ReadRoles(SqlConnection connection) {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();

            foreach (var role in roles) {
                Console.WriteLine(role.Name);
            }
        }

        public static void ReadTags(SqlConnection connection) {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            foreach (var tag in tags) {
                Console.WriteLine(tag.Name);
            }
        }



        public static void CreateUser() {
            var user = new User() {
                Bio = "MVP Microsoft 2",
                Email= "hello@baltario.com 2",
                Image= "https://.... 2",
                Name= "Batario io 2",
                PasswordHash = "HASH 2",
                Slug = "baltario-io-2"
            };
            using (var connection = new SqlConnection()) {
                connection.Insert<User>(user);
                Console.WriteLine($"Cadastro do {user.Name} finalizado");
            }
        }

        public static void UpdateUser() {
            var user = new User() {
                Id= 2,
                Bio = "233X MVP Microsoft",
                Email = "hello@baltario.com",
                Image = "https://....",
                Name = "Balta.io",
                PasswordHash = "HASH",
                Slug = "baltario-io"
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
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


namespace Blog.Services {
    public class ReadService {

        public static void ReadUsers(SqlConnection connection) {
            var repository = new UserRepository(connection);
            var users = repository.GetWithRole();

            Console.WriteLine("===== Usuários / Perfil Vinculado =====");
            foreach (var user in users) {
                Console.Write($"{user.Id} - {user.Name} / ");
                foreach (var role in user.Roles) {
                    Console.WriteLine($"{role.Name}");
                }
            }
        }

        public static void ReadRoles(SqlConnection _connection) {
            var repository = new Repository<Role>(_connection);
            var roles = repository.GetAll();

            Console.WriteLine("======== Perfis ========");
            foreach (var role in roles) {
                Console.WriteLine($"{role.Id} - {role.Name}");
            }
        }

        public static void ReadTags(SqlConnection connection) {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            Console.WriteLine("======== Tags ========");
            foreach (var tag in tags) {
                Console.WriteLine($"{tag.Id} - {tag.Name}");
            }
        }

        public static void ReadPosts(SqlConnection connection) {
            var repository = new Repository<Post>(connection);
            var posts = repository.GetAll();

            Console.WriteLine("======== Posts ========");
            foreach (var post in posts) {
                Console.WriteLine($"{post.Id} - {post.Title}");
            }
        }


    }
}

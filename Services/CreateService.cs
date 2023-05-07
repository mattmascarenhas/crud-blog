
using Blog.Models;
using Blog.Repositories;
using Blog.Services.Menu;
using Blog.Utils;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Services {
    public class CreateService {

        public static void CreateUser(SqlConnection _connection) {
            Console.Clear();
            var user = new User();
            Console.WriteLine("===== Cadastro de usuário =====");
            Console.Write("Nome: ");
            user.Name = Console.ReadLine();
            Console.Write("Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Senha: ");
            user.PasswordHash = Console.ReadLine();
            Console.Write("Bio: ");
            user.Bio = Console.ReadLine();
            Console.Write("Url da Imagem: ");
            user.Image = Console.ReadLine();
            Console.Write("Slug: ");
            user.Slug = Console.ReadLine();
            Console.WriteLine("");
            //verificar se o slug é repetido
            CheckUserInfo.SlugCheck(_connection, user);

            using (_connection) {
                _connection.Insert<User>(user);
                Console.WriteLine($"Cadastro do {user.Name} finalizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void CreateRole(SqlConnection _connection) {
            Console.Clear();
            var role = new Role();
            Console.WriteLine("===== Cadastro de perfil =====");
            Console.Write("Nome: ");
            role.Name = Console.ReadLine();
            Console.Write("Slug: ");
            role.Slug = Console.ReadLine();
            Console.WriteLine("");

            using (_connection) {
                _connection.Insert<Role>(role);
                Console.WriteLine($"Cadastro do perfil {role.Name} finalizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void CreateCategory(SqlConnection _connection) {
            Console.Clear();
            var category = new Category();
            Console.WriteLine("===== Cadastro de categoria =====");
            Console.Write("Nome: ");
            category.Name = Console.ReadLine();
            Console.Write("Slug: ");
            category.Slug = Console.ReadLine();
            Console.WriteLine("");

            using (_connection) {
                _connection.Insert<Category>(category);
                Console.WriteLine($"Cadastro da categoria {category.Name} finalizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void CreateTag(SqlConnection _connection) {
            Console.Clear();
            var tag = new Tag();
            Console.WriteLine("===== Cadastro de tag =====");
            Console.Write("Nome: ");
            tag.Name = Console.ReadLine();
            Console.Write("Slug: ");
            tag.Slug = Console.ReadLine();
            Console.WriteLine("");

            using (_connection) {
                _connection.Insert<Tag>(tag);
                Console.WriteLine($"Cadastro da tag {tag.Name} finalizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void CreatePost(SqlConnection _connection) {
            Console.Clear();
            var post = new Post();
            Console.WriteLine("===== Cadastro de post =====");
            Console.Write("Id do Autor do post: ");
            post.AuthorId = int.Parse(Console.ReadLine());
            Console.Write("Id da Categoria: ");
            post.CategoryId = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            post.Title = Console.ReadLine();
            Console.Write("Texto: ");
            post.Body = Console.ReadLine();
            Console.Write("Sumário: ");
            post.Summary = Console.ReadLine();
            Console.Write("Slug: ");
            post.Slug = Console.ReadLine();
            post.CreateDate = DateTime.Now;
            post.LastUpdateDate = DateTime.Now;
            Console.WriteLine("");

            using (_connection) {
                var author = _connection.Get<User>(post.AuthorId);
                var category = _connection.Get<Category>(post.CategoryId);
                if (author == null && category == null) {
                    Console.WriteLine("Autor e categoria inválidos");
                    Console.ReadLine();
                     MenuService.Menu(_connection);
                }
                if (author == null) {
                    Console.WriteLine("Autor inválido");
                    Console.ReadLine();
                     MenuService.Menu(_connection);
                }
                if (category == null) {
                    Console.WriteLine("Categoria inválida");
                    Console.ReadLine();
                     MenuService.Menu(_connection);
                } else {
                    _connection.Insert<Post>(post);
                    Console.WriteLine($"Cadastro do Post {post.Title} finalizado");
                }
            }
            Console.ReadLine();
             MenuService.Menu(_connection);
        }
    }
}

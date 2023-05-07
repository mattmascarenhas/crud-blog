using Blog.Models;
using Blog.Services.Menu;
using Blog.Utils;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Services {
    public class UpdateService {
        public static void UpdateUser(SqlConnection _connection) {
            Console.Clear();
            var user = new User();
            Console.WriteLine("===== Atualização de usuário =====");
            Console.Write("Id do usuario que deseja atualizar: ");
            user.Id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckUserInfo.IdExistUser(_connection, user.Id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Id do usuario que deseja atualizar: ");
                user.Id = int.Parse(Console.ReadLine());
            }

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
            CheckUserInfo.SlugCheck(_connection, user);

            using (_connection) {
                _connection.Update<User>(user);
                Console.WriteLine($"{user.Name} foi atualizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void UpdateTag(SqlConnection _connection) {
            Console.Clear();
            var tag = new Tag();
            Console.WriteLine("===== Atualização de Tag =====");
            Console.Write("Id da tag que deseja atualizar: ");
            tag.Id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckTagInfo.IdExistTag(_connection, tag.Id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Id da tag que deseja atualizar: ");
                tag.Id = int.Parse(Console.ReadLine());
            }

            Console.Write("Nome: ");
            tag.Name = Console.ReadLine();
            Console.Write("Slug: ");
            tag.Slug = Console.ReadLine();
            Console.WriteLine("");
            CheckTagInfo.SlugCheck(_connection, tag);

            using (_connection) {
                _connection.Update<Tag>(tag);
                Console.WriteLine($"{tag.Name} foi atualizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void UpdateRole(SqlConnection _connection) {
            Console.Clear();
            var role = new Role();
            Console.WriteLine("===== Atualização de Perfil =====");
            Console.Write("Id do perfil que deseja atualizar: ");
            role.Id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckRoleInfo.IdExistRole(_connection, role.Id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Id do perfil que deseja atualizar: ");
                role.Id = int.Parse(Console.ReadLine());
            }

            Console.Write("Nome: ");
            role.Name = Console.ReadLine();
            Console.Write("Slug: ");
            role.Slug = Console.ReadLine();
            Console.WriteLine("");
            CheckRoleInfo.SlugCheck(_connection, role);

            using (_connection) {
                _connection.Update<Role>(role);
                Console.WriteLine($"{role.Name} foi atualizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void UpdateCategory(SqlConnection _connection) {
            Console.Clear();
            var category = new Category();
            Console.WriteLine("===== Atualização de Categoria =====");
            Console.Write("Id da categoria que deseja atualizar: ");
            category.Id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckCategoryInfo.IdExistCategory(_connection, category.Id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Id da categoria que deseja atualizar: ");
                category.Id = int.Parse(Console.ReadLine());
            }

            Console.Write("Nome: ");
            category.Name = Console.ReadLine();
            Console.Write("Slug: ");
            category.Slug = Console.ReadLine();
            Console.WriteLine("");
            CheckCategoryInfo.SlugCheck(_connection, category);

            using (_connection) {
                _connection.Update<Category>(category);
                Console.WriteLine($"{category.Name} foi atualizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

        public static void UpdatePost(SqlConnection _connection) {
            Console.Clear();
            var post = new Post();
            Console.WriteLine("===== Atualização de Post =====");
            Console.Write("Id do Post que deseja atualizar: ");
            post.Id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckPostInfo.IdExistPost(_connection, post.Id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Id do Post que deseja atualizar: ");
                post.Id = int.Parse(Console.ReadLine());
            }

            Console.Write("Id do Autor do post: ");
            post.AuthorId = int.Parse(Console.ReadLine());
            Console.Write("Id da categoria: ");
            post.CategoryId = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            post.Title = Console.ReadLine();
            Console.Write("Texto: ");
            post.Body = Console.ReadLine();
            Console.Write("Sumário: ");
            post.Summary = Console.ReadLine();
            Console.Write("Slug: ");
            post.Slug = Console.ReadLine();
            post.LastUpdateDate = DateTime.Now;
            post.CreateDate = DateTime.Now;

            Console.WriteLine("");
            CheckPostInfo.SlugCheck(_connection, post);

            using (_connection) {
                _connection.Update<Post>(post);
                Console.WriteLine($"{post.Title} foi atualizado");
            }
            Console.ReadLine();
            MenuService.Menu(_connection);
        }

    }
}

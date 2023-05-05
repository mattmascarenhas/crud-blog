using Azure;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog {
    internal class Program {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root;TrustServerCertificate=True";
        static void Main(string[] args) {
            var _connection = new SqlConnection(CONNECTION_STRING);
            Menu(_connection);
            //ReadUsers(_connection);
            //ReadRoles(_connection);
            //ReadTags(_connection);
            //ReadUser(1);
            //CreateUser();
            //UpdateUser();
            //DeleteUser();

        }

        public static void Menu(SqlConnection _connection) {
            Console.Clear();
            int option;
            Console.WriteLine("Bem-vindo ao banco de dados do BLOG!");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("1- Cadastrar um usuário");
            Console.WriteLine("2- Cadastrar um perfil");
            Console.WriteLine("3- Cadastrar uma Categoria");
            Console.WriteLine("4- Cadastrar uma Tag");
            Console.WriteLine("5- Cadastrar um post");
            Console.WriteLine("6- Vincular um usuário a um perfil");
            Console.WriteLine("7- Vincular um post a uma tag");
            Console.WriteLine("0- Sair");

            option =  int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    CreateUser(_connection); break;
                case 2:
                    CreateRole(_connection); break;
                case 3:
                    CreateCategory(_connection); break;
                case 4:
                    CreateTag(_connection); break;
                case 5: 
                    CreatePost(_connection) ; break;
                case 6: 
                    CreateUserRole(_connection) ; break;
                case 7: ; break;
                case 0:
                    System.Environment.Exit(0); break;
                default: {
                    Console.WriteLine("Digite uma opcão válida");
                    Console.ReadLine();
                    Console.Clear();
                    Menu(_connection);
                } break;
            }
        }

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

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Insert<User>(user);
                Console.WriteLine($"Cadastro do {user.Name} finalizado");
            }
            Console.ReadLine();
            Menu(_connection);
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

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Insert<Role>(role);
                Console.WriteLine($"Cadastro do perfil {role.Name} finalizado");
            }
            Console.ReadLine();
            Menu(_connection);
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

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Insert<Category>(category);
                Console.WriteLine($"Cadastro da categoria {category.Name} finalizado");
            }
            Console.ReadLine();
            Menu(_connection);
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

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Insert<Tag>(tag);
                Console.WriteLine($"Cadastro da tag {tag.Name} finalizado");
            }
            Console.ReadLine();
            Menu(_connection);
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

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                var author = connection.Get<User>(post.AuthorId);
                var category = connection.Get<Category>(post.CategoryId);
                if (author == null && category == null) {
                    Console.WriteLine("Autor e categoria inválidos");
                    Console.ReadLine();
                    Menu(_connection);
                } if (author == null) {
                    Console.WriteLine("Autor inválido");
                    Console.ReadLine();
                    Menu(_connection);
                } if (category == null){
                    Console.WriteLine("Categoria inválida");
                    Console.ReadLine();
                    Menu(_connection);
                } else {
                    connection.Insert<Post>(post);
                    Console.WriteLine($"Cadastro do Post {post.Title} finalizado");
                }
            }
            Console.ReadLine();
            Menu(_connection);
        }

        public static void CreateUserRole(SqlConnection _connection) {
            Console.Clear();
            var userRole = new UserRole();
            Console.WriteLine("===== Vinculo de Usuário com Perfil =====");

            Console.WriteLine("");
            ReadUsers(_connection);
            Console.WriteLine("");

            Console.Write("Id do usuário: ");
            userRole.UserId = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            ReadRoles(_connection);
            Console.WriteLine("");

            Console.Write("Id do Perfil: ");
            userRole.RoleId = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Insert<UserRole>(userRole);
                Console.WriteLine("Vinculo realizado com sucesso.");
            }
            Console.ReadLine();
            Menu(_connection);
        }

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


        public static void ReadUser(int userId) {
            using (var connection = new SqlConnection()) {
                var user = connection.Get<User>(userId);
                Console.WriteLine(user.Name);
            }
        }


        public static void ReadTags(SqlConnection connection) {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            foreach (var tag in tags) {
                Console.WriteLine(tag.Name);
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
using Blog.Models;
using Blog.Services.Menu;
using Blog.Utils;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Blog.Services {
    public class RemoveService {
        public static void Delete<TModel>(SqlConnection connection, int id) where TModel: class{
            using (connection) {
                var user = connection.Get<TModel>(id);
                connection.Delete<TModel>(user);
                Console.WriteLine($"Exclusão realizada com sucesso");
            }
        }

        public static void DeleteUser(SqlConnection connection) {
            Console.Clear();
            Console.WriteLine("===== Remoção de usuário =====");
            Console.Write("Insira o Id do usuário que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckUserInfo.IdExistUser(connection, id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Insira o Id do usuário que deseja remover ");
                id = int.Parse(Console.ReadLine());
            }

            Delete<User>(connection, id);
            Console.ReadLine();
            Console.Clear();
            MenuService.Menu(connection);
        }

        public static void DeletePost(SqlConnection connection) {
            Console.Clear();
            Console.WriteLine("===== Remoção de post =====");
            Console.Write("Insira o Id do post que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckPostInfo.IdExistPost(connection, id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Insira o Id do post que deseja remover ");
                id = int.Parse(Console.ReadLine());
            }

            Delete<Post>(connection, id);
            Console.ReadLine();
            Console.Clear();
            MenuService.Menu(connection);
        }

        public static void DeleteRole(SqlConnection connection) {
            Console.Clear();
            Console.WriteLine("===== Remoção de perfil =====");
            Console.Write("Insira o Id do perfil que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckRoleInfo.IdExistRole(connection, id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Insira o Id do perfil que deseja remover ");
                id = int.Parse(Console.ReadLine());
            }

            Delete<Role>(connection, id);
            Console.ReadLine();
            Console.Clear();
            MenuService.Menu(connection);
        }

        public static void DeleteTag(SqlConnection connection) {
            Console.Clear();
            Console.WriteLine("===== Remoção de tag =====");
            Console.Write("Insira o Id do tag que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckRoleInfo.IdExistRole(connection, id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Insira o Id do tag que deseja remover ");
                id = int.Parse(Console.ReadLine());
            }

            Delete<Tag>(connection, id);
            Console.ReadLine();
            Console.Clear();
            MenuService.Menu(connection);
        }

        public static void DeleteCategory(SqlConnection connection) {
            Console.Clear();
            Console.WriteLine("===== Remoção de categoria =====");
            Console.Write("Insira o Id do categoria que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            //verifica se o Id existe
            while (!CheckRoleInfo.IdExistRole(connection, id)) {
                Console.WriteLine("O Id não existe, digite um Id valido.");
                Console.Write("Insira o Id do categoria que deseja remover ");
                id = int.Parse(Console.ReadLine());
            }

            Delete<Category>(connection, id);
            Console.ReadLine();
            Console.Clear();
            MenuService.Menu(connection);
        }

        //public static void DeleteUserRole(SqlConnection connection) {
        //    Console.Clear();
        //    int userId;
        //    int roleId;
        //    Console.WriteLine("===== Remoção da Associação de usuario com perfil =====");
        //    Console.Write("Insira o Id do usuário que deseja remover: ");
        //    userId = int.Parse(Console.ReadLine());
        //    Console.Write("Insira o Id do perfil que deseja remover: ");
        //    roleId = int.Parse(Console.ReadLine());

        //    //verifica se o Id existe
        //    while (!CheckUserInfo.IdExistUserRole(connection, userId, roleId)) {
        //        Console.WriteLine("A associação não existe, digite um conjunto de Id válido.");
        //        Console.Write("Insira o Id do categoria que deseja remover ");
        //        Console.Write("Insira o Id do usuário que deseja remover: ");
        //        userId = int.Parse(Console.ReadLine());
        //        Console.Write("Insira o Id do perfil que deseja remover: ");
        //        roleId = int.Parse(Console.ReadLine());
        //    }


        //    using (connection) {
        //        connection.Open();
        //        var sql = "DELETE FROM [UserRole] WHERE UserId = @userId AND RoleId = @roleId";
        //        var command = new SqlCommand(sql, connection);

        //        // Defina os valores dos parâmetros userId e roleId
        //        command.Parameters.AddWithValue("@userId", userId);
        //        command.Parameters.AddWithValue("@roleId", roleId);

        //        command.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //}

    }
}

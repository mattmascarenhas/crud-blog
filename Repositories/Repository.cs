using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories {
    //repositorio generico, onde o TModel é restrito apenas as classes
    public class Repository<TModel> where TModel: class {
        private readonly SqlConnection _connection;

        //construtor
        public Repository(SqlConnection connection) =>
            _connection = connection;

        //CRUD 
        public IEnumerable<TModel> GetAll() {
            return _connection.GetAll<TModel>();
        }

        public TModel Get(int id) =>
            _connection.Get<TModel>(id);

        public void Create(TModel model) => 
            _connection.Insert<TModel>(model);
        
        public void Update(TModel model) =>
                _connection.Update<TModel>(model);
        

        public void Delete(TModel model) =>
                _connection.Delete<TModel>(model);
        
        public void Delete(int id) {
            var model = _connection.Get<TModel>(id); //se receber id, captura o usuario
            _connection.Delete<TModel>(model);
        }
    }
}

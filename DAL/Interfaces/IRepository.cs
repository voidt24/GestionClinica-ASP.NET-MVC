using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public Task Create(string query, SqlParameter[] parameters);

        public Task<List<T>> GetAll(string query);

        public Task<T> GetById(string tableName, int id);

        public Task Update(string query, T entity);

        public Task DeleteById(string tableName, int id);
    }
}

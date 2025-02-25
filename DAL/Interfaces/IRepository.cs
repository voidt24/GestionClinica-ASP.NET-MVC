using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public void Create(string query, T entity);

        public List<T> GetAll(string query);

        public T GetById(string tableName, int id);

        public void Update(string query, T entity);

        public string DeleteById(string tableName, int id);
    }
}

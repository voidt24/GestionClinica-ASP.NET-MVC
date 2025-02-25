using DAL.Interfaces;
using Microsoft.Data.SqlClient;
namespace DAL.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private string _connectionString;
        public GenericRepository(string connectionString)
        {

            _connectionString = connectionString;
           
        }
        public void Create(T entity)
        {
        }

        public List<T> GetAll(string query)
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear una nueva instancia de T
                            T entity = Activator.CreateInstance<T>();

                            // Recorrer todas las columnas del reader
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // Obtener el nombre de la columna
                                var columnName = reader.GetName(i);

                                // Obtener el valor de la columna
                                object value = reader.GetValue(i);

                                // Usar reflexión para asignar el valor a la propiedad correspondiente de T
                                var property = typeof(T).GetProperty(columnName);
                                if (property != null && value != DBNull.Value)
                                {
                                    property.SetValue(entity, value);
                                }
                            }

                            list.Add(entity);
                        }
                    }
                }
            }

            return list;
        }


        public T GetById(int id)
        {
            return null;
        }

        public void Update(T entity){ }

        public string DeleteById(int id)
        {
            return "s";
        }

    }
}

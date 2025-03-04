using System.ComponentModel.DataAnnotations;
using System.Data;
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

        internal SqlParameter[] GetSqlParametersFromEntity(T entity)
        {
            var properties = typeof(T).GetProperties();
            var parameters = new List<SqlParameter>();

            foreach (var property in properties)
            {
                // Ignorar propiedades que no tienen el atributo Key
                if (property.GetCustomAttributes(typeof(KeyAttribute), false).Any())
                {
                    continue;
                }

                // Obtener el nombre de la propiedad y su valor
                var value = property.GetValue(entity);
                if (value == null)
                {
                    value = DBNull.Value; // Asegúrate de usar DBNull.Value si es null
                }

                var paramName = $"@{property.Name}"; // Nombre del parámetro

                // Verificar si el parámetro ya está configurado correctamente
                var parameter = new SqlParameter(paramName, value);
                parameters.Add(parameter);
            }

            return parameters.ToArray();
        }

        public async Task Create(string query, SqlParameter[] parameters)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }

            }
        }


        public async Task<List<T>> GetAll(string query)
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
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


        public async Task<T> GetById(string tableName, int id)
        {
            return null;
        }

        public async Task Update(string query, T entity) { }

        public async Task DeleteById(string tableName, int id)
        {

        }

    }
}

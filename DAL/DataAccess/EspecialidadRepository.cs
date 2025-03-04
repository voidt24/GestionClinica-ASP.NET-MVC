

using Microsoft.Data.SqlClient;

namespace DAL.DataAccess
{
    public class EspecialidadRepository<T> : GenericRepository<T> where T : class
    {

        public EspecialidadRepository(string connectionString) : base(connectionString) { }


        public async Task<List<T>> GetEspecialidades()
        {
            return await GetAll("ObtenerEspecialidad");
        }



        public async Task AgregarEspecialidad(T entity)
        {
            SqlParameter[] parameters = GetSqlParametersFromEntity(entity);

            await Create("GuardarEspecialidad", parameters);

        }
    }
}

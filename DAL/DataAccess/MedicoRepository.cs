using Microsoft.Data.SqlClient;


namespace DAL.DataAccess
{
    public class MedicoRepository<T> : GenericRepository<T> where T : class
    {

        public MedicoRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task crearMedico(T entity)
        {
            SqlParameter[] parameters = GetSqlParametersFromEntity(entity);

            await Create("GuardarMedico", parameters);
        }
        public async Task<List<T>> GetMedicos()
        {
            return await GetAll("ObtenerMedicos");
        }

    }
}

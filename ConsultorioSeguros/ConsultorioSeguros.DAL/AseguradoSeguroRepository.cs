using System.Data;
using System.Data.SqlClient;
using ConsultorioSeguros.Entities;

namespace ConsultorioSeguros.DAL
{
    public class AseguradoSeguroRepository : IAseguradoSeguroRepository
    {
        private readonly DatabaseContext _dbContext;

        public AseguradoSeguroRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AssignSeguroToAsegurado(string cedula, string segurosConcatenados)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("AssignSeguroToAsegurado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AseguradoCedula", cedula);
                    command.Parameters.AddWithValue("@SeguroCodigos", segurosConcatenados);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Seguro>> GetSegurosByAseguradoCedula(string cedula)
        {
            List<Seguro> seguros = new List<Seguro>();

            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("GetSegurosByAseguradoCedula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cedula", cedula);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            seguros.Add(new Seguro
                            {
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                SumaAsegurada = (decimal)reader["SumaAsegurada"],
                                Prima = (decimal)reader["Prima"]
                            });
                        }
                    }
                }
            }

            return seguros;
        }

        public async Task<List<Asegurado>> GetAseguradosBySeguroCodigo(string codigo)
        {
            List<Asegurado> asegurados = new List<Asegurado>();

            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("GetAseguradosBySeguroCodigo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            asegurados.Add(new Asegurado
                            {
                                Id = (int)reader["Id"],
                                Cedula = reader["Cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Edad = (int)reader["Edad"]
                            });
                        }
                    }
                }
            }

            return asegurados;
        }
    }
}
using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsultorioSeguros.DAL
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly DatabaseContext _dbContext;

        public SeguroRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Seguro>> GetAllSeguros()
        {
            List<Seguro> seguros = new List<Seguro>();
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAllSeguros", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            seguros.Add(new Seguro
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                SumaAsegurada = reader.GetDecimal(reader.GetOrdinal("SumaAsegurada")),
                                Prima = reader.GetDecimal(reader.GetOrdinal("Prima"))
                            });
                        }
                    }
                }
            }
            return seguros;
        }

        public async Task<Seguro> GetSeguroById(int id)
        {
            Seguro? seguro = null;
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetSeguroById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            seguro = new Seguro
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                SumaAsegurada = reader.GetDecimal(reader.GetOrdinal("SumaAsegurada")),
                                Prima = reader.GetDecimal(reader.GetOrdinal("Prima"))
                            };
                        }
                    }
                }
            }
            return seguro;
        }

        public async Task<Seguro> GetSeguroByCodigo(string codigo)
        {
            Seguro? seguro = null;
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetSeguroByCodigo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            seguro = new Seguro
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                SumaAsegurada = reader.GetDecimal(reader.GetOrdinal("SumaAsegurada")),
                                Prima = reader.GetDecimal(reader.GetOrdinal("Prima"))
                            };
                        }
                    }
                }
            }
            return seguro;
        }

        public async Task AddSeguro(Seguro seguro)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("InsertSeguro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", seguro.Nombre);
                    command.Parameters.AddWithValue("@Codigo", seguro.Codigo);
                    command.Parameters.AddWithValue("@SumaAsegurada", seguro.SumaAsegurada);
                    command.Parameters.AddWithValue("@Prima", seguro.Prima);
                    command.Parameters.AddWithValue("@CreatedBy", "AlexVergara");
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateSeguro(Seguro seguro)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("UpdateSeguro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", seguro.Id);
                    command.Parameters.AddWithValue("@Nombre", seguro.Nombre);
                    command.Parameters.AddWithValue("@Codigo", seguro.Codigo);
                    command.Parameters.AddWithValue("@SumaAsegurada", seguro.SumaAsegurada);
                    command.Parameters.AddWithValue("@Prima", seguro.Prima);
                    command.Parameters.AddWithValue("@UpdatedBy", "AlexVergara");
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteSeguro(int id)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("DeleteSeguro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DeletedBy", "AlexVergara");
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Seguro>> GetSegurosNoAsignadosPorAsegurado(string cedula)
        {
            List<Seguro> seguros = new List<Seguro>();
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetSegurosNoAsignados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cedula", cedula);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            seguros.Add(new Seguro
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                SumaAsegurada = reader.GetDecimal(reader.GetOrdinal("SumaAsegurada")),
                                Prima = reader.GetDecimal(reader.GetOrdinal("Prima"))
                            });
                        }
                    }
                }
            }
            return seguros;
        }

    }
}
using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsultorioSeguros.DAL
{
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly DatabaseContext _dbContext;

        public AseguradoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Asegurado>> GetAllAsegurados()
        {
            List<Asegurado> asegurados = new List<Asegurado>();
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAllAsegurados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            asegurados.Add(new Asegurado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Edad = reader.GetInt32(reader.GetOrdinal("Edad"))
                            });
                        }
                    }
                }
            }
            return asegurados;
        }

        public async Task<Asegurado> GetAseguradoById(int id)
        {
            Asegurado? asegurado = null;
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAseguradoById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            asegurado = new Asegurado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Edad = reader.GetInt32(reader.GetOrdinal("Edad"))
                            };
                        }
                    }
                }
            }
            return asegurado;
        }

        public async Task<Asegurado> GetAseguradoByCedula(string cedula)
        {
            Asegurado? asegurado = null;
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAseguradoByCedula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cedula", cedula);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            asegurado = new Asegurado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Edad = reader.GetInt32(reader.GetOrdinal("Edad"))
                            };
                        }
                    }
                }
            }
            return asegurado;
        }

        public async Task AddAsegurado(Asegurado asegurado)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("InsertAsegurado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cedula", asegurado.Cedula);
                    command.Parameters.AddWithValue("@Nombre", asegurado.Nombre);
                    command.Parameters.AddWithValue("@Telefono", asegurado.Telefono);
                    command.Parameters.AddWithValue("@Edad", asegurado.Edad);
                    command.Parameters.AddWithValue("@CreatedBy", "AlexVergara");
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsegurado(Asegurado asegurado)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("UpdateAsegurado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", asegurado.Id);
                    command.Parameters.AddWithValue("@Cedula", asegurado.Cedula);
                    command.Parameters.AddWithValue("@Nombre", asegurado.Nombre);
                    command.Parameters.AddWithValue("@Telefono", asegurado.Telefono);
                    command.Parameters.AddWithValue("@Edad", asegurado.Edad);
                    command.Parameters.AddWithValue("@UpdatedBy", "AlexVergara");
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsegurado(int id)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("DeleteAsegurado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DeletedBy", "AlexVergara");
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Asegurado>> GetAseguradosNoAsignadosPorSeguro(string codigoSeguro)
        {
            List<Asegurado> asegurados = new List<Asegurado>();

            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAseguradosNoAsignados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoSeguro", codigoSeguro);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            asegurados.Add(new Asegurado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Edad = reader.GetInt32(reader.GetOrdinal("Edad"))
                            });
                        }
                    }
                }
            }

            return asegurados;
        }



        public async Task BulkInsertAsegurados(DataTable filePath)
        {
            using (SqlConnection connection = _dbContext.CreateConnection())
            {
                await connection.OpenAsync();

                // Cargar datos en tabla temporal
                await CrearTablaTemporal(connection);
                await CargarDatosEnTablaTemporal(connection, filePath);

                // Insertar asegurados en la tabla principal
                await InsertarAsegurados(connection);

                // Asignar seguros basados en edad
                await AsignarSegurosPorEdad(connection);

                // Eliminar tabla temporal
                await EliminarTablaTemporal(connection);
            }

        }

        public async Task CargarDatosEnTablaTemporal(SqlConnection connection, DataTable dataTable)
        {
            
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = "AseguradosTemp";
                await bulkCopy.WriteToServerAsync(dataTable);
            }
        }

        public async Task CrearTablaTemporal(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("CrearTablaTemporal", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task InsertarAsegurados(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("InsertarAsegurados", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task AsignarSegurosPorEdad(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("AsignarSegurosPorEdad", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task EliminarTablaTemporal(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("EliminarTablaTemporal", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
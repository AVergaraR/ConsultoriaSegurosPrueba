using ConsultorioSeguros.DAL;
using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;


namespace ConsultorioSeguros.BLL
{

    public class AseguradoService : IAseguradoService
    {
        private readonly IAseguradoRepository _aseguradoRepository;
        private readonly FileValidatorService _fileValidatorService;

        public AseguradoService(IAseguradoRepository aseguradoRepository, FileValidatorService fileValidatorService)
        {
            _aseguradoRepository = aseguradoRepository;
            _fileValidatorService = fileValidatorService;
        }

        public async Task<Response<IEnumerable<Asegurado>>> GetAllAsegurados()
        {
            try
            {
                IEnumerable<Asegurado> asegurados = await _aseguradoRepository.GetAllAsegurados();
                return new Response<IEnumerable<Asegurado>> { Success = true, Data = asegurados };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Asegurado>> { Success = false, Message = "Error al obtener los asegurados", Error = ex.Message };
            }
        }

        public async Task<Response<Asegurado>> GetAseguradoById(int id)
        {
            try
            {
                Asegurado asegurado = await _aseguradoRepository.GetAseguradoById(id);
                return new Response<Asegurado> { Success = true, Data = asegurado };
            }
            catch (Exception ex)
            {
                return new Response<Asegurado> { Success = false, Message = "Error al obtener el asegurado", Error = ex.Message };
            }
        }

        public async Task<Response<Asegurado>> GetAseguradoByCedula(string cedula)
        {
            try
            {
                Asegurado asegurado = await _aseguradoRepository.GetAseguradoByCedula(cedula);
                return new Response<Asegurado> { Success = true, Data = asegurado };
            }
            catch (Exception ex)
            {
                return new Response<Asegurado> { Success = false, Message = "Error al obtener el asegurado", Error = ex.Message };
            }
        }

        public async Task<Response> AddAsegurado(Asegurado asegurado)
        {
            try
            {
                await _aseguradoRepository.AddAsegurado(asegurado);
                return new Response { Success = true, Message = "Asegurado agregado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al agregar el asegurado", Error = ex.Message };
            }
        }

        public async Task<Response> UpdateAsegurado(Asegurado asegurado)
        {
            try
            {
                await _aseguradoRepository.UpdateAsegurado(asegurado);
                return new Response { Success = true, Message = "Asegurado actualizado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al actualizar el asegurado", Error = ex.Message };
            }
        }

        public async Task<Response> DeleteAsegurado(int id)
        {
            try
            {
                await _aseguradoRepository.DeleteAsegurado(id);
                return new Response { Success = true, Message = "Asegurado eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al eliminar el asegurado", Error = ex.Message };
            }
        }

        public async Task<Response<IEnumerable<Asegurado>>> GetAseguradosNoAsignadosPorSeguro(string codigoSeguro)
        {
            try
            {
                IEnumerable<Asegurado> asegurados = await _aseguradoRepository.GetAseguradosNoAsignadosPorSeguro(codigoSeguro);
                return new Response<IEnumerable<Asegurado>> { Success = true, Data = asegurados };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Asegurado>> { Success = false, Message = "Error al obtener los asegurados", Error = ex.Message };
            }
        }




        public async Task<Response> BulkInsertAsegurados(string filePath)
        {
            try
            {
                await _aseguradoRepository.BulkInsertAsegurados(await ProcesarArchivo(filePath));
                return new Response { Success = true, Message = "Datos cargados exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al cargar los datos", Error = ex.Message };
            }
            

        }

        public async Task<DataTable> ProcesarArchivo(string filePath)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Cedula", typeof(string));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Telefono", typeof(string));
            dataTable.Columns.Add("Edad", typeof(int));

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue; // Skip header
                    }

                    string[] values = line.Split(',');
                    dataTable.Rows.Add(values[0], values[1], values[2], int.Parse(values[3]));
                }
            }

            return dataTable;
        }
  
    }
}
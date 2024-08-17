using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsultorioSeguros.BLL
{
    public class FileValidatorService
    {
        public async Task<string> ValidateFileAsync(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() != ".txt")
            {
                return "El archivo debe ser de tipo .txt.";
            }

            string[] lines = await File.ReadAllLinesAsync(filePath);

            if (lines.Length < 2)
            {
                return "El archivo no contiene suficientes datos.";
            }

            string header = lines[0];
            string expectedHeader = "Cedula,Nombre,Telefono,Edad";

            if (header != expectedHeader)
            {
                return "El encabezado del archivo es incorrecto. Debe ser: " + expectedHeader;
            }

            return "Archivo valido.";
        }
    }
}


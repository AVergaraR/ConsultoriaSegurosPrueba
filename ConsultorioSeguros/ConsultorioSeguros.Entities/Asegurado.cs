namespace ConsultorioSeguros.Entities
{
    public class Asegurado
    {
        public int Id { get; set; }
        public required string Cedula { get; set; }
        public required string Nombre { get; set; }
        public required string Telefono { get; set; }
        public int Edad { get; set; }
    }
}
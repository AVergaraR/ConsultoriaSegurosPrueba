namespace ConsultorioSeguros.Entities
{
    public class Seguro
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Codigo { get; set; }
        public decimal SumaAsegurada { get; set; }
        public decimal Prima { get; set; }
    }
}
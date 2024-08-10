namespace Factoring.Application.DTOs.Fondeador.CavaliFondeador
{
    public class CavaliFondeadorCreateDto
    {
        public int CodParticipante { get; set; }
        public int CodRUT { get; set; }
        public string UsuarioCreador { get; set; }
        public int IdFondeador { get; set; }
    }
    public class CavaliFondeadorResponseListDto
    {
        public string nIdFondeadorCavali { get; set; }
        public string nCodParticipante { get; set; }
        public string nCodRUT { get; set; }
    }
    public class CavaliFondeadorDeleteDto
    {
        public string UsuarioActualizacion { get; set; }
        public int IdFondeadorCavali { get; set; }
    }
}

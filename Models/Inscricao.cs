using VestibularAPI.Models;

public class Inscricao
{
    public int Id { get; set; }
    public int NumInscricao { get; set; }
    public DateTime DataInscricao { get; set; }
    public int CandidatoId { get; set; }
    public int OfertaId { get; set; }
    public int ProcessoSeletivoId { get; set; }
}

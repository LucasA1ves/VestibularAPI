public class ProcessoSeletivo
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }

    // Inicialize a coleção para evitar problemas com null
    public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}

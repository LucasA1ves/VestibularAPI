namespace VestibularAPI.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VagasDisponiveis { get; set; }

        // Inicialize a coleção para evitar problemas com null
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}

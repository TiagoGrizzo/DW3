namespace SistemaAcademico.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public int Vagas { get; set; }
        public ICollection<Disciplina>? Disciplinas { get; set; } // o I antes de Collection é de interface, que no caso é uma coleção do tipo Disciplina
    }
}

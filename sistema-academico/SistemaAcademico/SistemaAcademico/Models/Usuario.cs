namespace SistemaAcademico.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string? Nome { get; set; }  // ? signifca nullable
        public string? Email { get; set; }
        public string? Senha { get; set; }

    }
}

using System.ComponentModel.DataAnnotations; //necessario para tudo funcionar

namespace SistemaAcademico.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Display(Name ="RA")]//para fazer o RA aparecer maiusculo
        [Required(ErrorMessage="O RA é Obrigatório")]//mensagem de erro em portugues
        [StringLength(10,MinimumLength =4, ErrorMessage ="O RA deve ter entre 4 e 10 caracteres")]// tamanho maximo e minimo do RA + mensagem de erro caso não possua a quantidade correta
        public string? Ra { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } //vai guardar um objeto da classe usuario
    }
}


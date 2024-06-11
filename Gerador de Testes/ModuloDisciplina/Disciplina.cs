using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloDisciplina
{
    public class Disciplina : EntidadeBase
    {
        public string Nome { get; set; }
        public List<ModuloMateria.Materia> Materias { get; set; }

        public Disciplina() {}
        public Disciplina(string nome) => Nome = nome;

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Disciplina atualizada = (Disciplina)novoRegistro;
            Nome = atualizada.Nome;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
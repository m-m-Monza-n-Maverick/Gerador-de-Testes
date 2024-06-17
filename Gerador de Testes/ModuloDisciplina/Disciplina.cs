using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes.ModuloDisciplina
{
    public class Disciplina : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }

        public Disciplina() {}
        public Disciplina(string nome, List<Materia> materias)
        {
            Nome = nome;
            Materias = materias;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Disciplina atualizada = (Disciplina)novoRegistro;

            Nome = atualizada.Nome;
            Materias = atualizada.Materias;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];
            VerificaNulo(ref erros, Nome, "Nome");

            return erros;
        }
        public override string ToString() => Nome.ToTitleCase();
    }
}
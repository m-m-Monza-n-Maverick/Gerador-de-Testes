using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloMateria
{
    public class Materia : EntidadeBase
    {
        public string Nome {  get; set; }

        public Disciplina Disciplina { get; set; }

        public string Serie { get; set; }

        public List<ModuloQuestao.Questao> Questoes { get; set; } = [];

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
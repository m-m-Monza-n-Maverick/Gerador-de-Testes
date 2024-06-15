using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;

namespace Gerador_de_Testes.ModuloMateria
{
    public class Materia : EntidadeBase
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> Questoes { get; set; }

        public Materia() { }
    
        public Materia(string nome, string serie, Disciplina disciplina)
        {
            Nome = nome;
            Serie = serie;
            Disciplina = disciplina;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            VerificaNulo(ref erros, Nome, "Nome");
            VerificaNulo(ref erros, Disciplina);
            VerificaNulo(ref erros, Serie, "Série");

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Materia atualizado = (Materia)novoRegistro;

            Nome = atualizado.Nome;
            Serie = atualizado.Serie;
            Disciplina = atualizado.Disciplina;
        }
        public override string ToString()
        {
            return $"{Nome.ToTitleCase()}, {Serie}";
        }
        protected void VerificaNulo(ref List<string> erros, Disciplina campoTestado)
        {
            if (campoTestado == null)
                erros.Add("\nÉ necessário informar uma \"Disciplina\". Tente novamente ");
        }
    }
}
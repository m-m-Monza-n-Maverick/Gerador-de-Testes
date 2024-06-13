using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public class Teste : EntidadeBase
    {
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public int QntQuestoes { get; set; }
        public Materia Materia { get; set; }
        public string Serie { get; set; }
        public List<Questao> Questoes { get; set; }
        public bool Recuperacao { get; set; }

        public Teste() { }
        public Teste(string titulo, Disciplina disciplina, Materia materia, int qntQuestoes, List<Questao> questoes, bool recuperacao)
        {
            Titulo = titulo;
            Disciplina = disciplina;
            QntQuestoes = qntQuestoes;
            Materia = materia;
            Serie = materia.Serie;
            Questoes = questoes;
            Recuperacao = recuperacao;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
/*            Teste atualizado = (Teste)novoRegistro;

            Titulo = atualizado.Titulo;
            Diciplina = atualizado.Diciplina;
            Materia = atualizado.Materia;
            Serie = atualizado.Serie;
            QntQuestoes = atualizado.QntQuestoes;
            Questoes = atualizado.Questoes;
            Recuperacao = atualizado.Recuperacao;
*/        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Titulo, "Título");
            VerificaNulo(ref erros, Disciplina);
            VerificaNulo(ref erros, QntQuestoes, "Quantidade de questões");
            VerificaNulo(ref erros, Materia);

            return erros;
        }
        public override string ToString() => Titulo.ToTitleCase();

        #region Auxiliares de validação
        protected void VerificaNulo(ref List<string> erros, Disciplina disciplina)
        {
            if (disciplina == null)
                erros.Add("\nÉ necessário informar uma \"Disciplina\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, Materia materia)
        {
            if (materia == null)
                erros.Add("\nÉ necessário informar uma \"Matéria\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, List<string> questoes)
        {
            if (questoes.Count == 0)
                erros.Add("\nÉ necessário sortear as \"Questões\". Tente novamente ");
        }
        #endregion
    }
}
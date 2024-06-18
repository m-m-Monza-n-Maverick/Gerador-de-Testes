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
            if (materia != null) 
                Serie = materia.Serie;
            Questoes = questoes;
            Recuperacao = recuperacao;
        }

        #region Overrides
        public override void AtualizarRegistro(EntidadeBase novoRegistro) { }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Titulo, "Título");
            VerificaNulo(ref erros, Disciplina);
            if (!Recuperacao)
                VerificaNulo(ref erros, Materia);
            VerificaNulo(ref erros, Questoes);

            return erros;
        }
        public override string ToString() => Titulo.ToTitleCase();
        #endregion

        #region Auxiliares de validação
        protected void VerificaNulo(ref List<string> erros, Disciplina disciplina)
        {
            if (disciplina == null)
                erros.Add("É necessário informar uma \"Disciplina\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, Materia materia)
        {
            if (materia == null)
                erros.Add("É necessário informar uma \"Matéria\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, List<Questao> questoes)
        {
            if (questoes.Count == 0)
                erros.Add("É necessário sortear as \"Questões\". Tente novamente ");
        }
        internal void ValidarTitulo(ref List<string> erros, List<Teste> testes)
        {
            if (testes.Exists(t => t.Titulo.Validation() == Titulo.Validation()))
                erros.Add($"Já existe um teste com o título \"{Titulo.ToTitleCase()}\". Tente novamente");
        }
        #endregion

        #region Auxiliares de sorteio
        internal void SortearQuestoes(Teste teste, Disciplina disciplina, Materia materia, bool recuperacao, ListBox listaQuestoes)
        {
            List<Materia> materias = materiasParaSorteio(disciplina, materia, recuperacao);

            Random random = new();

            Span<int> IdsSorteados = idsParaSorteio(materias).ToArray();

            random.Shuffle<int>(IdsSorteados);

            Sortear(materias, IdsSorteados, teste, listaQuestoes);
        }
        private List<Materia> materiasParaSorteio(Disciplina disciplina, Materia materia, bool recuperacao)
        {
            List<Materia> materias;

            if (recuperacao)
                materias = disciplina.Materias;
            else
                materias = [materia];

            return materias;
        }
        private List<int> idsParaSorteio(List<Materia> materias)
        {
            List<int> idsDasQuestoes = [];

            foreach (Materia m in materias)
                foreach (Questao q in m.Questoes)
                    idsDasQuestoes.Add(q.Id);

            return idsDasQuestoes;
        }
        private void Sortear(List<Materia> materias, Span<int> IdsSorteados, Teste teste, ListBox listaQuestoes)
        {
            int i = 0;
            foreach (int id in IdsSorteados)
                foreach (Materia m in materias)
                    foreach (Questao q in m.Questoes)
                        if (q.Id == id)
                        {
                            if (i >= teste.QntQuestoes) return;
                            listaQuestoes.Items.Add(q);
                            i++;
                        }
        }
        #endregion
    }
}
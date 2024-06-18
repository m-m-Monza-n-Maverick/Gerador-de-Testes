using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;

namespace Gerador_de_Testes.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public string Resposta { get; set; }    
        public List<Alternativa> Alternativas { get; set; }

        public Questao(){}
        public Questao(string enunciado, Materia materia, List<Alternativa> alternativas, string resposta)
        {
            Enunciado = enunciado;
            Materia = materia;
            Alternativas = alternativas;
            Resposta = resposta;
        }

        #region Overrides
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Questao atualizado = (Questao)novoRegistro;

            Enunciado = atualizado.Enunciado;
            Materia = atualizado.Materia;
            Alternativas = atualizado.Alternativas;
            Resposta = atualizado.Resposta;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Materia);
            VerificaNulo(ref erros, Enunciado, "enunciado");

            if (Alternativas.Count < 2)
                erros.Add($"O numero mínimo de alternativas é 2");

            if (string.IsNullOrEmpty(Resposta))
                erros.Add($"Selecione a resposta correta");

            return erros;
        }
        public override string ToString()
        {
            return $"{Enunciado}";
        }
        #endregion

        #region Auxiliares
        protected void VerificaNulo(ref List<string> erros, Materia materia)
        {
            if (materia == null)
                erros.Add("\nÉ necessário informar uma \"Matéria\". Tente novamente ");
        }
        internal void ValidarQuestaoJaExistente(ref List<string> erros, List<Questao> questoes, int id)
        {
            foreach (Questao q in questoes)
                if (q.Materia == Materia)
                    if (q.Enunciado.Validation() == Enunciado.Validation())
                        if (q.Id != id)
                            erros.Add("Esta questão já existe. Tente novamente");
        }
        internal void AdicionarQuestaoNaMateria(List<Materia> materias, int id)
        {
            Id = id;

            foreach (Materia m in materias)
                if (m == Materia)
                {
                    m.Questoes.Add(this);
                    m.AtualizarRegistro(m);
                }
        }
        internal void RemoverQuestaoNaMateria(List<Materia> materias)
        {
            foreach (Materia m in materias)
                foreach (Questao q in m.Questoes)
                    if (q.Enunciado == Enunciado)
                    {
                        m.Questoes.Remove(q);
                        m.AtualizarRegistro(m);
                        return;
                    }
        }
        #endregion
    }
}
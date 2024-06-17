using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloTeste;
namespace Gerador_de_Testes.ModuloQuestao
{
    internal class RepositorioQuestao : RepositorioBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ContextoDados contexto) : base(contexto) { }
        protected override List<Questao> ObterRegistros() => contexto.Questoes;
        public override bool Excluir(int id)
        {
            foreach (Teste t in contexto.Testes)
                if (t.Materia.Questoes.Exists(q => q.Id == id))
                {
                    MessageBox.Show(
                        "Registro sendo utilizado por um teste.\nNão é possível excluir!",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

            AtualizarMateria(id);

            return base.Excluir(id);
        }

        private void AtualizarMateria(int id)
        {
            Questao questaoSelecionada = SelecionarPorId(id);

            foreach (Materia m in contexto.Materias)
            {
                foreach (Questao q in m.Questoes)
                    if (q.Enunciado == questaoSelecionada.Enunciado)
                        questaoSelecionada = q;

                m.Questoes.Remove(questaoSelecionada);
            }
        }
    }
}

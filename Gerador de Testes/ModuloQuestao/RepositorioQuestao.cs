using Gerador_de_Testes.Compartilhado;
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

            return base.Excluir(id);
        }
    }
}

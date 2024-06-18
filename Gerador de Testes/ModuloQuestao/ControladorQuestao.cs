using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes.ModuloQuestao
{
    public class ControladorQuestao(IRepositorioQuestao repositorioQuestao, ContextoDados contexto) : ControladorBase, IControladorDetalhes
    {
        private TabelaQuestaoControl tabelaQuestao;

        #region ToolTips
        public override string TipoCadastro => "Questão";
        public override string ToolTipAdicionar => "Adicionar questão";
        public override string ToolTipEditar => "Editar uma questão";
        public override string ToolTipExcluir => "Excluir uma questão";
        public string ToolTipVisualizarDetalhes => "Visualizar detalhes";
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            if (SemDependenciasCadastradas(contexto.Materias.Count, "Matérias")) return;
            int id = repositorioQuestao.PegarId();

            TelaQuestaoForm telaQuestao = new(id, contexto);

            DialogResult resultado = telaQuestao.ShowDialog();

            if (DialogResult.OK != resultado) return;

            Questao novaQuestao = telaQuestao.Questao;

            novaQuestao.AdicionarQuestaoNaMateria(contexto.Materias, id);

            RealizarAcao(
                () => repositorioQuestao.Cadastrar(novaQuestao),
                novaQuestao, "cadastrado");
        }
        public override void Editar()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            TelaQuestaoForm telaQuestao = new(idSelecionado, contexto);

            Questao questaoSelecionada =
                repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada)) return;

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Questao questaoEditada = telaQuestao.Questao;

            questaoSelecionada.RemoverQuestaoNaMateria(contexto.Materias);

            questaoEditada.AdicionarQuestaoNaMateria(contexto.Materias, idSelecionado);

            RealizarAcao(
                () => repositorioQuestao.Editar(idSelecionado, questaoEditada),
                questaoEditada, "editada");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada) || !DesejaRealmenteExcluir(questaoSelecionada)) return;

            questaoSelecionada.RemoverQuestaoNaMateria(contexto.Materias);

            RealizarAcao(
                () => repositorioQuestao.Excluir(idSelecionado),
                questaoSelecionada, "excluído");
        }
        public void VisualizarDetalhes()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada =
                repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada)) return;

            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(idSelecionado, contexto);

            if (questaoSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            telaQuestao.ModoVisualizacao();

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;
        }
        #endregion

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarRegistros();

            return tabelaQuestao;
        }
        protected override void CarregarRegistros()
        {
            List<Questao> Questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(Questoes);
        }
        #endregion
    }
}

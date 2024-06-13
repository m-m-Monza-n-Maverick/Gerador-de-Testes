using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloQuestao
{
    internal class ControladorQuestao(IRepositorioQuestao repositorioQuestao, ContextoDados contexto) : ControladorBase
    {
        private IRepositorioQuestao RepositorioQuestao = repositorioQuestao;
        private TabelaQuestaoControl tabelaQuestao;

        #region ToolTips
        public override string TipoCadastro => "Questão";
        public override string ToolTipAdicionar => "Adicionar questão";
        public override string ToolTipEditar => "Editar uma questão";
        public override string ToolTipExcluir => "Excluir uma questão";
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            int id = repositorioQuestao.PegarId();

            TelaQuestaoForm telaQuestao = new(id);
            DialogResult resultado = telaQuestao.ShowDialog();

            if (DialogResult.OK != resultado) return;

            Questao novaQuestao = telaQuestao.Questao;

            RepositorioQuestao.Cadastrar(novaQuestao);

            CarregarQuestoes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaQuestao.Enunciado}\" foi excluído com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(idSelecionado);

            Questao questaoSelecionada =
                repositorioQuestao.SelecionarPorId(idSelecionado);

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

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Questao clienteEditado = telaQuestao.Questao;

            RepositorioQuestao.Editar(questaoSelecionada.Id, clienteEditado);

            CarregarQuestoes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{clienteEditado.Enunciado}\" foi editado com sucesso!");

        }

        public override void Excluir()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada)) return;

            if (!DesejaRealmenteExcluir(questaoSelecionada)) return;

            repositorioQuestao.Excluir(questaoSelecionada.Id);

            CarregarQuestoes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{questaoSelecionada.Enunciado}\" foi excluído com sucesso!");
        }
        #endregion

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }
        private void CarregarQuestoes()
        {
            List<Questao> Questoes = RepositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(Questoes);
        }
    }
}

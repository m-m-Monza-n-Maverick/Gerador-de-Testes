﻿using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloQuestao
{
    internal class ControladorQuestao(IRepositorioQuestao repositorioQuestao) : ControladorBase, IControladorDetalhes
    {
        private IRepositorioQuestao RepositorioQuestao = repositorioQuestao;
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
            int id = repositorioQuestao.PegarId();

            TelaQuestaoForm telaQuestao = new(id);
            DialogResult resultado = telaQuestao.ShowDialog();

            if (DialogResult.OK != resultado) return;

            Questao novaQuestao = telaQuestao.Questao;

            RepositorioQuestao.Cadastrar(novaQuestao);

            CarregarQuestoes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaQuestao.Enunciado}\" foi adicionado com sucesso!");
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

            Questao questaoEditada = telaQuestao.Questao;

            RepositorioQuestao.Editar(questaoSelecionada.Id, questaoEditada);

            CarregarQuestoes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{questaoEditada.Enunciado}\" foi editado com sucesso!");

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

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        public void VisualizarDetalhes()
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
            telaQuestao.VisualizarMode();

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;
        }

        private void CarregarQuestoes()
        {
            List<Questao> Questoes = RepositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(Questoes);
        }
        #endregion
    }
}
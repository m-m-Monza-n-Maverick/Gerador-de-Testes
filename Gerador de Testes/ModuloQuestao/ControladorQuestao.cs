using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes.ModuloQuestao
{
    internal class ControladorQuestao(IRepositorioQuestao repositorioQuestao, ContextoDados contexto) : ControladorBase, IControladorDetalhes
    {
        private IRepositorioQuestao repositorioQuestao = repositorioQuestao;
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
            if (SemMaterias()) return;
            int id = repositorioQuestao.PegarId();

            TelaQuestaoForm telaQuestao = new(id, contexto);

            CarregarMaterias(telaQuestao);

            DialogResult resultado = telaQuestao.ShowDialog();

            if (DialogResult.OK != resultado) return;

            Questao novaQuestao = telaQuestao.Questao;

            AdicionarQuestaoNaMateria(novaQuestao, id);

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

            RemoverQuestaoNaMateria(questaoSelecionada);

            AdicionarQuestaoNaMateria(questaoEditada, idSelecionado);

            RealizarAcao(
                () => repositorioQuestao.Editar(idSelecionado, questaoEditada),
                questaoEditada, "editada");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada) || !DesejaRealmenteExcluir(questaoSelecionada)) return;

            RemoverQuestaoNaMateria(questaoSelecionada);

            RealizarAcao(
                () => repositorioQuestao.Excluir(idSelecionado),
                questaoSelecionada, "excluído");
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
        private bool SemMaterias()
        {
            if (contexto.Materias.Count == 0)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem Matérias cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
        private void AdicionarQuestaoNaMateria(Questao novaQuestao, int id)
        {
            novaQuestao.Id = id;

            foreach (Materia m in contexto.Materias)
                if (m == novaQuestao.Materia)
                {
                    m.Questoes.Add(novaQuestao);
                    m.AtualizarRegistro(m);
                }
        }
        private void RemoverQuestaoNaMateria(Questao questaoSelecionada)
        {
            foreach (Materia m in contexto.Materias)
                foreach (Questao q in m.Questoes)
                    if (q.Enunciado == questaoSelecionada.Enunciado)
                    {
                        m.Questoes.Remove(q);
                        m.AtualizarRegistro(m);
                        return;
                    }
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
            telaQuestao.VisualizarMode();

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;
        }
        private void CarregarQuestoes()
        {
            List<Questao> Questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(Questoes);
        }
        private void CarregarMaterias(TelaQuestaoForm telaQuestao)
        {
            List<Materia> materiasCadastradas = contexto.Materias;

            telaQuestao.CarregarMaterias(contexto.Materias);
        }
        private void RealizarAcao(Action acao, Questao questao, string texto)
        {
            acao();
            CarregarQuestoes();
            CarregarMensagem(questao, texto);
        }
        #endregion
    }
}

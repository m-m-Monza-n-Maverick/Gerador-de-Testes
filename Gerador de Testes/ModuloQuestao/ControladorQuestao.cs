using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
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

            RealizarAcao(
                () => repositorioQuestao.Cadastrar(novaQuestao),
                novaQuestao, "cadastrado");

            AtualizaMateria(contexto, novaQuestao);
        }
        public override void Editar()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(idSelecionado, contexto);

            Questao questaoSelecionada =
                repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada)) return;

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Questao questaoEditada = telaQuestao.Questao;

            AtualizarMateria(contexto, questaoSelecionada, questaoEditada);

            RealizarAcao(
                () => repositorioQuestao.Editar(idSelecionado, questaoEditada),
                questaoEditada, "editada");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (SemSeleção(questaoSelecionada) || !DesejaRealmenteExcluir(questaoSelecionada)) return;

            AtualizarMateria(contexto, ref questaoSelecionada);

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
        private void AtualizaMateria(ContextoDados contexto, Questao novaQuestao)
        {
            foreach (Materia m in contexto.Materias)
                if (m == novaQuestao.Materia)
                    m.Questoes.Add(novaQuestao);

            contexto.Gravar();
        }
        private void AtualizarMateria(ContextoDados contexto, Questao questaoSelecionada, Questao questaoEditada)
        {
            if (questaoSelecionada.Materia != questaoEditada.Materia)
            {
                foreach (Materia m in contexto.Materias)
                {
                    if (m == questaoSelecionada.Materia)
                    {
                        foreach (Questao q in m.Questoes)
                            if (q.Enunciado == questaoSelecionada.Enunciado)
                                questaoSelecionada = q;

                        m.Questoes.Remove(questaoSelecionada);
                    }

                    if (m == questaoEditada.Materia)
                        m.Questoes.Add(questaoEditada);
                }
            }
        }
        private void AtualizarMateria(ContextoDados contexto, ref Questao questaoSelecionada)
        {
            foreach (Materia m in contexto.Materias)
            {
                foreach (Questao q in m.Questoes)
                    if (q.Enunciado == questaoSelecionada.Enunciado)
                        questaoSelecionada = q;

                m.Questoes.Remove(questaoSelecionada);
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

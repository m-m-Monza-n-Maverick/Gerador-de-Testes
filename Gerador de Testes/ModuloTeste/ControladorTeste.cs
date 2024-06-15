using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class ControladorTeste(IRepositorioTeste repositorioTeste, ContextoDados contexto) : ControladorBase, IControladorDuplicavel, IControladorDetalhes
    {
        private IRepositorioTeste repositorioTeste = repositorioTeste;
        private TabelaTesteControl tabelaTeste;

        #region ToolTips
        public override string TipoCadastro { get => "Testes"; }
        public override string ToolTipAdicionar { get => "Cadastrar um novo teste"; }
        public override string ToolTipEditar => throw new NotImplementedException();
        public override string ToolTipExcluir { get => "Excluir um teste"; }
        public string ToolTipDuplicarTeste { get => "Duplicar um teste"; }
        public string ToolTipVisualizarDetalhes { get => "Visualizar detalhes"; }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            if (SemDisciplinaOuMateria()) return;

            int id = repositorioTeste.PegarId();

            TelaTesteForm telaTeste = new(contexto);

            DialogResult resultado = telaTeste.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Teste novoTeste = telaTeste.Teste;

            RealizarAcao(
                () => repositorioTeste.Cadastrar(novoTeste),
                novoTeste, "cadastrado");

            id++;
        }
        public override void Editar() { }
        public override void Excluir()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado) || !DesejaRealmenteExcluir(testeSelecionado)) return;

            RealizarAcao(
                () => repositorioTeste.Excluir(testeSelecionado.Id),
                testeSelecionado, "excluído");
        }
        public void DuplicarTeste()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            TelaTesteForm telaTeste = new(contexto);

            telaTeste.Teste = testeSelecionado;

            DialogResult resultado = telaTeste.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Teste testeDuplicado = telaTeste.Teste;

            RealizarAcao(
                () => repositorioTeste.Cadastrar(testeDuplicado),
                testeDuplicado, "duplicado");
        }
        public void VisualizarDetalhes()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            TelaDetalhesTesteForm telaDetalhesTeste = new();

            telaDetalhesTeste.Teste = testeSelecionado;

            telaDetalhesTeste.ShowDialog();
        }
        #endregion

        public override UserControl ObterListagem()
        {
            tabelaTeste ??= new();

            CarregarTestes();

            return tabelaTeste;
        }
        private void CarregarTestes()
            => tabelaTeste.AtualizarRegistros(repositorioTeste.SelecionarTodos());
        private bool SemDisciplinaOuMateria()
        {
            if (contexto.Disciplinas.Count == 0 || contexto.Materias.Count == 0)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem Disciplinas ou Matérias cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
        private void RealizarAcao(Action acao, Teste teste, string texto)
        {
            acao();
            CarregarTestes();
            CarregarMensagem(teste, texto);
        }
    }
}

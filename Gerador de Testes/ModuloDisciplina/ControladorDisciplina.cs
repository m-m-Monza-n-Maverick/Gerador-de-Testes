using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloDisciplina
{
    internal class ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, ContextoDados contexto) : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina = repositorioDisciplina;
        private TabelaDisciplinaControl tabelaDisciplina;

        #region ToolTips
        public override string TipoCadastro { get { return "Disciplinas"; } }
        public override string ToolTipAdicionar { get { return "Cadastrar uma nova disciplina"; } }
        public override string ToolTipEditar { get { return "Editar uma disciplina"; } }
        public override string ToolTipExcluir { get { return "Excluir uma disciplina"; } }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            int id = repositorioDisciplina.PegarId();

            TelaDisciplinaForm telaDisciplina = new(id, contexto);
            DialogResult resultado = telaDisciplina.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Disciplina novaDisciplina = telaDisciplina.Disciplina;

            RealizarAcao(
                () => repositorioDisciplina.Cadastrar(novaDisciplina), 
                novaDisciplina, "cadastrado");

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaDisciplina.ObterRegistroSelecionado();

            TelaDisciplinaForm telaDisciplina = new(idSelecionado, contexto);

            Disciplina disciplinaSelecionada =
                repositorioDisciplina.SelecionarPorId(idSelecionado);

            if (SemSeleção(disciplinaSelecionada)) return;

            telaDisciplina.Disciplina = disciplinaSelecionada;

            DialogResult resultado = telaDisciplina.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Disciplina disciplinaEditada = telaDisciplina.Disciplina;

            RealizarAcao(
                () => repositorioDisciplina.Editar(disciplinaSelecionada.Id, disciplinaEditada),
                disciplinaEditada, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaDisciplina.ObterRegistroSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(idSelecionado);

            if (SemSeleção(disciplinaSelecionada) || !DesejaRealmenteExcluir(disciplinaSelecionada)) return;

            RealizarAcao(
                () => repositorioDisciplina.Excluir(disciplinaSelecionada.Id),
                disciplinaSelecionada, "excluído");
        }
        #endregion

        public override UserControl ObterListagem()
        {
            tabelaDisciplina ??= new();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }
        private void CarregarDisciplinas()
            => tabelaDisciplina.AtualizarRegistros(repositorioDisciplina.SelecionarTodos());
        private void RealizarAcao(Action acao, Disciplina disciplina, string texto)
        {
            acao();
            CarregarDisciplinas();
            CarregarMensagem(disciplina, texto);
        }
    }
}

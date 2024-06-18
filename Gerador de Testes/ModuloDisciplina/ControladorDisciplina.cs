using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloDisciplina
{
    public class ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, ContextoDados contexto) : ControladorBase
    {
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

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaDisciplina ??= new();

            CarregarRegistros();

            return tabelaDisciplina;
        }
        protected override void CarregarRegistros()
            => tabelaDisciplina.AtualizarRegistros(repositorioDisciplina.SelecionarTodos());
        #endregion
    }
}

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

            repositorioDisciplina.Cadastrar(novaDisciplina);

            CarregarDisciplinas();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaDisciplina.Nome}\" foi criado com sucesso!");

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

            repositorioDisciplina.Editar(disciplinaSelecionada.Id, disciplinaEditada);

            CarregarDisciplinas();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{disciplinaEditada.Nome}\" foi editado com sucesso!");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaDisciplina.ObterRegistroSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(idSelecionado);

            if (SemSeleção(disciplinaSelecionada) || !DesejaRealmenteExcluir(disciplinaSelecionada)) return;

            repositorioDisciplina.Excluir(disciplinaSelecionada.Id);

            CarregarDisciplinas();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{disciplinaSelecionada}\" foi excluído com sucesso!");
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
    }
}

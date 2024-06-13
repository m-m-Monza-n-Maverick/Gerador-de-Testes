using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class ControladorTeste(IRepositorioTeste repositorioTeste, ContextoDados contexto) : ControladorBase
    {
        private IRepositorioTeste repositorioTeste = repositorioTeste;
        private TabelaTesteControl tabelaTeste;

        #region ToolTips
        public override string TipoCadastro { get { return "Testes"; } }
        public override string ToolTipAdicionar { get { return "Cadastrar um novo teste"; } }
        public override string ToolTipEditar { get { return "Editar um teste"; } }
        public override string ToolTipExcluir { get { return "Excluir um teste"; } }
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

            repositorioTeste.Cadastrar(novoTeste);

            CarregarTestes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novoTeste}\" foi criado com sucesso!");

            id++;
        }
        public override void Editar() { }
        public override void Excluir()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado) || !DesejaRealmenteExcluir(testeSelecionado)) return;

            repositorioTeste.Excluir(testeSelecionado.Id);

            CarregarTestes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{testeSelecionado}\" foi excluído com sucesso!");
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
                    "Não é possível cadastrar um teste\n\nNão existem Disciplinas/Matérias cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
    }
}

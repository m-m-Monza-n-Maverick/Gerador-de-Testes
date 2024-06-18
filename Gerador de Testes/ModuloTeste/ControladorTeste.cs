using Gerador_de_Testes.Compartilhado;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public class ControladorTeste(IRepositorioTeste repositorioTeste, ContextoDados contexto) : ControladorBase, IControladorDuplicavel, IControladorDetalhes, IControladorPDF
    {
        private TabelaTesteControl tabelaTeste;

        #region ToolTips
        public override string TipoCadastro { get => "Testes"; }
        public override string ToolTipAdicionar { get => "Cadastrar um novo teste"; }
        public override string ToolTipEditar => throw new NotImplementedException();
        public override string ToolTipExcluir { get => "Excluir um teste"; }
        public string ToolTipDuplicarTeste { get => "Duplicar um teste"; }
        public string ToolTipVisualizarDetalhes { get => "Visualizar detalhes"; }
        public string ToolTipGerarPDF { get => "Gerar PDF"; }
        public string ToolTipGerarPdfGabarito { get => "Gerar PDF do gabarito"; }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            if (SemDependenciasCadastradas(contexto.Disciplinas.Count, "Disciplinas") || 
                SemDependenciasCadastradas(contexto.Materias.Count, "Matérias") ||
                SemDependenciasCadastradas(contexto.Questoes.Count, "Questões")) return;

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

        #region Demais botões
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
        public void GerarPDF()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            GeradorDePDF geradorDePDF = new ($"C:\\temp\\{testeSelecionado}.pdf", testeSelecionado);

            geradorDePDF.GerarPDF(false);

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O arquivo \"Teste {testeSelecionado}.pdf\" foi gerado com sucesso na pasta \"temp\"");
        }
        public void GerarPdfGabarito()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            GeradorDePDF geradorDePDF = new($"C:\\temp\\Gabarito - {testeSelecionado}.pdf", testeSelecionado);

            geradorDePDF.GerarPDF(true);

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O arquivo \"Gabarito - {testeSelecionado}.pdf\" foi gerado com sucesso na pasta \"C:\\temp\"");
        }
        #endregion

        #region Auxiliares
        public override UserControl ObterListagem()
            {
                tabelaTeste ??= new();

                CarregarRegistros();

                return tabelaTeste;
            }
        protected override void CarregarRegistros()
            => tabelaTeste.AtualizarRegistros(repositorioTeste.SelecionarTodos());
        #endregion
    }
}

using Gerador_de_Testes.Compartilhado;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class ControladorTeste(IRepositorioTeste repositorioTeste, ContextoDados contexto) : ControladorBase, IControladorDuplicavel, IControladorDetalhes, IControladorPDF
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
        public string ToolTipGerarPDF { get => "Gerar PDF"; }
        public string ToolTipGerarPdfGabarito { get => "Gerar PDF do gabarito"; }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            if (SemDisciplinaOuMateriaOuQuestao()) return;

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
        public void VisualizarDetalhes()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            TelaDetalhesTesteForm telaDetalhesTeste = new();

            telaDetalhesTeste.Teste = testeSelecionado;

            telaDetalhesTeste.ShowDialog();
        }
        public void GerarPDF()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            Document doc = new(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();

            string caminho = $"C:\\temp\\Teste {testeSelecionado}.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            Phrase label = new("", new(iTextSharp.text.Font.NORMAL, 10));
            Phrase conteudo = new("", new((iTextSharp.text.Font.FontFamily)iTextSharp.text.Font.BOLD, 10));

            doc.Open();

            Cabecalho(doc, "TESTE");

            InformacoesSobreTeste(testeSelecionado, doc, label, conteudo);

            Cabecalho(doc, "\nQUESTÕES");

            InformacoesSobreQuestoes(testeSelecionado, doc, label, conteudo);

            doc.Close();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O arquivo \"Teste {testeSelecionado}.pdf\" foi gerado com sucesso na pasta \"temp\"");
        }
        public void GerarPdfGabarito()
        {
            int idSelecionado = tabelaTeste.ObterRegistroSelecionado();
            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (SemSeleção(testeSelecionado)) return;

            Document doc = new(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();

            string caminho = $"C:\\temp\\Gabarito - Teste {testeSelecionado}.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            Phrase label = new("", new(iTextSharp.text.Font.NORMAL, 10));
            Phrase conteudo = new("", new((iTextSharp.text.Font.FontFamily)iTextSharp.text.Font.BOLD, 10));

            doc.Open();

            Cabecalho(doc, "GABARITO DO TESTE");

            InformacoesSobreTeste(testeSelecionado, doc, label, conteudo);

            Cabecalho(doc, "\nQUESTÕES");

            InformacoesSobreQuestoesComResposta(testeSelecionado, doc, label, conteudo);

            doc.Close();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O arquivo \"Gabarito - Teste {testeSelecionado}.pdf\" foi gerado com sucesso na pasta \"C:\\temp\"");
        }
        #endregion

        #region Auxiliares
        public override UserControl ObterListagem()
            {
                tabelaTeste ??= new();

                CarregarTestes();

                return tabelaTeste;
            }
        private void CarregarTestes()
            => tabelaTeste.AtualizarRegistros(repositorioTeste.SelecionarTodos());
        private bool SemDisciplinaOuMateriaOuQuestao()
        {
            if (contexto.Disciplinas.Count == 0 || contexto.Materias.Count == 0 || contexto.Questoes.Count == 0)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem Disciplinas, Matérias ou Questões cadastradas",
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

        private static void AdicionaParagrafoAoPDF(Document doc, Phrase label, Phrase conteudo)
        {
            conteudo.Add("\n");

            doc.Add(label);
            doc.Add(conteudo);

            label.Clear();
            conteudo.Clear();
        }
        private static void Cabecalho(Document doc, string texto)
        {
            Paragraph cabecalho = new($"{texto}\n", new iTextSharp.text.Font((iTextSharp.text.Font.FontFamily)iTextSharp.text.Font.BOLD, 10))
            {
                Alignment = Element.ALIGN_CENTER,
            };
            doc.Add(cabecalho);
        }
        private static void InformacoesSobreTeste(Teste testeSelecionado, Document doc, Phrase label, Phrase conteudo)
        {
            label.Add("Título: ");
            conteudo.Add($"{testeSelecionado.Titulo}");
            AdicionaParagrafoAoPDF(doc, label, conteudo);

            label.Add("Disciplina: ");
            conteudo.Add($"{testeSelecionado.Disciplina}");
            AdicionaParagrafoAoPDF(doc, label, conteudo);

            label.Add("Matéria: ");
            if (testeSelecionado.Recuperacao)
                conteudo.Add($"Recuperação");
            else
                conteudo.Add($"{testeSelecionado.Materia}");
            AdicionaParagrafoAoPDF(doc, label, conteudo);
        }
        private static void InformacoesSobreQuestoes(Teste testeSelecionado, Document doc, Phrase label, Phrase conteudo)
        {
            int numQuestao = 1;

            foreach (Questao q in testeSelecionado.Questoes)
            {
                label.Add($"{numQuestao++}. {q}\n");

                foreach (Alternativa a in q.Alternativas)
                {
                    string[] alternativa = a.ToString().Split("-> ");
                    label.Add("    " + alternativa[0] + alternativa[1] + "\n");
                }

                AdicionaParagrafoAoPDF(doc, label, conteudo);
            }
        }
        private static void InformacoesSobreQuestoesComResposta(Teste testeSelecionado, Document doc, Phrase label, Phrase conteudo)
        {
            int numQuestao = 1;

            foreach (Questao q in testeSelecionado.Questoes)
            {
                label.Add($"{numQuestao++}. {q}\n");

                foreach (Alternativa a in q.Alternativas)
                {
                    string[] alternativa = a.ToString().Split("-> ");

                    if (a.Correta)
                        label.Add("    " + alternativa[0] + alternativa[1] + " -> RESPOSTA\n");
                    else
                        label.Add("    " + alternativa[0] + alternativa[1] + "\n");
                }

                AdicionaParagrafoAoPDF(doc, label, conteudo);
            }
        }
        #endregion
    }
}

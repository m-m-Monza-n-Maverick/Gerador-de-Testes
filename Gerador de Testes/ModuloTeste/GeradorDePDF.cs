using Gerador_de_Testes.ModuloQuestao;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class GeradorDePDF (string caminho, Teste testeSelecionado)
    {
        static Document doc = new(PageSize.A4);
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
        Phrase label = new("", new(iTextSharp.text.Font.NORMAL, 10));
        Phrase conteudo = new("", new((iTextSharp.text.Font.FontFamily)iTextSharp.text.Font.BOLD, 10));

        public void GerarPDF(bool gabarito)
        {
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();

            doc.Open();

            if (!gabarito) Cabecalho("TESTE");
            else Cabecalho("GABARITO DO TESTE");

            InformacoesSobreTeste();

            Cabecalho("\nQUESTÕES");

            if (!gabarito) InformacoesSobreQuestoes();
            else InformacoesSobreQuestoesComResposta();

            doc.Close();
        }

        private static void Cabecalho(string texto)
        {
            Paragraph cabecalho = new($"{texto}\n", new iTextSharp.text.Font((iTextSharp.text.Font.FontFamily)iTextSharp.text.Font.BOLD, 10))
            {
                Alignment = Element.ALIGN_CENTER,
            };
            doc.Add(cabecalho);
        }
        private void AdicionaParagrafoAoPDF()
        {
            conteudo.Add("\n");

            doc.Add(label);
            doc.Add(conteudo);

            label.Clear();
            conteudo.Clear();
        }
        private void InformacoesSobreTeste()
        {
            label.Add("Título: ");
            conteudo.Add($"{testeSelecionado.Titulo}");
            AdicionaParagrafoAoPDF();

            label.Add("Disciplina: ");
            conteudo.Add($"{testeSelecionado.Disciplina}");
            AdicionaParagrafoAoPDF();

            label.Add("Matéria: ");
            if (testeSelecionado.Recuperacao)
                conteudo.Add($"Recuperação");
            else
                conteudo.Add($"{testeSelecionado.Materia}");
            AdicionaParagrafoAoPDF();
        }
        private void InformacoesSobreQuestoes()
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

                AdicionaParagrafoAoPDF();
            }
        }
        private void InformacoesSobreQuestoesComResposta()
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

                AdicionaParagrafoAoPDF();
            }
        }
    }
}

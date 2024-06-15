using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TelaDetalhesTesteForm : Form
    {
        bool gerarPDF, gabarito;
        int numQuestao = 1;

        public Teste Teste
        {
            set
            {
                lblTitulo.Text = value.Titulo;
                lblDisciplina.Text = value.Disciplina.Nome;

                if (value.Recuperacao)
                    lblMateria.Text = "Recuperação";
                else
                    lblMateria.Text = value.Materia.ToString();

                foreach (Questao q in value.Questoes)
                {
                    listaQuestoes.Items.Add($"{numQuestao++}. {q}");
                    GerarPDF(q);
                }

                if (gerarPDF)
                    btnVoltar.Hide();
                else
                    btnPdfConcluido.Hide();
            }
        }

        public TelaDetalhesTesteForm(bool gerarPDF, bool gabarito)
        {
            InitializeComponent();
            this.gerarPDF = gerarPDF;
            this.gabarito = gabarito;
        }
        private void GerarPDF(Questao q)
        {
            if (gerarPDF)
            {
                foreach (Alternativa a in q.Alternativas)
                {
                    if (gabarito && a.Correta)
                        listaQuestoes.Items.Add("    " + a + "     -> Resposta");
                    else
                        listaQuestoes.Items.Add("    " + a);
                }

                listaQuestoes.Items.Add("\n");
            }
        }
    }
}

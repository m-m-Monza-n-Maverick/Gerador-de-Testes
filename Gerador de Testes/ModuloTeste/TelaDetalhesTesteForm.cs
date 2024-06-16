using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TelaDetalhesTesteForm : Form
    {
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
                    listaQuestoes.Items.Add($"{numQuestao++}. {q}");
            }
        }

        public TelaDetalhesTesteForm() => InitializeComponent();
    }
}

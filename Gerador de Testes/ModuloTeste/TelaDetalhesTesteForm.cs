using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TelaDetalhesTesteForm : Form
    {
        public Teste Teste
        {
            set
            {
                lblTitulo.Text = value.Titulo;
                lblDisciplina.Text = value.Disciplina.Nome;

                if (value.Recuperacao)
                    lblMateria.Text = "Recuperação";
                else
                    lblMateria.Text = value.Materia.Nome;

                foreach (Questao q in value.Questoes)
                    listaQuestoes.Items.Add(q);
            }
        }

        public TelaDetalhesTesteForm() => InitializeComponent();
    }
}

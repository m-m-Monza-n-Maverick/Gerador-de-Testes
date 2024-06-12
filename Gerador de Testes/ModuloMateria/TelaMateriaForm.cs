using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;

namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        public Materia Materia { get { return materia; } set { } }

        public TelaMateriaForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string serie = radio1.Text;

            //List<Disciplina> disciplinas = [];
            //foreach (Disciplina disciplina in List<Questao> disciplinas)
            //
            //List<Questao> questoes = [];
            //foreach (Disciplina questoes in list.Items)

            //materia = new Materia(nome, serie);
        }
    }
}

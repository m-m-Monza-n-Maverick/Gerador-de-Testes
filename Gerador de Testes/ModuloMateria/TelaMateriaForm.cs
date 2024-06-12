using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        //Ajustei a tela, de acordo com as configurações que eles pediram (posição inicial e bla bla bla)

        private Materia materia;
        public Materia Materia { get { return materia; } set { } }

        public TelaMateriaForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
        }

        public void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            //Mudei de "boxDisciplina" para "cmbDisciplina", pra ficar no padrão do Tiago
            cmbDisciplina.Items.Clear();

            foreach (Disciplina d in disciplinas)
                cmbDisciplina.Items.Add(d);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            //Troquei o nome dos botões -> de "radio1" para "radio1Serie"
            //Criei essa validação:
            string serie = "";

            if (radio1Serie.Checked) serie = "1ª série";
            if (radio2Serie.Checked) serie = "2ª série";

            //Para as disciplinas, olhar a linha: 26 do ControladorMateria

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            //Sobre a List<Questao>, olhar a linha: 12 de Materia

            materia = new Materia(nome, serie, disciplina);

            //Validação dos campos (linha 47):
            ValidarCampos(materia);
        }

        private void ValidarCampos(EntidadeBase entidade)
        {
            //Olhar linha 26 de Materia
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
            else DialogResult = DialogResult.OK;
        }
    }
}

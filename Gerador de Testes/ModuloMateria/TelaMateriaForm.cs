using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private List<Questao> questoes = [];
        public ContextoDados contexto;
        readonly int id = 0;

        public Materia Materia
        {
            get => materia;
            set
            {
                txtNome.Text = value.Nome;
                cmbDisciplina.SelectedItem = value.Disciplina;
                foreach (Questao q in value.Questoes) 
                    questoes.Add(q);

                if (value.Serie == "1ª série")
                    radio1Serie.Checked = true;
                else
                    radio2Serie.Checked = true;                
            }
        }
        private Materia materia;

        public TelaMateriaForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            this.contexto = contexto;
            this.id = id;
            CarregarDisciplinas();
        }

        public void CarregarDisciplinas()
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina diciplina in contexto.Disciplinas)
                cmbDisciplina.Items.Add(diciplina);
        }
        private void ValidarCampos()
        {
            List<string> erros = materia.Validar();

            //Validação requisitada
            //materia.ValidarNome(ref erros, contexto.Materias);

            //Validação que achamos que faz mais sentido:
            materia.ValidarMateriaJaExistente(ref erros, contexto.Materias, id);

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
            else DialogResult = DialogResult.OK;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            string serie = "";

            if (radio1Serie.Checked) serie = "1ª série";
            if (radio2Serie.Checked) serie = "2ª série";

            materia = new Materia(nome, serie, disciplina, questoes);

            ValidarCampos();
        }
    }
}

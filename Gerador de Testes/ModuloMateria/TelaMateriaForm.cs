using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private List<Questao> questoes = [];

        private Materia materia;
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
        public ContextoDados contexto;
        readonly int id = 0;

        public TelaMateriaForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            CarregarDisciplinas(contexto.Disciplinas);
            txtId.Text = id.ToString();
            this.contexto = contexto;
            this.id = id;
        }

        public void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina diciplina in disciplinas)
                cmbDisciplina.Items.Add(diciplina);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            string serie = "";

            if (radio1Serie.Checked) serie = "1ª série";
            if (radio2Serie.Checked) serie = "2ª série";

            //Validação requisitada
            //if (ValidarNome(nome)) return;

            //Validação que achamos que faz mais sentido:
            if (ValidarMateriaJaExistente(nome, disciplina, serie)) return;

            materia = new Materia(nome, serie, disciplina, questoes);

            ValidarCampos(materia);
        }

        private bool ValidarNome(string nome)
        {
            foreach (Materia materia in contexto.Materias)
                if (materia.Nome.Validation() == nome.Validation())
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(
                        $"Já existe uma matéria com o nome \"{nome.ToTitleCase().Trim()}\". Tente novamente.");

                    DialogResult = DialogResult.None;
                    return true;
                }

            return false;
        }
        private bool ValidarMateriaJaExistente(string nome, Disciplina disciplina, string serie)
        {
            foreach (Materia materia in contexto.Materias)
                if (materia.Nome.ToLower().Trim() == nome.ToLower().Trim())
                    if (materia.Disciplina == disciplina)
                        if (materia.Serie == serie)
                            if (materia.Id != id)
                            {
                                TelaPrincipalForm.Instancia.AtualizarRodape(
                                    $"Esta matéria já existe. Tente novamente.");

                                DialogResult = DialogResult.None;
                                return true;
                            }

            return false;
        }
        private void ValidarCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
            else DialogResult = DialogResult.OK;
        }

        private void cmbDisciplina_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;
        
    }
}

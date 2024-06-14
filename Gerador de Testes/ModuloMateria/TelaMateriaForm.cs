using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;

namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        public Materia Materia 
        { 
            get { return materia; } 
            set 
            {
                txtNome.Text = value.Nome;
                cmbDisciplina.SelectedItem = value.Disciplina;
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

            if (ValidarNome(nome)) return;

            string serie = "";

            if (radio1Serie.Checked) serie = "1ª série";
            if (radio2Serie.Checked) serie = "2ª série";

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            materia = new Materia(nome, serie, disciplina);

            ValidarCampos(materia, nome);
        }

        private bool ValidarNome(string nome)
        {
            foreach (Materia materia in contexto.Materias)
                if (materia.Nome == nome)
                    if (materia.Id != id)
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape(
                            $"Já existe uma matéria com o nome {nome.ToTitleCase()}. Tente novamente.");

                        DialogResult = DialogResult.None;
                        return true;
                    }

            return false;
        }
        private void ValidarCampos(EntidadeBase entidade, string nome)
        {
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

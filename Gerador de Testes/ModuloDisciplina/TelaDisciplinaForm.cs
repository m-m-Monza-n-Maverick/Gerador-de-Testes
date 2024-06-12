using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;
        public Disciplina Disciplina
        {
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
            }
            get => disciplina;
        }
        ContextoDados contexto;

        public TelaDisciplinaForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            this.contexto = contexto;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            disciplina = new(nome);

            List<string> erros = disciplina.Validar();

            if(contexto.Disciplinas.Exists(d => d.Nome == nome))
                erros.Add($"Já existe uma disciplina com o nome \"{nome.ToTitleCase()}\". Tente novamente.");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
    }
}

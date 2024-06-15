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
        readonly int id;

        public TelaDisciplinaForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            this.contexto = contexto;
            this.id = id;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            if (ValidarNomeJaExistente(nome)) return;

            disciplina = new(nome);

            ValidacaoDeCampos(disciplina);
        }

        private bool ValidarNomeJaExistente(string nome)
        {
            foreach (Disciplina d in contexto.Disciplinas)
                if (d.Nome.ToLower() == nome.ToLower())
                    if (d.Id != id)
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape(
                            $"Já existe uma disciplina com o nome \"{nome.ToTitleCase()}\". Tente novamente.");

                        DialogResult = DialogResult.None;
                        return true;
                    }

            return false;
        }
        private void ValidacaoDeCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
    }
}

using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
using System.Drawing.Drawing2D;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TelaTesteForm : Form
    {
        private Teste teste;
        public Teste Teste
        {
            get => teste;
            set
            {
            }
        }
        ContextoDados contexto;

        public TelaTesteForm(ContextoDados contexto)
        {
            InitializeComponent();
            this.contexto = contexto;

            CarregarDisciplinas();
        }

        public void CarregarDisciplinas()
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in contexto.Disciplinas)
                cmbDisciplina.Items.Add(disciplina);
        }
        public void CarregarMaterias(Disciplina disciplina)
        {
            cmbMateria.Items.Clear();

            if (disciplina == null) return;

            foreach (Materia materia in disciplina.Materias)
                cmbMateria.Items.Add(materia);
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            listaQuestoes.Items.Clear();

            Materia materia = (Materia)cmbMateria.SelectedItem;
            int qntQuestoes = Convert.ToInt32(txtQntQuestoes.Value);

            List<int> ids = [];
            foreach (Questao q in materia.Questoes)
                ids.Add(q.Id);

            Span<int> Ids = ids.ToArray();
            Random random = new();

            random.Shuffle<int>(Ids);

            int i = 0;
            foreach (int id in Ids)
                foreach (Questao q in materia.Questoes)
                    if (q.Id == id)
                    {
                        listaQuestoes.Items.Add(q);
                        i++;
                        if (i >= qntQuestoes) return;
                    }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            int qntQuestoes = Convert.ToInt32(txtQntQuestoes.Value);
            List<Questao> questoes = null;
            bool recuperacao = rdbRecuperacao.Checked;

            teste = new(titulo, disciplina, materia, qntQuestoes, questoes, recuperacao);

            ValidacaoDeCampos(teste, titulo);
        }



        private void cmbDisciplina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbMateria.Text = null;

            AlterarBotoes(false);
            listaQuestoes.Items.Clear();

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            CarregarMaterias(disciplina);
        }
        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AlterarBotoes(true);
            listaQuestoes.Items.Clear();

            Materia materia = (Materia)cmbMateria.SelectedItem;
            txtQntQuestoes.Maximum = materia.Questoes.Count;
        }
        private void AlterarBotoes(bool ativo)
        {
            btnSortear.Enabled = ativo;
            txtQntQuestoes.Enabled = ativo;
            txtQntQuestoes.Value = 1;
        }
        private void ValidacaoDeCampos(EntidadeBase entidade, string titulo)
        {
            List<string> erros = entidade.Validar();

            if (contexto.Testes.Exists(t => t.Titulo == titulo))
                erros.Add($"Já existe um teste com o título \"{titulo.ToTitleCase()}\". Tente novamente.");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
    }
}

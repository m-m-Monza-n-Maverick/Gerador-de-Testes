using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TelaTesteForm : Form
    {
        private Teste teste = new();
        public Teste Teste
        {
            set
            {
                txtTitulo.Text = value.Titulo;

                cmbDisciplina.SelectedItem = value.Disciplina;

                rdbRecuperacao.Enabled = true;
                rdbRecuperacao.Checked = value.Recuperacao;
                rdbRecuperacao.Checked = true;

                CarregarMaterias();
                cmbMateria.SelectedItem = value.Materia;

                txtQntQuestoes.Enabled = true;
                txtQntQuestoes.Value = value.QntQuestoes;
            }
            get => teste;
        }
        ContextoDados contexto;

        public TelaTesteForm(ContextoDados contexto)
        {
            InitializeComponent();
            this.contexto = contexto;

            CarregarDisciplinas();
        }

        #region Disciplinas
        public void CarregarDisciplinas()
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in contexto.Disciplinas)
                cmbDisciplina.Items.Add(disciplina);
        }
        private void cmbDisciplina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplina.SelectedItem;

            if (DisciplinaSemMaterias(disciplinaSelecionada)) return;
            if (disciplinaSelecionada == teste.Disciplina) return;

            teste.Disciplina = disciplinaSelecionada;
            teste.Materia = null;

            cmbMateria.SelectedItem = null;
            rdbRecuperacao.Enabled = true;

            CarregarMaterias();

            ResetarInformações();

            if (!rdbRecuperacao.Checked) ConfigurarCampos(false);
        }
        #endregion

        #region Matérias
        public void CarregarMaterias()
        {
            cmbMateria.Items.Clear();

            foreach (Materia materia in ((Disciplina)cmbDisciplina.SelectedItem).Materias)
                cmbMateria.Items.Add(materia);
        }
        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Materia materiaSelecionada = (Materia)cmbMateria.SelectedItem;

            if (materiaSelecionada == teste.Materia) return;

            teste.Materia = materiaSelecionada;

            ResetarInformações();
            ConfigurarCampos(true);
        }
        #endregion

        #region Demais botões
        private void rdbRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            ResetarInformações();

            if (!rdbRecuperacao.Checked)
            {
                cmbMateria.Enabled = true;

                ConfigurarCampos(false);
                return;
            }

            cmbMateria.Enabled = false;
            cmbMateria.SelectedItem = null;

            ConfigurarCampos(true);
        }
        private void txtQntQuestoes_ValueChanged(object sender, EventArgs e)
        {
            int qntQuestoesDisponiveis = 0;

            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplina.SelectedItem;
            Materia materiaSelecionada = (Materia)cmbMateria.SelectedItem;


            if (rdbRecuperacao.Checked)
                foreach (Materia m in disciplinaSelecionada.Materias)
                    qntQuestoesDisponiveis += m.Questoes.Count;
            else
                if (materiaSelecionada != null)
                qntQuestoesDisponiveis = materiaSelecionada.Questoes.Count;


            if (qntQuestoesDisponiveis == 0) 
                txtQntQuestoes.Maximum = 1;
            else 
                txtQntQuestoes.Maximum = qntQuestoesDisponiveis;

            teste.QntQuestoes = (int)txtQntQuestoes.Value;
        }
        private void btnSortear_Click(object sender, EventArgs e)
        {
            listaQuestoes.Items.Clear();

            AvisoParaAumentarQnt();

            List<Materia> materias = materiasParaSorteio();

            Random random = new();

            Span<int> IdsSorteados = idsParaSorteio(materias).ToArray();

            random.Shuffle<int>(IdsSorteados);

            Sortear(materias, IdsSorteados);
        }
        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;

            if (ValidarTitulo(titulo)) return;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            int qntQuestoes = Convert.ToInt32(txtQntQuestoes.Value);
            List<Questao> questoes = [];

            foreach (Questao q in listaQuestoes.Items)
                questoes.Add(q);

            bool recuperacao = rdbRecuperacao.Checked;

            teste = new(titulo, disciplina, materia, qntQuestoes, questoes, recuperacao);

            ValidacaoDeCampos(teste, titulo);
        }
        #endregion

        #region Auxiliares
        private bool DisciplinaSemMaterias(Disciplina disciplinaSelecionada)
        {
            if (disciplinaSelecionada.Materias.Count == 0)
            {
                MessageBox.Show(
                    "Esta disciplina não possui matérias cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                if (teste != null) cmbDisciplina.SelectedItem = teste.Disciplina;
                return true;
            }
            return false;
        }
        private void ResetarInformações()
        {
            txtQntQuestoes.Value = 0;
            listaQuestoes.Items.Clear();
        }
        private void ConfigurarCampos(bool ativo)
        {
            btnSortear.Enabled = ativo;
            txtQntQuestoes.Enabled = ativo;
        }
        private void AvisoParaAumentarQnt()
        {
            if (txtQntQuestoes.Value == 0)
                lblAvisoAumentarQnt.Text = "Aumente a qnt.de questões";
            else
                lblAvisoAumentarQnt.Text = null;
        }
        private List<Materia> materiasParaSorteio()
        {
            List<Materia> materias;
            if (rdbRecuperacao.Checked)
                materias = teste.Disciplina.Materias;
            else
                materias = [teste.Materia];
            return materias;
        }
        private static List<int> idsParaSorteio(List<Materia> materias)
        {
            List<int> idsDasQuestoes = [];

            foreach (Materia m in materias)
                foreach (Questao q in m.Questoes)
                    idsDasQuestoes.Add(q.Id);

            return idsDasQuestoes;
        }
        private void Sortear(List<Materia> materias, Span<int> IdsSorteados)
        {
            int i = 0;
            foreach (int id in IdsSorteados)
                foreach (Materia m in materias)
                    foreach (Questao q in m.Questoes)
                        if (q.Id == id)
                        {
                            if (i >= teste.QntQuestoes) return;
                            listaQuestoes.Items.Add(q);
                            i++;
                        }
        }
        private bool ValidarTitulo(string titulo)
        {
            if (contexto.Testes.Exists(t => t.Titulo == titulo))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(
                    $"Já existe um teste com o título \"{titulo.ToTitleCase()}\". Tente novamente.");

                DialogResult = DialogResult.None;
                return true;
            }

            return false;
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
        #endregion
    }
}

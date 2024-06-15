using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        List<string> alternativasCadastradas = [];
        ContextoDados contexto;
        private int countAlternativas = 0;
        public char letra = 'A';
        int id;

        private Questao questao;
        public Questao Questao
        {
            get { return questao; } 
            set
            {
                CarregarMaterias(contexto.Materias);
                txtId.Text = value.Id.ToString();
                txtEnunciado.Text = value.Enunciado;
                cmbMateria.SelectedItem = value.Materia;
                foreach (Alternativa alternativa in value.Alternativas)
                {
                    alternativasCadastradas.Add(alternativa.Resposta);

                    alternativa.Letra = letra;

                    listBox.Items.Add(alternativa);
                    letra++;
                    countAlternativas++;
                }
            }
        }

        public TelaQuestaoForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            this.id = id;
            this.contexto = contexto;
        }

        public void CarregarMaterias(List<Materia> materias)
        {
            cmbMateria.Items.Clear();

            foreach (Materia materia in materias)
                cmbMateria.Items.Add(materia);
        }

        #region Botões
        public void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (AlternativaVazia() || LimiteMaxDeAlternativas() || AlternativaJaCadastrada()) return;

            string resposta = txtResposta.Text;

            Alternativa alternativa = new(letra, resposta, false);

            listBox.Items.Add(alternativa);
            letra++;
            countAlternativas++;
            txtResposta.Text = "";
            alternativasCadastradas.Add(resposta);
        }
        public void btnRemover_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;

            listBox.Items.Remove(listBox.SelectedItem);
            countAlternativas--;

            letra = 'A';

            List<Alternativa> listaDeItens = [];
            foreach (Alternativa alternativa in listBox.Items)
                listaDeItens.Add(alternativa);

            listBox.Items.Clear();
            foreach (Alternativa alternativa in listaDeItens)
            {
                alternativa.Letra = letra;

                listBox.Items.Add(alternativa);
                letra++;
            }
        }
        public void btnGravar_Click(object sender, EventArgs e)
        {

            string enunciado = txtEnunciado.Text;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            string resposta = null;
            List<Alternativa> alternativas = CadastrarAlternativas(ref resposta);

            ValidarQuestaoJaExistente(materia, enunciado);

            questao = new(enunciado, materia, alternativas, resposta);

            #region Validacoes

            List<string> erros = questao.Validar();

            if (cmbMateria.SelectedItem == null)
                erros.Add($"Selecione uma matéria");
            if (countAlternativas < 2)
                erros.Add($"O numero mínimo de alternativas é 2");
            if (listBox.CheckedItems.Count == 0)
                erros.Add($"Selecione a resposta correta");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
            #endregion
        }

        #endregion

        #region Auxiliares
        private bool AlternativaVazia() => txtResposta.Text == "";
        private bool LimiteMaxDeAlternativas()
        {
            if (countAlternativas > 4)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Você atingiu o número máximo de alternativas cadastradas");
                return true;
            }
            return false;
        }
        private bool AlternativaJaCadastrada()
        {
            if (alternativasCadastradas.Contains(txtResposta.Text))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Alternativa já cadastrada. Tente novamente");
                return true;
            }
            return false;
        }
        private void CheckItemCorreto(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                Alternativa alternativa = (Alternativa)listBox.Items[i];
                if (alternativa.Correta)
                {
                    listBox.SetItemChecked(i, true);
                    break;
                }
            }
        }
        public void OnlyOne_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Desmarca todos os outros itens
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        listBox.SetItemChecked(i, false);
                    }
                }
            }
        }
        private List<Alternativa> CadastrarAlternativas(ref string resposta)
        {
            List<Alternativa> alternativas = new();

            foreach (Alternativa alternativa in listBox.Items)
                alternativas.Add(alternativa);

            foreach (Alternativa alternativa in alternativas)
            {
                if (listBox.CheckedItems.Contains(alternativa))
                {
                    alternativa.Correta = true;
                    resposta = alternativa.ToString();
                }
                else alternativa.Correta = false;
            }

            return alternativas;
        }
        private bool ValidarQuestaoJaExistente(Materia materia, string enunciado)
        {
            foreach (Questao questao in contexto.Questoes)
                if (questao.Materia == materia)
                    if (questao.Enunciado == enunciado)
                        if (questao.Id != id)
                        {
                            TelaPrincipalForm.Instancia.AtualizarRodape(
                                $"Esta questão já existe. Tente novamente.");

                            DialogResult = DialogResult.None;
                            return true;
                        }

            return false;
        }
        public void VisualizarMode()
        {
            txtEnunciado.Enabled = false;
            txtResposta.Enabled = false;
            listBox.Enabled = false;
            listBox.Dock = DockStyle.Fill;
            listBox.BackColor = Color.FromArgb(240, 240, 240);
            cmbMateria.Enabled = false;
            lblResposta.Visible = false;
            txtResposta.Visible = false;
            btnAdicionar.Visible = false;
            btnRemoverlist.Visible = false;
            btnGravar.Visible = false;
            btnCancelar.Text = "Voltar";
        }
        #endregion
    }
}

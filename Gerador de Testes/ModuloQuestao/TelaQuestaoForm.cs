using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        List<string> alternativasCadastradas = [];
        ContextoDados contexto;
        public char letra = 'A';
        readonly int id;

        public Questao Questao
        {
            get => questao;
            set
            {
                CarregarMaterias();
                txtId.Text = value.Id.ToString();
                txtEnunciado.Text = value.Enunciado;
                cmbMateria.SelectedItem = value.Materia;
                foreach (Alternativa alternativa in value.Alternativas)
                {
                    alternativasCadastradas.Add(alternativa.Resposta);

                    alternativa.Letra = letra++;

                    listBox.Items.Add(alternativa);
                }
            }
        }
        private Questao questao;

        public TelaQuestaoForm(int id, ContextoDados contexto)
        {
            InitializeComponent();
            CarregarMaterias();
            txtId.Text = id.ToString();
            this.id = id;
            this.contexto = contexto;
        }

        public void CarregarMaterias()
        {
            cmbMateria.Items.Clear();

            foreach (Materia materia in contexto.Materias)
                cmbMateria.Items.Add(materia);
        }

        #region Botões
        public void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (AlternativaVazia() || LimiteMaxDeAlternativas() || AlternativaJaCadastrada()) return;

            string resposta = txtResposta.Text.Trim();

            Alternativa alternativa = new(letra, resposta, false);

            letra++;
            txtResposta.Text = null;
            listBox.Items.Add(alternativa);
            alternativasCadastradas.Add(resposta);
        }
        public void btnRemover_Click(object sender, EventArgs e)
        {
            Alternativa alternativaSelecionada = (Alternativa)listBox.SelectedItem;

            if (alternativaSelecionada == null) return;

            alternativasCadastradas.Remove(alternativaSelecionada.Resposta);
            listBox.Items.Remove(alternativaSelecionada);

            List<Alternativa> listaDeItens = ListarAlternativas();

            listBox.Items.Clear();
            ReorganizarListaDeAlternativas(listaDeItens);
        }
        public void btnGravar_Click(object sender, EventArgs e)
        {
            string enunciado = txtEnunciado.Text;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            string resposta = null;
            List<Alternativa> alternativas = CadastrarAlternativas(ref resposta);

            questao = new(enunciado, materia, alternativas, resposta);

            ValidarCampos();
        }
        #endregion

        #region Auxiliares
        private bool AlternativaVazia() 
            => string.IsNullOrEmpty(txtResposta.Text.Trim());
        private bool LimiteMaxDeAlternativas()
        {
            if (alternativasCadastradas.Count >= 4)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Você atingiu o número máximo de alternativas cadastradas");
                return true;
            }
            return false;
        }
        private bool AlternativaJaCadastrada()
        {
            if (alternativasCadastradas.Contains(txtResposta.Text.Trim()))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Alternativa já cadastrada. Tente novamente");
                return true;
            }
            return false;
        }
        private void CheckItemCorreto(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Alternativa a in listBox.Items)
            {
                if (a.Correta)
                {
                    listBox.SetItemChecked(i, true);
                    break;
                }
                i++;
            }
        }
        private List<Alternativa> CadastrarAlternativas(ref string resposta)
        {
            List<Alternativa> alternativas = new();

            foreach (Alternativa a in listBox.Items)
                alternativas.Add(a);

            foreach (Alternativa a in alternativas)
            {
                if (listBox.CheckedItems.Contains(a))
                {
                    a.Correta = true;
                    resposta = a.ToString();
                }
                else a.Correta = false;
            }

            return alternativas;
        }
        private List<Alternativa> ListarAlternativas()
        {
            List<Alternativa> listaDeItens = [];

            foreach (Alternativa a in listBox.Items)
                listaDeItens.Add(a);

            return listaDeItens;
        }
        private void ReorganizarListaDeAlternativas(List<Alternativa> listaDeItens)
        {
            letra = 'A';
            foreach (Alternativa a in listaDeItens)
            {
                a.Letra = letra++;
                listBox.Items.Add(a);
            }
        }

        private void ValidarCampos()
        {
            List<string> erros = questao.Validar();

            questao.ValidarQuestaoJaExistente(ref erros, contexto.Questoes, id);

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
        public void ModoVisualizacao()
        {
            txtEnunciado.Enabled = false;
            txtResposta.Enabled = false;
            listBox.Enabled = false;
            listBox.Dock = DockStyle.Fill;
            listBox.BackColor = Color.FromArgb(240, 240, 240);
            cmbMateria.Enabled = false;
            cmbMateria.DropDownStyle = ComboBoxStyle.Simple;
            lblResposta.Visible = false;
            txtResposta.Visible = false;
            btnAdicionar.Visible = false;
            btnRemoverlist.Visible = false;
            btnGravar.Visible = false;
            btnCancelar.Text = "Voltar";
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
        #endregion
    }
}

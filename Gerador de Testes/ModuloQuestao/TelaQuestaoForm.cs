using Gerador_de_Testes.ModuloMateria;
using System.Reflection.Metadata.Ecma335;

namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        List<string> alternativasCadastradas = [];

        private Questao questao;
        public Questao Questao
        {
            get { return questao; } 
            set
            {
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
        public TelaQuestaoForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
        }

        private int countAlternativas = 0;
        public char letra = 'A';

        #region Botões
        public void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (AlternativaVazia() || LimiteMaxDeAlternativas() || AlternativaJaCadastrada()) return;

            string resposta = txtResposta.Text;

            Alternativa alternativa = new Alternativa(letra, resposta, false);

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

            List<Alternativa> alternativas = new();

            foreach (Alternativa alternativa in listBox.Items)            
                alternativas.Add(alternativa);
            
            foreach (Alternativa alternativa in alternativas)
            {
                if (listBox.CheckedItems.Contains(alternativa))
                {
                    alternativa.Correta = true;
                    resposta = alternativa.Resposta;
                }
                else alternativa.Correta = false;
            }
            questao = new(enunciado, materia, alternativas, resposta);

            #region Validacoes

            List<string> erros = questao.Validar();
            
            //if (cmbMateria.SelectedItem == null)
            //    erros.Add($"Selecione uma meteria");
            if (countAlternativas < 2)
                erros.Add($"O numero minimo de alternativas é 2");
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
        public void CarregarMaterias(List<Materia> materias)
        {
            cmbMateria.Items.Clear();

            foreach (Materia materia in materias)
                cmbMateria.Items.Add(materia);
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

using Gerador_de_Testes.ModuloMateria;

namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
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
            if (txtResposta.Text == "") return;
            if (countAlternativas > 4) return;

            string resposta = txtResposta.Text;
            bool correta = false;

            Alternativa alternativa = new Alternativa(letra, resposta, correta);

            listBox.Items.Add(alternativa);
            letra++;
            countAlternativas++;
            txtResposta.Text = "";
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

            List<Alternativa> alternativas = new();

            foreach (Alternativa alternativa in listBox.Items)            
                alternativas.Add(alternativa);
            
            foreach (Alternativa alternativa in alternativas)
            {
                if (listBox.CheckedItems.Contains(alternativa))
                    alternativa.Correta = true;
                else alternativa.Correta = false;
            }
            questao = new(enunciado, materia, alternativas);

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
        public void VizualizarMode()
        {
            txtEnunciado.Enabled = false;
            txtResposta.Enabled = false;
            listBox.Enabled = false;
            listBox.Dock = DockStyle.Fill;
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

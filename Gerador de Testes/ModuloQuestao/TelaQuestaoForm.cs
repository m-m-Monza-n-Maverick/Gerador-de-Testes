using Gerador_de_Testes.ModuloMateria;

namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        public Questao Questao
        {
            get => questao;
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

        public void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
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

        private void btnAdicionar_Click(object sender, EventArgs e)
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
        private void btnRemoverlist_Click(object sender, EventArgs e)
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
            if (txtEnunciado.Text == null) return;
            //if (cmbMateria.SelectedItem == null) return;
            if (countAlternativas < 2) return;
                
            string enunciado = txtEnunciado.Text;

            Materia materia = (Materia)cmbMateria.SelectedItem;

            List<Alternativa> alternativas = new();

            foreach (Alternativa alternativa in listBox.Items)
            {
                if (alternativa == listBox.SelectedItem)
                    alternativa.Correta = true;
                alternativas.Add(alternativa);
            }
            
            questao = new Questao(enunciado, materia, alternativas);
        }

        

        
    }
}

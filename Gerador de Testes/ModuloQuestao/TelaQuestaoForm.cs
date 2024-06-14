using Gerador_de_Testes.ModuloMateria;
using System.Windows.Forms;

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
                    if (alternativa.Correta)
                         

                    alternativa.Letra = letra;

                    listBox.Items.Add(alternativa);
                    letra++;
                }
            }
        }
        public TelaQuestaoForm(int id)
        {
            InitializeComponent();
            listBox.HandleCreated += new EventHandler(CheckedListBox_HandleCreated);
            
            txtId.Text = id.ToString();
        }

        private int countAlternativas = 0;
        public char letra = 'A';

        private void CheckedListBox_HandleCreated(object sender, EventArgs e)
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
                alternativas.Add(alternativa);
            
            foreach (Alternativa alternativa in alternativas)
            {
                if (listBox.CheckedItems.Contains(alternativa))
                    alternativa.Correta = true;
            }

            questao = new Questao(enunciado, materia, alternativas);
        }

        

        
    }
}

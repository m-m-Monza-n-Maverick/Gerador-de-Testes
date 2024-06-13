using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Testes.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        public Questao Questao { get { return questao; } set { } }
        public TelaQuestaoForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
        }
        int countAlternativas = 0;
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtResposta.Text == "") return;
            if (countAlternativas > 4) return;

            listBox.Items.Add(txtResposta.Text);
            countAlternativas++;
            txtResposta.Text = "";
        }
        private void btnRemoverlist_Click(object sender, EventArgs e)
        {
            List<object> itemsToRemove = new List<object>();

            foreach (object selectedItem in listBox.SelectedItems)
            {
                itemsToRemove.Add(selectedItem);
            }

            foreach (object item in itemsToRemove)
            {
                listBox.Items.Remove(item);
            }
            countAlternativas--;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string enunciado = txtEnunciado.Text;
            string resposta = txtResposta.Text;

            List<string[]> alternativas = [];

            foreach (string[] alternativa in listBox.Items)
                alternativas.Add(alternativa);

            questao = new Questao(enunciado, resposta, alternativas);
        }
    }
}

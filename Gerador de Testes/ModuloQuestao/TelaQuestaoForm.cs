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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtResposta.Text == null) return;

            listBox.Items.Add(txtResposta.Text);
            txtResposta.Text = "";
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

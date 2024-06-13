using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();
            string materiaOuRecuperacao;

            foreach (Teste t in testes)
            {
                if (t.Recuperacao) materiaOuRecuperacao = "Recuperação";
                else materiaOuRecuperacao = t.Materia.Nome;
                 
                grid.Rows.Add(t.Id, t, t.Disciplina, materiaOuRecuperacao, t.QntQuestoes);
            }
        }
        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private DataGridViewColumn[] ObterColunas()
        {
            return
            [
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria" },
                new DataGridViewTextBoxColumn { DataPropertyName = "QntQuestoes", HeaderText = "Nº de questões" },
            ];
        }
    }
}

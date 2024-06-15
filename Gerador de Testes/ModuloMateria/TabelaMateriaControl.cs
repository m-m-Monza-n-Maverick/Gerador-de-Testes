using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        internal void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (Materia materia in materias) 
                grid.Rows.Add(materia.Id, materia.Nome.ToTitleCase(), materia.Disciplina, materia.Serie);
        }
        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private static DataGridViewTextBoxColumn[] ObterColunas()
        {
            return 
            [
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Série" },
            ];
        }
    }
}

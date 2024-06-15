using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloMateria
{
    internal class ControladorMateria (IRepositorioMateria repositorioMateria, ContextoDados contexto) : ControladorBase
    {
        private IRepositorioMateria repositorioMateria = repositorioMateria;
        private TabelaMateriaControl tabelaMateria;

        #region ToolTips
        public override string TipoCadastro => "Matéria";
        public override string ToolTipAdicionar => "Adicionar matéria";
        public override string ToolTipEditar => "Editar matéria";
        public override string ToolTipExcluir => "Excluir matéria";
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            if (SemDisciplinas()) return;

            int id = repositorioMateria.PegarId();

            TelaMateriaForm telaMateria = new(id, contexto);

            CarregarDisciplinas(telaMateria);

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Materia novaMateria = telaMateria.Materia;

            repositorioMateria.Cadastrar(novaMateria);
            
            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaMateria.Nome}\" foi cadastrado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            TelaMateriaForm telaMateria = new(idSelecionado, contexto);

            Materia materiaSelecionada =
                repositorioMateria.SelecionarPorId(idSelecionado);

            if (SemSeleção(materiaSelecionada)) return;

            telaMateria.Materia = materiaSelecionada;

            DialogResult resultado = telaMateria.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Materia MateriaEditada = telaMateria.Materia;

            repositorioMateria.Editar(idSelecionado, MateriaEditada);

            CarregarMaterias(); 

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{MateriaEditada.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada = 
                repositorioMateria.SelecionarPorId(idSelecionado);

            if (SemSeleção(materiaSelecionada) || !DesejaRealmenteExcluir(materiaSelecionada)) return;

            repositorioMateria.Excluir(idSelecionado);

            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{materiaSelecionada.Nome}\" foi excluído com sucesso!");
        }
        #endregion

        #region Auxiliares 
        public override UserControl ObterListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }
        private bool SemDisciplinas()
        {
            if (contexto.Disciplinas.Count == 0)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem Disciplinas cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
        private void CarregarMaterias()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(Materias);
        }
        private void CarregarDisciplinas(TelaMateriaForm telaMateria)
        {
            List<Disciplina> disciplinasCadastradas = contexto.Disciplinas;

            telaMateria.CarregarDisciplinas(disciplinasCadastradas);
        }
        #endregion
    }
}

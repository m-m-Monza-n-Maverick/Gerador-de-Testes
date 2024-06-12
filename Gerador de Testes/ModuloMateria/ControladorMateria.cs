using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloMateria
{
    internal class ControladorMateria (RepositorioMateria repositorioMateria) : ControladorBase
    {
        private RepositorioMateria repositorioMateria = repositorioMateria;
        private TabelaMateriaControl tabelaMateria;

        #region ToolTips
        public override string TipoCadastro => "Materia";
        public override string ToolTipAdicionar => "Adicionar nova materia";
        public override string ToolTipEditar => "Editar uma materia existente";
        public override string ToolTipExcluir => "Excluir uma materia existente";
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            int id = repositorioMateria.PegarId();

            TelaMateriaForm telaMateria = new(id);

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Materia novaMateria = telaMateria.Materia;

            repositorioMateria.Cadastrar(novaMateria);
            
            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaMateria.Nome}\" foi excluído com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            TelaMateriaForm telaMateria = new(idSelecionado);

            Materia materiaSelecionada =
                repositorioMateria.SelecionarPorId(idSelecionado);

            if(materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            telaMateria.Materia = materiaSelecionada;

            DialogResult resultado = telaMateria.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Materia MateriaEditada = telaMateria.Materia;

            repositorioMateria.Editar(idSelecionado, MateriaEditada);

            CarregarMaterias(); 

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{MateriaEditada.Nome}\" foi excluído com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada = 
                repositorioMateria.SelecionarPorId(idSelecionado);

            if (materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            repositorioMateria.Excluir(materiaSelecionada.Id);

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
        
        private void CarregarMaterias()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(Materias);
        }
        #endregion
    }
}

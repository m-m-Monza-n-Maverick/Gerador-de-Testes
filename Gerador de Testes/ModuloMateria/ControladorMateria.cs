using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloMateria
{
    public class ControladorMateria (IRepositorioMateria repositorioMateria, ContextoDados contexto) : ControladorBase
    {
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
            if (SemDependenciasCadastradas(contexto.Disciplinas.Count, "Disciplinas")) return;

            int id = repositorioMateria.PegarId();

            TelaMateriaForm telaMateria = new(id, contexto);

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Materia novaMateria = telaMateria.Materia;

            novaMateria.AdicionarMateriaEmDisciplina(id, contexto.Disciplinas);

            RealizarAcao(
                () => repositorioMateria.Cadastrar(novaMateria), 
                novaMateria, "cadastrado");
        }
        public override void Editar()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            TelaMateriaForm telaMateria = new(idSelecionado, contexto);

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(idSelecionado);

            if (SemSeleção(materiaSelecionada)) return;

            telaMateria.Materia = materiaSelecionada;

            DialogResult resultado = telaMateria.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Materia materiaEditada = telaMateria.Materia;

            materiaEditada.Questoes = materiaSelecionada.Questoes;

            materiaSelecionada.RemoverMateriaEmDisciplina(contexto.Disciplinas);

            materiaEditada.AdicionarMateriaEmDisciplina(idSelecionado, contexto.Disciplinas);

            RealizarAcao(
                () => repositorioMateria.Editar(idSelecionado, materiaEditada), 
                materiaEditada, "editada");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada =
                repositorioMateria.SelecionarPorId(idSelecionado);

            if (SemSeleção(materiaSelecionada) || !DesejaRealmenteExcluir(materiaSelecionada)) return;

            materiaSelecionada.RemoverMateriaEmDisciplina(contexto.Disciplinas);

            RealizarAcao(
                () => repositorioMateria.Excluir(idSelecionado), 
                materiaSelecionada, "excluído");
        }
        #endregion

        #region Auxiliares 
        public override UserControl ObterListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarRegistros();

            return tabelaMateria;
        }
        protected override void CarregarRegistros()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(Materias);
        }
        #endregion
    }
}

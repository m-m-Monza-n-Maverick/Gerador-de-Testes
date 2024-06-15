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

            RealizarAcao(
                () => repositorioMateria.Cadastrar(novaMateria), 
                novaMateria, "cadastrado");

            AtualizaDisciplina(contexto, novaMateria);
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

            Materia materiaEditada = telaMateria.Materia;

            AtualizarDisciplina(contexto, materiaSelecionada, materiaEditada);

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

            AtualizarDisciplina(contexto, ref materiaSelecionada);

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
        private void AtualizaDisciplina(ContextoDados contexto, Materia novaMateria)
        {
            foreach (Disciplina d in contexto.Disciplinas)
                if (d == novaMateria.Disciplina)
                    d.Materias.Add(novaMateria);
        }
        private void AtualizarDisciplina(ContextoDados contexto, Materia materiaSelecionada, Materia materiaEditada)
        {
            if (materiaSelecionada.Disciplina != materiaEditada.Disciplina)
            {
                foreach (Disciplina d in contexto.Disciplinas)
                {
                    if (d == materiaSelecionada.Disciplina)
                    {
                        foreach (Materia m in d.Materias)
                            if (m.Nome == materiaSelecionada.Nome)
                                materiaSelecionada = m;

                        d.Materias.Remove(materiaSelecionada);
                    }

                    if (d == materiaEditada.Disciplina)
                        d.Materias.Add(materiaEditada);
                }
            }
        }
        private void AtualizarDisciplina(ContextoDados contexto, ref Materia materiaSelecionada)
        {
            foreach (Disciplina d in contexto.Disciplinas)
            {
                foreach (Materia m in d.Materias)
                    if (m.Nome == materiaSelecionada.Nome)
                        materiaSelecionada = m;

                d.Materias.Remove(materiaSelecionada);
            }
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
        private void RealizarAcao(Action acao, Materia materia, string texto)
        {
            acao();
            CarregarMaterias();
            CarregarMensagem(materia, texto);
        }
        #endregion
    }
}

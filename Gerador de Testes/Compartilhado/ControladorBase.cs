namespace Gerador_de_Testes.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string TipoCadastro { get; }

        #region ToolTips
        public abstract string ToolTipAdicionar { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }
        #endregion

        #region CRUD
        public abstract void Adicionar();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract UserControl ObterListagem();
        #endregion

        #region Auxiliares
        public bool SemSeleção(EntidadeBase entidadeSelecionada)
        {
            if (entidadeSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
        public bool DesejaRealmenteExcluir(EntidadeBase entidadeSelecionada)
        {
            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{entidadeSelecionada}\"?",
                $"Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes) return false;
            return true;
        }
        //public override void ExibirDetalhes()
        //{ }
        #endregion
    }
}

using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloDisciplina
{
    internal class RepositorioDisciplina : RepositorioBaseEmArquivo<Disciplina>, IRepositorioDisciplina
    {
        public RepositorioDisciplina(ContextoDados contexto) : base(contexto) { }

        protected override List<Disciplina> ObterRegistros() => contexto.Disciplinas;
        public override bool Excluir(int id)
        {
            if (contexto.Materias.Exists(m => m.Disciplina.Id == id))
            {
                MessageBox.Show(
                    "Registro sendo utilizado por uma Matéria.\nNão é possível excluir!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            if (contexto.Testes.Exists(t => t.Disciplina.Id == id))
            {
                MessageBox.Show(
                    "Registro sendo utilizado por um Teste.\nNão é possível excluir!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            return base.Excluir(id);
        }
    }
}

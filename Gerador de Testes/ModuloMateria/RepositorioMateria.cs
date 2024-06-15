using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloMateria
{
    internal class RepositorioMateria : RepositorioBaseEmArquivo<Materia>, IRepositorioMateria
    {
        public RepositorioMateria(ContextoDados contexto) : base(contexto) { }
        
        protected override List<Materia> ObterRegistros()
        {
            return contexto.Materias;
        }

        public override bool Excluir(int id)
        {
            if (contexto.Questoes.Exists(q => q.Materia == SelecionarPorId(id)))
            {
                MessageBox.Show(
                    "Registro sendo utilizado por uma Questão.\nNão é possível excluir!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }
            return base.Excluir(id);
        }
    }
}

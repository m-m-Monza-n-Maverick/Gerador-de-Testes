using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloMateria
{
    internal class RepositorioMateria : RepositorioBaseEmArquivo<Materia>
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
                    "Não é possível excluir este registro, pois ele está sendo utilizado por uma questão",
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

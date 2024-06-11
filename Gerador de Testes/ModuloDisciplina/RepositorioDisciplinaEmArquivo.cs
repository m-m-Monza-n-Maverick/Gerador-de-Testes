using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloDisciplina
{
    internal class RepositorioDisciplinaEmArquivo : RepositorioBaseEmArquivo<Disciplina>, IRepositorioDisciplina
    {
        public RepositorioDisciplinaEmArquivo(ContextoDados contexto) : base(contexto) { }


        protected override List<Disciplina> ObterRegistros() => contexto.Disciplinas;
        public override bool Excluir(int id)
        {
            if (contexto.Materias.Exists(m => m.Disciplina.Id == id)) return false;
            //if (contexto.Testes.Exists(t => t.Disciplina.Id == id)) return false;
            return base.Excluir(id);
        }
    }
}

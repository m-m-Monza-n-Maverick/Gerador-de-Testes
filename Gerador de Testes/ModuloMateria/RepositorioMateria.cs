using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloMateria
{
    internal class RepositorioMateria : RepositorioBaseEmArquivo<Materia>
    {
        public RepositorioMateria(ContextoDados contexto) : base(contexto) 
        { 
        }
        
        protected override List<Materia> ObterRegistros()
        {
            return new List<Materia>() { };
        }
    }
}

using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class RepositorioTesteEmArquivo : RepositorioBaseEmArquivo<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(ContextoDados contexto) : base(contexto) { }

        protected override List<Teste> ObterRegistros() => contexto.Testes;
    }

}

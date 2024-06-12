using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloQuestao
{
    internal class RepositorioQuestao : RepositorioBaseEmArquivo<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ContextoDados contexto) : base(contexto) 
        { 
        }
        protected override List<Questao> ObterRegistros() => contexto.Questoes;
    }
}

using Gerador_de_Testes.Compartilhado;

namespace Gerador_de_Testes.ModuloQuestao
{
    public interface IRepositorioQuestao
    {
        void Cadastrar(Questao novaQuestao);
        bool Editar(int id, Questao questaoEditada);
        bool Excluir(int id);
        int PegarId();
        Questao SelecionarPorId(int idSelecionado);
        List<Questao> SelecionarTodos();
    }
}

using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloTeste
{
    public interface IRepositorioTeste
    {
        void Cadastrar(Teste novoTeste);
        bool Editar(int id, Teste testeEditada);
        bool Excluir(int id);


        Teste SelecionarPorId(int idSelecionado);
        List<Teste> SelecionarTodos();
        int PegarId();
    }
}

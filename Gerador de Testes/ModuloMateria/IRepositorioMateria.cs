namespace Gerador_de_Testes.ModuloMateria
{
    public interface IRepositorioMateria
    {
        void Cadastrar(Materia novaMateria);
        bool Editar(int idSelecionado, Materia materiaEditada);
        bool Excluir(int id);
        Materia SelecionarPorId(int idSelecionado);
        List<Materia> SelecionarTodos();
        int PegarId();
    }
}

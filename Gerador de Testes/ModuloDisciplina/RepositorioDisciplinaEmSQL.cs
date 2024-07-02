using Microsoft.Data.SqlClient;

namespace Gerador_de_Testes.ModuloDisciplina
{
    public class RepositorioDisciplinaEmSQL() : IRepositorioDisciplina
    {
        private int contadorId;
        private string enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = GeradorDeTestesDb; Integrated Security = True; Pooling=False";

        #region Queries
        protected string sqlInserir =
            @"INSERT INTO [TBDISCIPLINA]
            (
                [NOME_DISCIPLINA]
            )
            VALUES
            (
                @NOME_DISCIPLINA
            ); 
            SELECT SCOPE_IDENTITY();";
        protected string sqlEditar =
            @"UPDATE [TBDisciplina]
                SET
                    [NOME_DISCIPLINA] = @NOME_DISCIPLINA
                WHERE
                    [ID] = @ID;
            ";
        protected string sqlExcluir =
            @"DELETE FROM [TBDisciplina]
                WHERE
                    [ID] = @ID;
            ";
        protected string sqlSelecionarPorId =
            @"SELECT 
                [ID],
                [NOME_DISCIPLINA]
            FROM
                [TBDisciplina]
            WHERE
                [ID] = @ID";
        protected string sqlSelecionarTodos =
            @"SELECT 
                [ID],
                [NOME_DISCIPLINA]
            FROM
                [TBDisciplina]
            ";
        #endregion

        #region CRUD
        public void Cadastrar(Disciplina novaDisciplina)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoInsercao = new(sqlInserir, conexaoComBanco);

            ConfigurarParametros(comandoInsercao, novaDisciplina);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novaDisciplina.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }
        public bool Editar(int id, Disciplina disciplinaEditada)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoEdicao = new(sqlEditar, conexaoComBanco);

            disciplinaEditada.Id = id;

            ConfigurarParametros(comandoEdicao, disciplinaEditada);

            conexaoComBanco.Open();

            int numRegistrosAfetados = comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numRegistrosAfetados < 1) return false;
            return true;
        }
        public bool Excluir(int id)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoExclusao = new(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            int numRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numRegistrosExcluidos < 1) return false;
            return true;
        }
        #endregion

        #region Auxiliares
        public int PegarId() => contadorId;
        public Disciplina SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoSelecao = new(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader();

            Disciplina disciplina = null;

            if (leitor.Read())
                disciplina = ConverterParaDisciplina(leitor);

            conexaoComBanco.Close();

            return disciplina;
        }
        public List<Disciplina> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoSelecao = new(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader();

            List<Disciplina> disciplinas = [];

            while (leitorDisciplina.Read())
                disciplinas.Add(ConverterParaDisciplina(leitorDisciplina));

            contadorId = disciplinas.Last().Id + 1;

            conexaoComBanco.Close();

            return disciplinas;
        }
        private Disciplina ConverterParaDisciplina(SqlDataReader leitor)
            => new()
            {
                Id = Convert.ToInt32(leitor["ID"]),
                Nome = leitor["NOME_DISCIPLINA"].ToString()
            };
        private void ConfigurarParametros(SqlCommand comando, Disciplina disciplina)
        {
            comando.Parameters.AddWithValue("ID", disciplina.Id);
            comando.Parameters.AddWithValue("NOME_DISCIPLINA", disciplina.Nome);
        }
        #endregion
    }
}

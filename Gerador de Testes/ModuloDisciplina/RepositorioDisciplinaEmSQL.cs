using Microsoft.Data.SqlClient;

namespace Gerador_de_Testes.ModuloDisciplina
{
    public class RepositorioDisciplinaEmSQL() : IRepositorioDisciplina
    {
        private int contadorId;
        private string enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = GeradorDeTestesDb; Integrated Security = True; Pooling=False";

        #region CRUD
        public void Cadastrar(Disciplina novaDisciplina)
        {
            string sqlInserir =
                @"INSERT INTO [TBDISCIPLINA]
                  	(
                    	[NOME]
                	)
                	VALUES
                	(
                		@NOME
                	); 
                    SELECT SCOPE_IDENTITY();";

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
            string sqlEditar =
                @"UPDATE [TBDisciplina]
                    SET
                        [NOME] = @NOME
                    WHERE
                        [ID] = @ID;
                ";

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
            string sqlEditar =
                @"DELETE FROM [TBDisciplina]
                    WHERE
                        [ID] = @ID;
                ";

            SqlConnection conexaoComBanco = new(enderecoBanco);
            SqlCommand comandoExclusao = new(sqlEditar, conexaoComBanco);

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
            string sqlSelecionarPorId =
                @"SELECT 
                    [ID],
                    [NOME]
                FROM
                    [TBDisciplina]
                WHERE
                    [ID] = @ID";

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
            string sqlSelecionarTodos =
                @"SELECT 
                    [ID],
                    [NOME]
                FROM
                    [TBDisciplina]
                ";

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
                Nome = leitor["NOME"].ToString()
            };
        private void ConfigurarParametros(SqlCommand comando, Disciplina disciplina)
        {
            comando.Parameters.AddWithValue("ID", disciplina.Id);
            comando.Parameters.AddWithValue("NOME", disciplina.Nome);
        }
        #endregion
    }
}

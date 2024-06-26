using Gerador_de_Testes.ModuloDisciplina;
using Microsoft.Data.SqlClient;
namespace Gerador_de_Testes.ModuloMateria
{
    //Mapeamento Objeto Relacional
    public class RepositorioMateriaEmSQL() : IRepositorioMateria
    {
        private int contadorId;
        private string enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = GeradorDeTestesDb; Integrated Security = True; Pooling=False";
        private const string sqlInserir =
            @"INSERT INTO [TBMATERIA]
            (
                [NOME],
                [SERIE],
                [DISCIPLINA_ID]
            )
            VALUES
            (
                @NOME,
                @SERIE,
                @DISCIPLINA_ID
            ); 
            SELECT SCOPE_IDENTITY();";
        private const string sqlEditar =
            @"UPDATE [TBMATERIA]
                SET
                    [NOME] = @NOME,
                    [SERIE] = @SERIE,
                    [DISCIPLINA_ID] = @DISCIPLINA_ID
                WHERE
                    [ID] = @ID;";
        private const string sqlExcluir =
            @"DELETE FROM [TBMATERIA]
                WHERE
                    [ID] = @ID;";
        private const string sqlSelecionarTodos =
            @"SELECT 
                MT.[ID],
                MT.[NOME],
                MT.[SERIE],
                MT.[DISCIPLINA_ID],
                DC.[NOME]
            FROM
                [TBMateria] AS MT LEFT JOIN
                [TBDisciplina] AS DC
            ON
                DC.ID = MT.DISCIPLINA_ID;";
        private const string sqlSelecionarPorId =
            @"SELECT 
                MT.[ID],
                MT.[NOME],
                MT.[SERIE],
                MT.[DISCIPLINA_ID],
                DC.[NOME]
            FROM
                [TBMateria] AS MT LEFT JOIN
                [TBDisciplina] AS DC
            ON
                DC.ID = MT.DISCIPLINA_ID
            WHERE
                MT.[ID] = @ID;";


        #region CRUD
        public void Cadastrar(Materia novaMateria)
        {
            CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comandoInsercao, sqlInserir);

            ConfigurarParametros(comandoInsercao, novaMateria);

            object id = comandoInsercao.ExecuteScalar();

            novaMateria.Id = Convert.ToInt32(id);

            RealizarAcaoEmSQL(conexaoComBanco, comandoInsercao);
        }
        public bool Editar(int id, Materia disciplinaEditada)
        {
            CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comandoEdicao, sqlEditar);

            disciplinaEditada.Id = id;

            ConfigurarParametros(comandoEdicao, disciplinaEditada);

            return RealizarAcaoEmSQL(conexaoComBanco, comandoEdicao);
        }
        public bool Excluir(int id)
        {
            CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comandoExclusao, sqlExcluir);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            return RealizarAcaoEmSQL(conexaoComBanco, comandoExclusao);
        }
        #endregion

        #region Auxiliares
        public int PegarId() => contadorId;
        public Materia SelecionarPorId(int idSelecionado)
        {
            CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comandoSelecao, sqlSelecionarPorId);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader();

            Materia materia = null;

            if (leitor.Read())
                materia = ConverterParaMateria(leitor);

            conexaoComBanco.Close();

            return materia;
        }
        public List<Materia> SelecionarTodos()
        {
            CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comandoSelecao, sqlSelecionarTodos);

            conexaoComBanco.Open();

            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = [];

            while (leitorMateria.Read())
                materias.Add(ConverterParaMateria(leitorMateria));

            if (materias.Count > 0)
                contadorId = materias.Last().Id + 1;

            conexaoComBanco.Close();

            return materias;
        }
        private Materia ConverterParaMateria(SqlDataReader leitor)
            => new()
            {
                Id = Convert.ToInt32(leitor["ID"]),
                Nome = leitor["NOME"].ToString(),
                Serie = leitor["SERIE"].ToString(),
                Disciplina = ConverterParaDisciplina(leitor)
            };
        private Disciplina ConverterParaDisciplina(SqlDataReader leitor)
            => new()
            {
                Id = Convert.ToInt32(leitor["DISCIPLINA_ID"]),
                Nome = leitor["NOME"].ToString()
            };
        private void ConfigurarParametros(SqlCommand comando, Materia materia)
        {
            comando.Parameters.AddWithValue("ID", materia.Id);
            comando.Parameters.AddWithValue("NOME", materia.Nome);
            comando.Parameters.AddWithValue("SERIE", materia.Serie);

            comando.Parameters.AddWithValue("DISCIPLINA_ID", materia.Disciplina.Id);
        }
        private void CriarConexaoSQL(out SqlConnection conexaoComBanco, out SqlCommand comando, string query)
        {
            conexaoComBanco = new(enderecoBanco);
            comando = new(query, conexaoComBanco);
        }
        private static bool RealizarAcaoEmSQL(SqlConnection conexaoComBanco, SqlCommand comando)
        {
            conexaoComBanco.Open();

            int numRegistrosAfetados = comando.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numRegistrosAfetados < 1) return false;
            return true;
        }
        #endregion
    }
}

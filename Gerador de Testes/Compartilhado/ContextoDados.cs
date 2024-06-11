using System.Text.Json.Serialization;
using System.Text.Json;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
using Gerador_de_Testes.ModuloTeste;
namespace Gerador_de_Testes.Compartilhado
{
    public class ContextoDados()
    {
        public List<Disciplina> Disciplinas { get; set; } = [];
        public List<Materia> Materias { get; set; } = [];
        public List<Questao> Questoes { get; set; } = [];
        public List<Teste> Testes { get; set; } = [];
        private string caminho = $"C:\\temp\\GeradorTestes\\dados.json";

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados) CarregarDados();
        }

        public void Gravar()
        {
            FileInfo arquivo = new(caminho);

            arquivo.Directory.Create();

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            byte[] resgistrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(this, options);

            File.WriteAllBytes(caminho, resgistrosEmBytes);
        }
        public void CarregarDados()
        {
            FileInfo arquivo = new(caminho);

            if (!arquivo.Exists) return;

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosEmBytes, options);

            if (ctx == null) return;

            Disciplinas = ctx.Disciplinas;
            Materias = ctx.Materias;
            Questoes = ctx.Questoes;
            Testes = ctx.Testes;
        }
    }
}

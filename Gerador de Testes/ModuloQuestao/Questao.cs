using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;

namespace Gerador_de_Testes.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public string Resposta { get; set; }    
        public List<Alternativa> Alternativas { get; set; }
        public Questao()
        {
        }
        public Questao(string enunciado, Materia materia, List<Alternativa> alternativas, string resposta)
        {
            Enunciado = enunciado;
            Materia = materia;
            Alternativas = alternativas;
            Resposta = resposta;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Questao atualizado = (Questao)novoRegistro;

            Enunciado = atualizado.Enunciado;
            Materia = atualizado.Materia;
            Alternativas = atualizado.Alternativas;
            Resposta = atualizado.Resposta;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Enunciado, "enunciado");

            return erros;
        }
        public override string ToString()
        {
            return $"{Enunciado}";
        }
    }
}
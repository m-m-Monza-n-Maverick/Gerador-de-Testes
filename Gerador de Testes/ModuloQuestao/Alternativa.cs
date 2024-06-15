
namespace Gerador_de_Testes.ModuloQuestao
{
    public class Alternativa
    {
        public char Letra { get; set; }
        public string Resposta { get; set; }
        public bool Correta { get; set; }

        public Alternativa(char letra, string resposta, bool correta)
        {
            Letra = letra;
            Resposta = resposta;    
            Correta = correta;
        }
        public override string ToString()
        {
            return $"({Letra}) -> {Resposta}";
        }
    }
}

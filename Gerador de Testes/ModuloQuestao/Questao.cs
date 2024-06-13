using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;

namespace Gerador_de_Testes.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public Materia Materia
        {
            get => default;
            set
            {
            }
        }

        public string Enunciado
        {
            get => default;
            set
            {
            }
        }

        public string[] Alternativas
        {
            get => default;
            set
            {
            }
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
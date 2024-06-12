using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;

namespace Gerador_de_Testes.ModuloMateria
{
    public class Materia : EntidadeBase
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        public Disciplina Disciplina
        {
            get => default;
            set
            {
            }
        }
        public List<Questao> Questoes
        {
            get => default;
            set
            {
            }
        }
        public Materia()
        {
        }
        public Materia(string nome, string serie, Disciplina disciplina,List<Questao> questoes)
        {
            Nome = nome;
            Serie = serie;
            Disciplina = disciplina;
            Questoes = questoes;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Serie.Trim()))
                erros.Add("O campo \"serie\" é obrigatório");

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Materia atualizado = (Materia)novoRegistro;

            Nome = atualizado.Nome;
            Serie = atualizado.Serie;
            Disciplina = atualizado.Disciplina;
        }
        public override string ToString()
        {
            return $"{Nome.ToTitleCase()}";
        }
    }
}
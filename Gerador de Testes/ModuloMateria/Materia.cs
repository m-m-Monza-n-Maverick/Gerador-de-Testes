using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloQuestao;
using Gerador_de_Testes.ModuloTeste;

namespace Gerador_de_Testes.ModuloMateria
{
    public class Materia : EntidadeBase
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> Questoes { get; set; }
        public Materia() { }    
        public Materia(string nome, string serie, Disciplina disciplina, List<Questao> questoes)
        {
            Nome = nome;
            Serie = serie;
            Disciplina = disciplina;
            Questoes = questoes;
        }

        #region Overrides
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            VerificaNulo(ref erros, Nome, "Nome");
            VerificaNulo(ref erros, Disciplina);
            VerificaNulo(ref erros, Serie, "Série");

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Materia atualizado = (Materia)novoRegistro;

            Nome = atualizado.Nome;
            Serie = atualizado.Serie;
            Disciplina = atualizado.Disciplina;
            Questoes = atualizado.Questoes;
        }
        public override string ToString() => $"{Nome.ToTitleCase()}, {Serie}";
        #endregion

        #region Auxiliares
        protected void VerificaNulo(ref List<string> erros, Disciplina campoTestado)
        {
            if (campoTestado == null)
                erros.Add("É necessário informar uma \"Disciplina\". Tente novamente ");
        }
        internal void ValidarNome(ref List<string> erros, List<Materia> materias)
        {
            foreach (Materia m in materias)
                if (m.Nome.Validation() == Nome.Validation())
                    erros.Add($"Já existe uma matéria com o nome \"{Nome.ToTitleCase().Trim()}\". Tente novamente ");
        }
        internal void ValidarMateriaJaExistente(ref List<string> erros, List<Materia> materias, int id)
        {
            foreach (Materia m in materias)
                if (m.Nome.Validation() == Nome.Validation() &&
                    m.Disciplina == Disciplina && 
                    m.Serie == Serie &&
                    m.Id != id)
                        erros.Add("Esta matéria já existe. Tente novamente");
        }
        internal void AdicionarMateriaEmDisciplina(int id, List<Disciplina> disciplinas)
        {
            Id = id;

            foreach (Disciplina d in disciplinas)
                if (d == Disciplina)
                    d.Materias.Add(this);
        }
        internal void RemoverMateriaEmDisciplina(List<Disciplina> disciplinas)
        {
            foreach (Disciplina d in disciplinas)
            {
                foreach (Materia m in d.Materias)
                    if (m.Nome == Nome)
                    {
                        d.Materias.Remove(m);
                        d.AtualizarRegistro(d);
                        return;
                    }
            }
        }
        internal bool MateriaSemQuestões(Teste teste, ref ComboBox cmbMateria)
        {
            if (Questoes.Count != 0) return false;

            MessageBox.Show(
                "Esta matéria não possui questões cadastradas",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            if (teste.Materia != null) cmbMateria.SelectedItem = teste.Materia;

            return true; ;
        }
        #endregion
    }
}
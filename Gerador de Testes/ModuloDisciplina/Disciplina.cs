using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloTeste;

namespace Gerador_de_Testes.ModuloDisciplina
{
    public class Disciplina : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }

        public Disciplina() {}
        public Disciplina(string nome, List<Materia> materias)
        {
            Nome = nome;
            Materias = materias;
        }

        #region Overrides
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Disciplina atualizada = (Disciplina)novoRegistro;

            Nome = atualizada.Nome;
            Materias = atualizada.Materias;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];
            VerificaNulo(ref erros, Nome, "Nome");

            return erros;
        }
        public override string ToString() => Nome.ToTitleCase();
        #endregion

        #region Auxiliares
        internal bool DisciplinaSemMaterias(Teste teste, ref ComboBox cmbDisciplina)
        {
            if (Materias.Count == 0)
            {
                MessageBox.Show(
                    "Esta disciplina não possui matérias cadastradas",
                    "Aviso",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                if (teste != null) cmbDisciplina.SelectedItem = teste.Disciplina;
                return true;
            }
            return false;
        }
        internal bool DisciplinaSemQuestões(Teste teste, ref ComboBox cmbDisciplina)
        {
            foreach (Materia m in Materias)
                if (m.Questoes.Count != 0) return false;

            MessageBox.Show(
                "Esta disciplina não possui questões cadastradas",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            if (teste != null) cmbDisciplina.SelectedItem = teste.Disciplina;

            return true;
        }
        #endregion
    }
}
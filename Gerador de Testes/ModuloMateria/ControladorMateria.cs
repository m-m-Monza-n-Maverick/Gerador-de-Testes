﻿using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
namespace Gerador_de_Testes.ModuloMateria
{
    internal class ControladorMateria (RepositorioMateria repositorioMateria/*, RepositorioDisciplina repositorioDisciplina*/) : ControladorBase
    {
        private RepositorioMateria repositorioMateria = repositorioMateria;
        //private RepositorioDisciplina repositorioDisciplina = repositorioDisciplina;
        private TabelaMateriaControl tabelaMateria;

        public override string TipoCadastro => "Matéria";

        public override string ToolTipAdicionar => "Adicionar matéria";

        public override string ToolTipEditar => "Editar matéria";

        public override string ToolTipExcluir => "Excluir matéria";

        #region CRUD
        public override void Adicionar()
        {
            int id = repositorioMateria.PegarId();

            TelaMateriaForm telaMateria = new(id);

            //Adicionei essa linha (olhar linha 120)
            CarregarDisciplinas(telaMateria);

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Materia novaMateria = telaMateria.Materia;

            repositorioMateria.Cadastrar(novaMateria);
            
            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novaMateria.Nome}\" foi cadastrado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            TelaMateriaForm telaMateria = new(idSelecionado);

            Materia materiaSelecionada =
                repositorioMateria.SelecionarPorId(idSelecionado);

            if(materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            telaMateria.Materia = materiaSelecionada;

            DialogResult resultado = telaMateria.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Materia MateriaEditada = telaMateria.Materia;

            repositorioMateria.Editar(idSelecionado, MateriaEditada);

            CarregarMaterias(); 

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{MateriaEditada.Nome}\" foi excluído com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada = 
                repositorioMateria.SelecionarPorId(idSelecionado);

            if (materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            repositorioMateria.Excluir(materiaSelecionada.Id);

            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{materiaSelecionada.Nome}\" foi excluído com sucesso!");
        }
        #endregion

        #region Auxiliares 
        public override UserControl ObterListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }
        
        private void CarregarMaterias()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(Materias);
        }
        private void CarregarDisciplinas(TelaMateriaForm telaMateria)
        {
            //Tive que chamar o repositório de disciplinas aqui, pra ter acesso às disciplinas cadastradas (olhar linha 8)

            List<Disciplina> disciplinasCadastradas/* = repositorioDisciplina.SelecionarTodos();

            telaMateria.CarregarDisciplinas(disciplinasCadastradas)*/;



            //Testando (apagar depois)
            Disciplina disciplina = new();
            telaMateria.CarregarDisciplinas([disciplina]);
        }
    }
}

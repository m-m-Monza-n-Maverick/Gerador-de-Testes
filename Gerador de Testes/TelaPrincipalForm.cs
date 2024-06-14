using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
using Gerador_de_Testes.ModuloQuestao;
using Gerador_de_Testes.ModuloTeste;
namespace Gerador_de_Testes
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        ContextoDados contexto;

        IRepositorioDisciplina repositorioDisciplina;
        //IRepositorioMateria repositorioMateria;
        //IRepositorioQuestao repositorioQuestao;
        IRepositorioTeste repositorioTeste;
        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            contexto = new(carregarDados: true);
            repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contexto);
            //repositorioMateria = new RepositorioMateriaEmArquivo(contexto);
            //repositorioQuestao = new RepositorioQuestaoEmArquivo(contexto);
            repositorioTeste = new RepositorioTesteEmArquivo(contexto);


            Disciplina disciplina1 = new("disciplina");
            disciplina1.Id = 1;
            Disciplina disciplina2 = new("aaaaaa");
            disciplina2.Id = 2;
            Disciplina disciplina3 = new("bbbbbb");
            disciplina3.Id = 3;

            Materia materia = new();
            Materia materia2 = new();

            Questao questao = new();
            questao.Id = 1;
            Questao questao1 = new();
            questao1.Id = 2;
            Questao questao2 = new();
            questao2.Id = 3;
            Questao questao3 = new();
            questao3.Id = 4;
            contexto.Questoes.AddRange([questao, questao1, questao2, questao3]);

            materia.Questoes.AddRange([questao, questao1]);
            materia2.Questoes.AddRange([questao2, questao3]);
            contexto.Materias.AddRange([materia, materia2]);

            disciplina1.Materias.AddRange([materia, materia2]);
            disciplina2.Materias.Add(materia);

            contexto.Disciplinas.AddRange([disciplina1, disciplina2, disciplina3]);

            Instancia = this;
        }

        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        #region Seleção de módulo
        private void disciplinasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorDisciplina(repositorioDisciplina, contexto));
        private void testesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorTeste(repositorioTeste, contexto));
        #endregion

        #region Botões
        private void btnAdicionar_Click_1(object sender, EventArgs e)
            => controlador.Adicionar();
        private void btnEditar_Click_1(object sender, EventArgs e)
            => controlador.Editar();
        private void btnExcluir_Click_1(object sender, EventArgs e)
            => controlador.Excluir();
        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorDuplicavel controladorDuplicavel)
                controladorDuplicavel.DuplicarTeste();
        }
        #endregion

        #region Auxiliares
        private void SelecionaModulo(ref ControladorBase controlador, Action controladorSelecionado)
        {
            controladorSelecionado();
            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;

            ConfigurarToolBox(controlador);
            ConfigurarListagem(controlador);
        }
        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = controladorSelecionado is not ControladorTeste;
            btnExcluir.Enabled = true;
            btnDuplicar.Enabled = controladorSelecionado is IControladorDuplicavel;

            ConfigurarToolTips(controladorSelecionado);
        }
        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is not ControladorTeste)
                btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;

            if (controladorSelecionado is IControladorDuplicavel controladorDuplicavel)
                btnDuplicar.ToolTipText = controladorDuplicavel.ToolTipDuplicarTeste;
        }
        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();

            listagemContato.Dock = DockStyle.Fill;
            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }
        #endregion
    }
}

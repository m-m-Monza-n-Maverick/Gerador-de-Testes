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
            Disciplina disciplina2 = new("aaaaaa");
            
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

            contexto.Disciplinas.AddRange([disciplina1, disciplina2]);

            Instancia = this;
        }

        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        #region Sele��o de m�dulo
        private void disciplinasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorDisciplina(repositorioDisciplina, contexto));
        private void testesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorTeste(repositorioTeste, contexto));
        #endregion

        #region Bot�es
        private void btnAdicionar_Click_1(object sender, EventArgs e)
            => controlador.Adicionar();
        private void btnEditar_Click_1(object sender, EventArgs e)
            => controlador.Editar();
        private void btnExcluir_Click_1(object sender, EventArgs e)
            => controlador.Excluir();
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
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            ConfigurarToolTips(controladorSelecionado);
        }
        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;
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

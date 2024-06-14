using Gerador_de_Testes.Compartilhado;
using Gerador_de_Testes.ModuloDisciplina;
using Gerador_de_Testes.ModuloMateria;
namespace Gerador_de_Testes
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        ContextoDados contexto;

        //IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        //IRepositorioQuestao repositorioQuestao;
        //IRepositorioTeste repositorioTeste;
        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            contexto = new(carregarDados: true);

            //repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contexto);
            repositorioMateria = new RepositorioMateria(contexto);
            //repositorioQuestao = new RepositorioQuestaoEmArquivo(contexto);
            //repositorioTeste = new RepositorioTesteEmArquivo(contexto);

            Instancia = this;
        }

        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        #region Seleção de módulo

        private void temasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorMateria(repositorioMateria, contexto));

        #endregion

        #region Botões
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

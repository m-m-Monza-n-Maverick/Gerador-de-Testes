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
        IRepositorioMateria repositorioMateria;
        IRepositorioQuestao repositorioQuestao;
        IRepositorioTeste repositorioTeste;

        public static TelaPrincipalForm Instancia { get; private set; }
        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            contexto = new(carregarDados: true);

            repositorioDisciplina = new RepositorioDisciplinaEmSQL();
            repositorioMateria = new RepositorioMateriaEmSQL();
            repositorioQuestao = new RepositorioQuestao(contexto);
            repositorioTeste = new RepositorioTeste(contexto);

            Instancia = this;
        }
        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        #region Seleção de módulo
        private void disciplinasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorDisciplina(repositorioDisciplina, contexto),
                contexto.Disciplinas.Count);
        private void materiasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorMateria(repositorioMateria, contexto),
                contexto.Materias.Count);
        private void questoesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorQuestao(repositorioQuestao, contexto),
                contexto.Questoes.Count);
        private void testesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorTeste(repositorioTeste, contexto), 
                contexto.Testes.Count);
        #endregion

        #region Botões
        private void btnAdicionar_Click(object sender, EventArgs e)
            => controlador.Adicionar();
        private void btnEditar_Click(object sender, EventArgs e)
            => controlador.Editar();
        private void btnExcluir_Click(object sender, EventArgs e)
            => controlador.Excluir();
        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorDuplicavel controladorDuplicavel)
                controladorDuplicavel.DuplicarTeste();
        }
        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorDetalhes controladorDetalhes)
                controladorDetalhes.VisualizarDetalhes();
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorPDF controladorPDF)
                controladorPDF.GerarPDF();
        }
        private void btnGabarito_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorPDF controladorPDF)
                controladorPDF.GerarPdfGabarito();
        }
        #endregion

        #region Auxiliares
        private void SelecionaModulo(ref ControladorBase controlador, Action controladorSelecionado, int numRegistros)
        {
            controladorSelecionado();
            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;

            ConfigurarToolBox(controlador);
            ConfigurarListagem(controlador);
            AtualizarRodape($"Visualizando {numRegistros} registro(s)...");
        }
        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = controladorSelecionado is not ControladorTeste;
            btnExcluir.Enabled = true;
            btnDuplicar.Enabled = controladorSelecionado is IControladorDuplicavel;
            btnDetalhes.Enabled = controladorSelecionado is IControladorDetalhes;
            btnPdf.Enabled = controladorSelecionado is IControladorPDF;
            btnGabarito.Enabled = controladorSelecionado is IControladorPDF;

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

            if (controladorSelecionado is IControladorDetalhes controladorDetalhes)
                btnDetalhes.ToolTipText = controladorDetalhes.ToolTipVisualizarDetalhes;

            if (controladorSelecionado is IControladorPDF controladorPDF)
            {
                btnPdf.ToolTipText = controladorPDF.ToolTipGerarPDF;
                btnGabarito.ToolTipText = controladorPDF.ToolTipGerarPdfGabarito;
            }
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

namespace Gerador_de_Testes
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            disciplinasMenuItem = new ToolStripMenuItem();
            materiasMenuItem = new ToolStripMenuItem();
            questoesMenuItem = new ToolStripMenuItem();
            testesMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabelPrincipal = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnAlternativas = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDuplicar = new ToolStripButton();
            btnDetalhes = new ToolStripButton();
            btnPdf = new ToolStripButton();
            btnGabarito = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            lblTipoCadastro = new ToolStripLabel();
            pnlRegistros = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { disciplinasMenuItem, materiasMenuItem, questoesMenuItem, testesMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(86, 24);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // disciplinasMenuItem
            // 
            disciplinasMenuItem.Name = "disciplinasMenuItem";
            disciplinasMenuItem.Size = new Size(149, 24);
            disciplinasMenuItem.Text = "Disciplinas";
            disciplinasMenuItem.Click += disciplinasMenuItem_Click;
            // 
            // materiasMenuItem
            // 
            materiasMenuItem.Name = "materiasMenuItem";
            materiasMenuItem.Size = new Size(149, 24);
            materiasMenuItem.Text = "Matérias";
            // 
            // questoesMenuItem
            // 
            questoesMenuItem.Name = "questoesMenuItem";
            questoesMenuItem.Size = new Size(149, 24);
            questoesMenuItem.Text = "Questões";
            // 
            // testesMenuItem
            // 
            testesMenuItem.Name = "testesMenuItem";
            testesMenuItem.Size = new Size(149, 24);
            testesMenuItem.Text = "Testes";
            testesMenuItem.Click += testesMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelPrincipal });
            statusStrip1.Location = new Point(0, 425);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 25);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPrincipal
            // 
            statusLabelPrincipal.Name = "statusLabelPrincipal";
            statusLabelPrincipal.Size = new Size(185, 20);
            statusLabelPrincipal.Text = "Visualizando 0 registro(s)...";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator2, btnAlternativas, toolStripSeparator1, btnDuplicar, btnDetalhes, btnPdf, btnGabarito, toolStripSeparator4, lblTipoCadastro });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 41);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            btnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionar.Enabled = false;
            btnAdicionar.Image = Gerador_de_Testes.Properties.Resources.btnAdicionarItens;
            btnAdicionar.ImageScaling = ToolStripItemImageScaling.None;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(5);
            btnAdicionar.Size = new Size(38, 38);
            btnAdicionar.Click += btnAdicionar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Enabled = false;
            btnEditar.Image = Gerador_de_Testes.Properties.Resources.btnEditar;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(38, 38);
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Enabled = false;
            btnExcluir.Image = Gerador_de_Testes.Properties.Resources.btnExcluir;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(38, 38);
            btnExcluir.Click += btnExcluir_Click_1;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 41);
            // 
            // btnAlternativas
            // 
            btnAlternativas.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAlternativas.Enabled = false;
            btnAlternativas.Image = Gerador_de_Testes.Properties.Resources.btnConfigurarDescontos;
            btnAlternativas.ImageScaling = ToolStripItemImageScaling.None;
            btnAlternativas.ImageTransparentColor = Color.Magenta;
            btnAlternativas.Name = "btnAlternativas";
            btnAlternativas.Padding = new Padding(5);
            btnAlternativas.Size = new Size(38, 38);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // btnDuplicar
            // 
            btnDuplicar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDuplicar.Enabled = false;
            btnDuplicar.Image = Gerador_de_Testes.Properties.Resources.Copiar1;
            btnDuplicar.ImageScaling = ToolStripItemImageScaling.None;
            btnDuplicar.ImageTransparentColor = Color.DarkOrchid;
            btnDuplicar.Name = "btnDuplicar";
            btnDuplicar.Padding = new Padding(5);
            btnDuplicar.Size = new Size(38, 38);
            btnDuplicar.Click += btnDuplicar_Click;
            // 
            // btnDetalhes
            // 
            btnDetalhes.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDetalhes.Enabled = false;
            btnDetalhes.Image = Gerador_de_Testes.Properties.Resources.Detalhes6;
            btnDetalhes.ImageScaling = ToolStripItemImageScaling.None;
            btnDetalhes.ImageTransparentColor = Color.Magenta;
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Padding = new Padding(5);
            btnDetalhes.Size = new Size(38, 38);
            btnDetalhes.Click += btnDetalhes_Click;
            // 
            // btnPdf
            // 
            btnPdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPdf.Enabled = false;
            btnPdf.Image = Gerador_de_Testes.Properties.Resources.PDF;
            btnPdf.ImageScaling = ToolStripItemImageScaling.None;
            btnPdf.ImageTransparentColor = Color.Magenta;
            btnPdf.Name = "btnPdf";
            btnPdf.Padding = new Padding(5);
            btnPdf.Size = new Size(38, 38);
            // 
            // btnGabarito
            // 
            btnGabarito.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGabarito.Enabled = false;
            btnGabarito.Image = Gerador_de_Testes.Properties.Resources.PDF_gabarito;
            btnGabarito.ImageScaling = ToolStripItemImageScaling.None;
            btnGabarito.ImageTransparentColor = Color.Magenta;
            btnGabarito.Name = "btnGabarito";
            btnGabarito.Padding = new Padding(5);
            btnGabarito.Size = new Size(38, 38);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 41);
            // 
            // lblTipoCadastro
            // 
            lblTipoCadastro.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoCadastro.Name = "lblTipoCadastro";
            lblTipoCadastro.Size = new Size(123, 38);
            lblTipoCadastro.Text = "Tipo de Cadastro";
            // 
            // pnlRegistros
            // 
            pnlRegistros.Dock = DockStyle.Fill;
            pnlRegistros.Location = new Point(0, 69);
            pnlRegistros.Name = "pnlRegistros";
            pnlRegistros.Size = new Size(800, 356);
            pnlRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlRegistros);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Testes";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelPrincipal;
        private ToolStrip toolStrip1;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private Panel pnlRegistros;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel lblTipoCadastro;
        private ToolStripButton btnGabarito;
        private ToolStripButton btnAlternativas;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem disciplinasMenuItem;
        private ToolStripMenuItem materiasMenuItem;
        private ToolStripMenuItem questoesMenuItem;
        private object Properties;
        private ToolStripMenuItem testesMenuItem;
        private ToolStripButton btnDuplicar;
        private ToolStripButton btnDetalhes;
        private ToolStripButton btnPdf;
        private ToolStripSeparator toolStripSeparator2;
    }
}

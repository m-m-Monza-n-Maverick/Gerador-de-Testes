using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloTeste
{
    partial class TelaTesteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGravar = new Button();
            btnCancelar = new Button();
            txtTitulo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cmbDisciplina = new ComboBox();
            label3 = new Label();
            txtQntQuestoes = new NumericUpDown();
            cmbMateria = new ComboBox();
            label4 = new Label();
            rdbRecuperacao = new CheckBox();
            groupBox1 = new GroupBox();
            lblAvisoAumentarQnt = new Label();
            listaQuestoes = new ListBox();
            btnSortear = new Button();
            ((System.ComponentModel.ISupportInitialize)txtQntQuestoes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(371, 365);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 365);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(80, 30);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(317, 23);
            txtTitulo.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 34);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 22;
            label2.Text = "Título:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 66);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 25;
            label1.Text = "Disciplina:";
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(80, 62);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(152, 23);
            cmbDisciplina.TabIndex = 1;
            cmbDisciplina.SelectionChangeCommitted += cmbDisciplina_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(253, 99);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 27;
            label3.Text = "Qnt. questões:";
            // 
            // txtQntQuestoes
            // 
            txtQntQuestoes.Enabled = false;
            txtQntQuestoes.Location = new Point(345, 95);
            txtQntQuestoes.Name = "txtQntQuestoes";
            txtQntQuestoes.ReadOnly = true;
            txtQntQuestoes.Size = new Size(52, 23);
            txtQntQuestoes.TabIndex = 4;
            txtQntQuestoes.ValueChanged += txtQntQuestoes_ValueChanged;
            // 
            // cmbMateria
            // 
            cmbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateria.Enabled = false;
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(80, 95);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(152, 23);
            cmbMateria.TabIndex = 3;
            cmbMateria.SelectionChangeCommitted += cmbMateria_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 99);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 29;
            label4.Text = "Matéria:";
            // 
            // rdbRecuperacao
            // 
            rdbRecuperacao.AutoSize = true;
            rdbRecuperacao.Enabled = false;
            rdbRecuperacao.Location = new Point(253, 66);
            rdbRecuperacao.Name = "rdbRecuperacao";
            rdbRecuperacao.Size = new Size(140, 19);
            rdbRecuperacao.TabIndex = 2;
            rdbRecuperacao.Text = "Prova de recuperação";
            rdbRecuperacao.UseVisualStyleBackColor = true;
            rdbRecuperacao.CheckedChanged += rdbRecuperacao_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAvisoAumentarQnt);
            groupBox1.Controls.Add(listaQuestoes);
            groupBox1.Controls.Add(btnSortear);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(24, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(409, 202);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas";
            // 
            // lblAvisoAumentarQnt
            // 
            lblAvisoAumentarQnt.AutoSize = true;
            lblAvisoAumentarQnt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvisoAumentarQnt.ForeColor = Color.Red;
            lblAvisoAumentarQnt.Location = new Point(251, 32);
            lblAvisoAumentarQnt.Name = "lblAvisoAumentarQnt";
            lblAvisoAumentarQnt.Size = new Size(0, 13);
            lblAvisoAumentarQnt.TabIndex = 6;
            // 
            // listaQuestoes
            // 
            listaQuestoes.BorderStyle = BorderStyle.None;
            listaQuestoes.FormattingEnabled = true;
            listaQuestoes.ItemHeight = 17;
            listaQuestoes.Location = new Point(0, 66);
            listaQuestoes.Name = "listaQuestoes";
            listaQuestoes.Size = new Size(409, 136);
            listaQuestoes.TabIndex = 1;
            // 
            // btnSortear
            // 
            btnSortear.BackColor = SystemColors.Control;
            btnSortear.Enabled = false;
            btnSortear.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnSortear.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnSortear.FlatStyle = FlatStyle.Flat;
            btnSortear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSortear.Location = new Point(27, 27);
            btnSortear.Name = "btnSortear";
            btnSortear.Size = new Size(113, 23);
            btnSortear.TabIndex = 5;
            btnSortear.Text = "Sortear Questões";
            btnSortear.UseVisualStyleBackColor = false;
            btnSortear.Click += btnSortear_Click;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 400);
            Controls.Add(groupBox1);
            Controls.Add(rdbRecuperacao);
            Controls.Add(cmbMateria);
            Controls.Add(label4);
            Controls.Add(txtQntQuestoes);
            Controls.Add(label3);
            Controls.Add(cmbDisciplina);
            Controls.Add(label1);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTesteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Teste";
            ((System.ComponentModel.ISupportInitialize)txtQntQuestoes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CmbMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtTitulo;
        private Label label2;
        private Label label1;
        private ComboBox cmbDisciplina;
        private Label label3;
        private NumericUpDown txtQntQuestoes;
        private ComboBox cmbMateria;
        private Label label4;
        private CheckBox rdbRecuperacao;
        private GroupBox groupBox1;
        private Button btnSortear;
        private ListBox listaQuestoes;
        private Label lblAvisoAumentarQnt;
    }
}
namespace Gerador_de_Testes.ModuloTeste
{
    partial class TelaDetalhesTesteForm
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
            btnVoltar = new Button();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            listaQuestoes = new ListBox();
            lblTitulo = new Label();
            lblDisciplina = new Label();
            lblMateria = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnVoltar
            // 
            btnVoltar.DialogResult = DialogResult.OK;
            btnVoltar.Location = new Point(12, 365);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(75, 23);
            btnVoltar.TabIndex = 6;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 99);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 29;
            label4.Text = "Matéria:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listaQuestoes);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(24, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(409, 202);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas";
            // 
            // listaQuestoes
            // 
            listaQuestoes.BackColor = SystemColors.ButtonFace;
            listaQuestoes.BorderStyle = BorderStyle.None;
            listaQuestoes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listaQuestoes.FormattingEnabled = true;
            listaQuestoes.ItemHeight = 15;
            listaQuestoes.Location = new Point(3, 30);
            listaQuestoes.Name = "listaQuestoes";
            listaQuestoes.Size = new Size(403, 165);
            listaQuestoes.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo.Location = new Point(80, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(39, 15);
            lblTitulo.TabIndex = 34;
            lblTitulo.Text = "Título";
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDisciplina.Location = new Point(80, 66);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(59, 15);
            lblDisciplina.TabIndex = 35;
            lblDisciplina.Text = "Disciplina";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMateria.Location = new Point(80, 99);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(50, 15);
            lblMateria.TabIndex = 36;
            lblMateria.Text = "Matéria";
            // 
            // TelaDetalhesTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 400);
            Controls.Add(lblMateria);
            Controls.Add(lblDisciplina);
            Controls.Add(lblTitulo);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(btnVoltar);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaDetalhesTesteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TelaTesteForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void CmbMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnGravar;
        private Button btnVoltar;
        private Label label2;
        private Label label1;
        private Label label4;
        private GroupBox groupBox1;
        private ListBox listaQuestoes;
        private Label lblTitulo;
        private Label lblDisciplina;
        private Label lblMateria;
    }
}
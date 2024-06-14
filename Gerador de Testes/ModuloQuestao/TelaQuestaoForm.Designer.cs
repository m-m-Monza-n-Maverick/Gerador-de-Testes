﻿namespace Gerador_de_Testes.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            lblMateria = new Label();
            lblEnunciado = new Label();
            lblResposta = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            btnAdicionar = new Button();
            cmbMateria = new ComboBox();
            txtResposta = new TextBox();
            listBox = new CheckedListBox();
            txtEnunciado = new TextBox();
            label4 = new Label();
            txtId = new TextBox();
            groupBox1 = new GroupBox();
            btnRemoverlist = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new Point(36, 62);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(50, 15);
            lblMateria.TabIndex = 0;
            lblMateria.Text = "Matéria:";
            // 
            // lblEnunciado
            // 
            lblEnunciado.AutoSize = true;
            lblEnunciado.Location = new Point(20, 131);
            lblEnunciado.Name = "lblEnunciado";
            lblEnunciado.Size = new Size(66, 15);
            lblEnunciado.TabIndex = 1;
            lblEnunciado.Text = "Enunciado:";
            // 
            // lblResposta
            // 
            lblResposta.AutoSize = true;
            lblResposta.Location = new Point(29, 199);
            lblResposta.Name = "lblResposta";
            lblResposta.Size = new Size(57, 15);
            lblResposta.TabIndex = 2;
            lblResposta.Text = "Resposta:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(268, 446);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(87, 34);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(372, 446);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 34);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(361, 191);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(83, 31);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // cmbMateria
            // 
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(92, 59);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(200, 23);
            cmbMateria.TabIndex = 0;
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(92, 191);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(263, 31);
            txtResposta.TabIndex = 2;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(0, 58);
            listBox.Name = "listBox";
            listBox.Size = new Size(408, 130);
            listBox.TabIndex = 8;
            listBox.ItemCheck += OnlyOne_ItemCheck;
            listBox.HandleCreated += CheckItemCorreto;
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(92, 93);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new Size(352, 92);
            txtEnunciado.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 32);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 9;
            label4.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(92, 29);
            txtId.Name = "txtId";
            txtId.Size = new Size(66, 23);
            txtId.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Controls.Add(btnRemoverlist);
            groupBox1.Controls.Add(listBox);
            groupBox1.Location = new Point(36, 246);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 194);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas:";
            // 
            // btnRemoverlist
            // 
            btnRemoverlist.Location = new Point(6, 22);
            btnRemoverlist.Name = "btnRemoverlist";
            btnRemoverlist.Size = new Size(81, 29);
            btnRemoverlist.TabIndex = 9;
            btnRemoverlist.Text = "Remover";
            btnRemoverlist.UseVisualStyleBackColor = true;
            btnRemoverlist.Click += btnRemover_Click;
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 492);
            Controls.Add(groupBox1);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(txtEnunciado);
            Controls.Add(txtResposta);
            Controls.Add(cmbMateria);
            Controls.Add(btnAdicionar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(lblResposta);
            Controls.Add(lblEnunciado);
            Controls.Add(lblMateria);
            Name = "TelaQuestaoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMateria;
        private Label lblEnunciado;
        private Label lblResposta;
        private Button btnGravar;
        private Button btnCancelar;
        private Button btnAdicionar;
        private ComboBox cmbMateria;
        private TextBox txtResposta;
        private CheckedListBox listBox;
        private TextBox txtEnunciado;
        private Label label4;
        private TextBox txtId;
        private GroupBox groupBox1;
        private Button btnRemover;
        private Button btnRemoverlist;
    }
}
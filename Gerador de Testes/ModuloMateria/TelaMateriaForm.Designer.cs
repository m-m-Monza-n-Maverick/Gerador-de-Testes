namespace Gerador_de_Testes.ModuloMateria
{
    partial class TelaMateriaForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtId = new TextBox();
            txtNome = new TextBox();
            cmbDisciplina = new ComboBox();
            label4 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            radio1Serie = new RadioButton();
            radio2Serie = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 38);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 89);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 121);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Disciplina:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(114, 35);
            txtId.Name = "txtId";
            txtId.Size = new Size(47, 23);
            txtId.TabIndex = 3;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(114, 85);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(289, 23);
            txtNome.TabIndex = 0;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(114, 117);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(121, 23);
            cmbDisciplina.TabIndex = 1;
            cmbDisciplina.KeyPress += cmbDisciplina_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 153);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 6;
            label4.Text = "Série:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(373, 213);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 213);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // radio1Serie
            // 
            radio1Serie.AutoSize = true;
            radio1Serie.Location = new Point(120, 151);
            radio1Serie.Name = "radio1Serie";
            radio1Serie.Size = new Size(36, 19);
            radio1Serie.TabIndex = 2;
            radio1Serie.TabStop = true;
            radio1Serie.Text = "1º";
            radio1Serie.UseVisualStyleBackColor = true;
            // 
            // radio2Serie
            // 
            radio2Serie.AutoSize = true;
            radio2Serie.Location = new Point(170, 151);
            radio2Serie.Name = "radio2Serie";
            radio2Serie.Size = new Size(36, 19);
            radio2Serie.TabIndex = 3;
            radio2Serie.TabStop = true;
            radio2Serie.Text = "2º";
            radio2Serie.UseVisualStyleBackColor = true;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 248);
            Controls.Add(radio2Serie);
            Controls.Add(radio1Serie);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label4);
            Controls.Add(cmbDisciplina);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaMateriaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Matéria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtId;
        private TextBox txtNome;
        private ComboBox cmbDisciplina;
        private Label label4;
        private Button btnGravar;
        private Button btnCancelar;
        private RadioButton radio1Serie;
        private RadioButton radio2Serie;
    }
}
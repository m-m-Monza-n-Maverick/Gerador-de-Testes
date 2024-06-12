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
            boxDisciplina = new ComboBox();
            label4 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            radio1 = new RadioButton();
            radio2 = new RadioButton();
            radio3 = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 59);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 110);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 148);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Disciplina:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(102, 56);
            txtId.Name = "txtId";
            txtId.Size = new Size(47, 23);
            txtId.TabIndex = 3;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(102, 102);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(289, 23);
            txtNome.TabIndex = 0;
            // 
            // boxDisciplina
            // 
            boxDisciplina.FormattingEnabled = true;
            boxDisciplina.Location = new Point(102, 145);
            boxDisciplina.Name = "boxDisciplina";
            boxDisciplina.Size = new Size(121, 23);
            boxDisciplina.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 188);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 6;
            label4.Text = "Série:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(246, 253);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 31);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(344, 253);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 31);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            radio1.AutoSize = true;
            radio1.Location = new Point(102, 184);
            radio1.Name = "radio1";
            radio1.Size = new Size(36, 19);
            radio1.TabIndex = 2;
            radio1.TabStop = true;
            radio1.Text = "1º";
            radio1.UseVisualStyleBackColor = true;
            // 
            // radio2
            // 
            radio2.AutoSize = true;
            radio2.Location = new Point(144, 184);
            radio2.Name = "radio2";
            radio2.Size = new Size(36, 19);
            radio2.TabIndex = 3;
            radio2.TabStop = true;
            radio2.Text = "2º";
            radio2.UseVisualStyleBackColor = true;
            // 
            // radio3
            // 
            radio3.AutoSize = true;
            radio3.Location = new Point(186, 184);
            radio3.Name = "radio3";
            radio3.Size = new Size(36, 19);
            radio3.TabIndex = 4;
            radio3.TabStop = true;
            radio3.Text = "3º";
            radio3.UseVisualStyleBackColor = true;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 308);
            Controls.Add(radio3);
            Controls.Add(radio2);
            Controls.Add(radio1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label4);
            Controls.Add(boxDisciplina);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaMateriaForm";
            Text = "TelaMateriaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtId;
        private TextBox txtNome;
        private ComboBox boxDisciplina;
        private Label label4;
        private Button btnGravar;
        private Button btnCancelar;
        private RadioButton radio1;
        private RadioButton radio2;
        private RadioButton radio3;
    }
}
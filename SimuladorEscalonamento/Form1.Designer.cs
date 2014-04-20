namespace SimuladorEscalonamento
{
    partial class Form1
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
            this.dataGridViewProcessos = new System.Windows.Forms.DataGridView();
            this.buttonAddProcesso = new System.Windows.Forms.Button();
            this.textBoxInicio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDuracao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxRetorno = new System.Windows.Forms.ListBox();
            this.buttonSimular = new System.Windows.Forms.Button();
            this.buttonStepbyStep = new System.Windows.Forms.Button();
            this.dataGridViewSimulacao = new System.Windows.Forms.DataGridView();
            this.labelPrioridade = new System.Windows.Forms.Label();
            this.textBoxPrioridade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxQuantum = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcessos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimulacao)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProcessos
            // 
            this.dataGridViewProcessos.AllowUserToAddRows = false;
            this.dataGridViewProcessos.AllowUserToDeleteRows = false;
            this.dataGridViewProcessos.AllowUserToOrderColumns = true;
            this.dataGridViewProcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcessos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProcessos.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewProcessos.Name = "dataGridViewProcessos";
            this.dataGridViewProcessos.ReadOnly = true;
            this.dataGridViewProcessos.Size = new System.Drawing.Size(583, 134);
            this.dataGridViewProcessos.TabIndex = 0;
            // 
            // buttonAddProcesso
            // 
            this.buttonAddProcesso.Location = new System.Drawing.Point(229, 43);
            this.buttonAddProcesso.Name = "buttonAddProcesso";
            this.buttonAddProcesso.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProcesso.TabIndex = 1;
            this.buttonAddProcesso.Text = "Add";
            this.buttonAddProcesso.UseVisualStyleBackColor = true;
            this.buttonAddProcesso.Click += new System.EventHandler(this.buttonAddProcesso_Click);
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Location = new System.Drawing.Point(12, 45);
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(46, 20);
            this.textBoxInicio.TabIndex = 2;
            this.textBoxInicio.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Início";
            // 
            // textBoxDuracao
            // 
            this.textBoxDuracao.Location = new System.Drawing.Point(64, 45);
            this.textBoxDuracao.Name = "textBoxDuracao";
            this.textBoxDuracao.Size = new System.Drawing.Size(46, 20);
            this.textBoxDuracao.TabIndex = 4;
            this.textBoxDuracao.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duração";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(116, 45);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(46, 20);
            this.textBoxNome.TabIndex = 6;
            this.textBoxNome.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nome";
            // 
            // listBoxRetorno
            // 
            this.listBoxRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRetorno.FormattingEnabled = true;
            this.listBoxRetorno.Location = new System.Drawing.Point(613, 72);
            this.listBoxRetorno.Name = "listBoxRetorno";
            this.listBoxRetorno.Size = new System.Drawing.Size(252, 134);
            this.listBoxRetorno.TabIndex = 8;
            // 
            // buttonSimular
            // 
            this.buttonSimular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSimular.Location = new System.Drawing.Point(790, 43);
            this.buttonSimular.Name = "buttonSimular";
            this.buttonSimular.Size = new System.Drawing.Size(75, 23);
            this.buttonSimular.TabIndex = 9;
            this.buttonSimular.Text = "Simular";
            this.buttonSimular.UseVisualStyleBackColor = true;
            this.buttonSimular.Click += new System.EventHandler(this.buttonSimular_Click);
            // 
            // buttonStepbyStep
            // 
            this.buttonStepbyStep.Location = new System.Drawing.Point(613, 43);
            this.buttonStepbyStep.Name = "buttonStepbyStep";
            this.buttonStepbyStep.Size = new System.Drawing.Size(88, 23);
            this.buttonStepbyStep.TabIndex = 10;
            this.buttonStepbyStep.Text = "Step-by-Step";
            this.buttonStepbyStep.UseVisualStyleBackColor = true;
            this.buttonStepbyStep.Click += new System.EventHandler(this.buttonStepbyStep_Click);
            // 
            // dataGridViewSimulacao
            // 
            this.dataGridViewSimulacao.AllowUserToAddRows = false;
            this.dataGridViewSimulacao.AllowUserToDeleteRows = false;
            this.dataGridViewSimulacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSimulacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimulacao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSimulacao.Location = new System.Drawing.Point(12, 237);
            this.dataGridViewSimulacao.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.dataGridViewSimulacao.Name = "dataGridViewSimulacao";
            this.dataGridViewSimulacao.ReadOnly = true;
            this.dataGridViewSimulacao.Size = new System.Drawing.Size(853, 213);
            this.dataGridViewSimulacao.TabIndex = 11;
            // 
            // labelPrioridade
            // 
            this.labelPrioridade.AutoSize = true;
            this.labelPrioridade.Location = new System.Drawing.Point(168, 29);
            this.labelPrioridade.Name = "labelPrioridade";
            this.labelPrioridade.Size = new System.Drawing.Size(54, 13);
            this.labelPrioridade.TabIndex = 13;
            this.labelPrioridade.Text = "Prioridade";
            // 
            // textBoxPrioridade
            // 
            this.textBoxPrioridade.Location = new System.Drawing.Point(168, 45);
            this.textBoxPrioridade.Name = "textBoxPrioridade";
            this.textBoxPrioridade.Size = new System.Drawing.Size(46, 20);
            this.textBoxPrioridade.TabIndex = 12;
            this.textBoxPrioridade.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quantum";
            // 
            // textBoxQuantum
            // 
            this.textBoxQuantum.Location = new System.Drawing.Point(720, 45);
            this.textBoxQuantum.Name = "textBoxQuantum";
            this.textBoxQuantum.Size = new System.Drawing.Size(46, 20);
            this.textBoxQuantum.TabIndex = 14;
            this.textBoxQuantum.Text = "2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FIFO",
            "Round-Robin"});
            this.comboBox1.Location = new System.Drawing.Point(474, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Algoritmo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 462);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxQuantum);
            this.Controls.Add(this.labelPrioridade);
            this.Controls.Add(this.textBoxPrioridade);
            this.Controls.Add(this.dataGridViewSimulacao);
            this.Controls.Add(this.buttonStepbyStep);
            this.Controls.Add(this.buttonSimular);
            this.Controls.Add(this.listBoxRetorno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDuracao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInicio);
            this.Controls.Add(this.buttonAddProcesso);
            this.Controls.Add(this.dataGridViewProcessos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcessos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimulacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProcessos;
        private System.Windows.Forms.Button buttonAddProcesso;
        private System.Windows.Forms.TextBox textBoxInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDuracao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxRetorno;
        private System.Windows.Forms.Button buttonSimular;
        private System.Windows.Forms.Button buttonStepbyStep;
        private System.Windows.Forms.DataGridView dataGridViewSimulacao;
        private System.Windows.Forms.Label labelPrioridade;
        private System.Windows.Forms.TextBox textBoxPrioridade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxQuantum;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
    }
}


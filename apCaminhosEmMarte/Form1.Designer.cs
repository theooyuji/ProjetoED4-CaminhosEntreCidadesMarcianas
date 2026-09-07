namespace apCaminhosEmMarte
{
  partial class FrmCaminhos
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRecursao = new System.Windows.Forms.RadioButton();
            this.rbPilhas = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPreco = new System.Windows.Forms.RadioButton();
            this.rbTempo = new System.Windows.Forms.RadioButton();
            this.rbDistancia = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlMapa = new System.Windows.Forms.Panel();
            this.lbOrigem = new System.Windows.Forms.Label();
            this.lbDestino = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAcharCaminho = new System.Windows.Forms.Button();
            this.lbMelhorCaminho = new System.Windows.Forms.Label();
            this.lbCaminhosEncontrados = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.DefaultExt = "*.txt";
            this.dlgAbrir.InitialDirectory = "c:\\temp";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.rbRecursao);
            this.groupBox1.Controls.Add(this.rbPilhas);
            this.groupBox1.Location = new System.Drawing.Point(228, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Técnica de Busca Desejada";
            // 
            // rbRecursao
            // 
            this.rbRecursao.AutoSize = true;
            this.rbRecursao.Location = new System.Drawing.Point(107, 24);
            this.rbRecursao.Name = "rbRecursao";
            this.rbRecursao.Size = new System.Drawing.Size(71, 17);
            this.rbRecursao.TabIndex = 1;
            this.rbRecursao.Text = "Recursão";
            this.rbRecursao.UseVisualStyleBackColor = true;
            // 
            // rbPilhas
            // 
            this.rbPilhas.AutoSize = true;
            this.rbPilhas.Checked = true;
            this.rbPilhas.Location = new System.Drawing.Point(18, 24);
            this.rbPilhas.Name = "rbPilhas";
            this.rbPilhas.Size = new System.Drawing.Size(53, 17);
            this.rbPilhas.TabIndex = 0;
            this.rbPilhas.TabStop = true;
            this.rbPilhas.Text = "Pilhas";
            this.rbPilhas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.rbPreco);
            this.groupBox2.Controls.Add(this.rbTempo);
            this.groupBox2.Controls.Add(this.rbDistancia);
            this.groupBox2.Location = new System.Drawing.Point(562, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 51);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Critério de peso desejado";
            // 
            // rbPreco
            // 
            this.rbPreco.AutoSize = true;
            this.rbPreco.Location = new System.Drawing.Point(186, 24);
            this.rbPreco.Name = "rbPreco";
            this.rbPreco.Size = new System.Drawing.Size(53, 17);
            this.rbPreco.TabIndex = 2;
            this.rbPreco.Text = "Preço";
            this.rbPreco.UseVisualStyleBackColor = true;
            // 
            // rbTempo
            // 
            this.rbTempo.AutoSize = true;
            this.rbTempo.Location = new System.Drawing.Point(107, 24);
            this.rbTempo.Name = "rbTempo";
            this.rbTempo.Size = new System.Drawing.Size(58, 17);
            this.rbTempo.TabIndex = 1;
            this.rbTempo.Text = "Tempo";
            this.rbTempo.UseVisualStyleBackColor = true;
            // 
            // rbDistancia
            // 
            this.rbDistancia.AutoSize = true;
            this.rbDistancia.Checked = true;
            this.rbDistancia.Location = new System.Drawing.Point(18, 24);
            this.rbDistancia.Name = "rbDistancia";
            this.rbDistancia.Size = new System.Drawing.Size(69, 17);
            this.rbDistancia.TabIndex = 0;
            this.rbDistancia.TabStop = true;
            this.rbDistancia.Text = "Distância";
            this.rbDistancia.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 445);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(846, 60);
            this.dataGridView1.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(111, 148);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(111, 291);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // pnlMapa
            // 
            this.pnlMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMapa.BackgroundImage = global::apCaminhosEmMarte.Properties.Resources.Mapa_Marte_sem_rotas;
            this.pnlMapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMapa.Location = new System.Drawing.Point(228, 76);
            this.pnlMapa.Name = "pnlMapa";
            this.pnlMapa.Size = new System.Drawing.Size(630, 363);
            this.pnlMapa.TabIndex = 10;
            // 
            // lbOrigem
            // 
            this.lbOrigem.AutoSize = true;
            this.lbOrigem.Location = new System.Drawing.Point(115, 66);
            this.lbOrigem.Name = "lbOrigem";
            this.lbOrigem.Size = new System.Drawing.Size(43, 13);
            this.lbOrigem.TabIndex = 11;
            this.lbOrigem.Text = "Origem:";
            this.lbOrigem.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbDestino
            // 
            this.lbDestino.AutoSize = true;
            this.lbDestino.Location = new System.Drawing.Point(12, 66);
            this.lbDestino.Name = "lbDestino";
            this.lbDestino.Size = new System.Drawing.Size(46, 13);
            this.lbDestino.TabIndex = 12;
            this.lbDestino.Text = "Destino:";
            this.lbDestino.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            // 
            // btnAcharCaminho
            // 
            this.btnAcharCaminho.Location = new System.Drawing.Point(12, 148);
            this.btnAcharCaminho.Name = "btnAcharCaminho";
            this.btnAcharCaminho.Size = new System.Drawing.Size(88, 49);
            this.btnAcharCaminho.TabIndex = 15;
            this.btnAcharCaminho.Text = "Achar caminho";
            this.btnAcharCaminho.UseVisualStyleBackColor = true;
            this.btnAcharCaminho.Click += new System.EventHandler(this.btnAcharCaminho_Click);
            // 
            // lbMelhorCaminho
            // 
            this.lbMelhorCaminho.AutoSize = true;
            this.lbMelhorCaminho.Location = new System.Drawing.Point(108, 132);
            this.lbMelhorCaminho.Name = "lbMelhorCaminho";
            this.lbMelhorCaminho.Size = new System.Drawing.Size(82, 13);
            this.lbMelhorCaminho.TabIndex = 2;
            this.lbMelhorCaminho.Text = "Melhor caminho";
            this.lbMelhorCaminho.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbCaminhosEncontrados
            // 
            this.lbCaminhosEncontrados.AutoSize = true;
            this.lbCaminhosEncontrados.Location = new System.Drawing.Point(9, 429);
            this.lbCaminhosEncontrados.Name = "lbCaminhosEncontrados";
            this.lbCaminhosEncontrados.Size = new System.Drawing.Size(115, 13);
            this.lbCaminhosEncontrados.TabIndex = 16;
            this.lbCaminhosEncontrados.Text = "Caminhos encontrados";
            this.lbCaminhosEncontrados.Click += new System.EventHandler(this.lbCaminhosEncontrados_Click);
            // 
            // FrmCaminhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.lbCaminhosEncontrados);
            this.Controls.Add(this.lbMelhorCaminho);
            this.Controls.Add(this.btnAcharCaminho);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbDestino);
            this.Controls.Add(this.lbOrigem);
            this.Controls.Add(this.pnlMapa);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCaminhos";
            this.Text = "Caminhos Em Marte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCaminhos_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRecursao;
        private System.Windows.Forms.RadioButton rbPilhas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbPreco;
        private System.Windows.Forms.RadioButton rbTempo;
        private System.Windows.Forms.RadioButton rbDistancia;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlMapa;
        private System.Windows.Forms.Label lbOrigem;
        private System.Windows.Forms.Label lbDestino;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnAcharCaminho;
        private System.Windows.Forms.Label lbMelhorCaminho;
        private System.Windows.Forms.Label lbCaminhosEncontrados;
    }
}


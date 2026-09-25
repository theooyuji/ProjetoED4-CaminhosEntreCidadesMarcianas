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
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.dgvMelhorCaminho = new System.Windows.Forms.DataGridView();
            this.lbOrigem = new System.Windows.Forms.Label();
            this.lbDestino = new System.Windows.Forms.Label();
            this.btnAcharCaminho = new System.Windows.Forms.Button();
            this.lbMelhorCaminho = new System.Windows.Forms.Label();
            this.lbCaminhosEncontrados = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.pnlMapa = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).BeginInit();
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
            this.rbPreco.CheckedChanged += new System.EventHandler(this.VerificaCriterio);
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
            this.rbTempo.CheckedChanged += new System.EventHandler(this.VerificaCriterio);
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
            this.rbDistancia.CheckedChanged += new System.EventHandler(this.VerificaCriterio);
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.AllowUserToAddRows = false;
            this.dgvCaminhos.AllowUserToDeleteRows = false;
            this.dgvCaminhos.AllowUserToResizeColumns = false;
            this.dgvCaminhos.AllowUserToResizeRows = false;
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(12, 445);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.ReadOnly = true;
            this.dgvCaminhos.Size = new System.Drawing.Size(846, 60);
            this.dgvCaminhos.TabIndex = 8;
            this.dgvCaminhos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaminhos_CellClick);
            // 
            // dgvMelhorCaminho
            // 
            this.dgvMelhorCaminho.AllowUserToAddRows = false;
            this.dgvMelhorCaminho.AllowUserToDeleteRows = false;
            this.dgvMelhorCaminho.AllowUserToResizeColumns = false;
            this.dgvMelhorCaminho.AllowUserToResizeRows = false;
            this.dgvMelhorCaminho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMelhorCaminho.Location = new System.Drawing.Point(111, 128);
            this.dgvMelhorCaminho.Name = "dgvMelhorCaminho";
            this.dgvMelhorCaminho.ReadOnly = true;
            this.dgvMelhorCaminho.Size = new System.Drawing.Size(111, 311);
            this.dgvMelhorCaminho.TabIndex = 9;
            this.dgvMelhorCaminho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PintaMelhorCaminho);
            // 
            // lbOrigem
            // 
            this.lbOrigem.AutoSize = true;
            this.lbOrigem.Location = new System.Drawing.Point(9, 60);
            this.lbOrigem.Name = "lbOrigem";
            this.lbOrigem.Size = new System.Drawing.Size(43, 13);
            this.lbOrigem.TabIndex = 11;
            this.lbOrigem.Text = "Origem:";
            // 
            // lbDestino
            // 
            this.lbDestino.AutoSize = true;
            this.lbDestino.Location = new System.Drawing.Point(122, 60);
            this.lbDestino.Name = "lbDestino";
            this.lbDestino.Size = new System.Drawing.Size(46, 13);
            this.lbDestino.TabIndex = 12;
            this.lbDestino.Text = "Destino:";
            // 
            // btnAcharCaminho
            // 
            this.btnAcharCaminho.Location = new System.Drawing.Point(12, 128);
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
            this.lbMelhorCaminho.Location = new System.Drawing.Point(108, 112);
            this.lbMelhorCaminho.Name = "lbMelhorCaminho";
            this.lbMelhorCaminho.Size = new System.Drawing.Size(82, 13);
            this.lbMelhorCaminho.TabIndex = 2;
            this.lbMelhorCaminho.Text = "Melhor caminho";
            // 
            // lbCaminhosEncontrados
            // 
            this.lbCaminhosEncontrados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCaminhosEncontrados.AutoSize = true;
            this.lbCaminhosEncontrados.Location = new System.Drawing.Point(9, 429);
            this.lbCaminhosEncontrados.Name = "lbCaminhosEncontrados";
            this.lbCaminhosEncontrados.Size = new System.Drawing.Size(115, 13);
            this.lbCaminhosEncontrados.TabIndex = 16;
            this.lbCaminhosEncontrados.Text = "Caminhos encontrados";
            // 
            // cbDestino
            // 
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(125, 76);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(97, 21);
            this.cbDestino.TabIndex = 17;
            // 
            // cbOrigem
            // 
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(12, 76);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(97, 21);
            this.cbOrigem.TabIndex = 18;
            // 
            // pnlMapa
            // 
            this.pnlMapa.BackgroundImage = global::apCaminhosEmMarte.Properties.Resources.Mapa_Marte_sem_rotas_sem_cidades1;
            this.pnlMapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMapa.Location = new System.Drawing.Point(228, 76);
            this.pnlMapa.Name = "pnlMapa";
            this.pnlMapa.Size = new System.Drawing.Size(630, 363);
            this.pnlMapa.TabIndex = 10;
            this.pnlMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapa_Paint);
            this.pnlMapa.Resize += new System.EventHandler(this.pnlMapa_Resize);
            // 
            // FrmCaminhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.cbOrigem);
            this.Controls.Add(this.cbDestino);
            this.Controls.Add(this.lbCaminhosEncontrados);
            this.Controls.Add(this.lbMelhorCaminho);
            this.Controls.Add(this.btnAcharCaminho);
            this.Controls.Add(this.lbDestino);
            this.Controls.Add(this.lbOrigem);
            this.Controls.Add(this.pnlMapa);
            this.Controls.Add(this.dgvMelhorCaminho);
            this.Controls.Add(this.dgvCaminhos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCaminhos";
            this.Text = "Caminhos Em Marte";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.DataGridView dgvMelhorCaminho;
        private System.Windows.Forms.Panel pnlMapa;
        private System.Windows.Forms.Label lbOrigem;
        private System.Windows.Forms.Label lbDestino;
        private System.Windows.Forms.Button btnAcharCaminho;
        private System.Windows.Forms.Label lbMelhorCaminho;
        private System.Windows.Forms.Label lbCaminhosEncontrados;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.ComboBox cbOrigem;
    }
}


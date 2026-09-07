using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosEmMarte
{
  public partial class FrmCaminhos : Form
  {
    public FrmCaminhos()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnAbrirArquivo_Click(object sender, EventArgs e)
    {
      if (dlgAbrir.ShowDialog() == DialogResult.OK)
      {
        // verificamos qual a técnica de Hash escolhida
        // pelo usuário e criamos uma tabela de hash de
        // acordo com essa escolha
  

        // abrimos o arquivo escolhido
        var asCidades = new StreamReader(dlgAbrir.FileName);
        // ler registros do arquivo aberto
        while (!asCidades.EndOfStream)
        {
          // instanciar um objeto cidade
          // lê-lo do arquivo para preencher seus atributos
          // armazenar esse objeto na tabela de Hash
          // de acordo com a técnica de hash escolhida
          // pelo usuário
        }
        // Desenhar os nomes das cidades no mapa de Marte
        asCidades.Close();  // deixar arquivo fechado
      }
    }

    private void FrmCaminhos_FormClosing(object sender, FormClosingEventArgs e)
    {
      // aqui, a tabela de hash deve ser percorrida e os 
      // registros armazenados devem ser gravados no arquivo
      // agora, aberto para saída (StreamWriter).
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAcharCaminho_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbCaminhosEncontrados_Click(object sender, EventArgs e)
        {

        }
    }
}

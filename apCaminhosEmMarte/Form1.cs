using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosEmMarte
{
    public partial class FrmCaminhos : Form
    {
        const int tamanhoVetor = 100;
        Ligacao[,] matrizAdjacencia;
        Cidade[] cidades;
        int qtasCidades;
        public FrmCaminhos()
        {
              InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cidades = new Cidade[tamanhoVetor];
            matrizAdjacencia = new Ligacao[tamanhoVetor, tamanhoVetor];
            qtasCidades = 0;
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            dlgAbrir.Title = "Selecione o arquivo de cidades";

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
                    Cidade novaCidade = new Cidade();
                    
                    if (novaCidade.LerRegistro(asCidades))
                    {
                        qtasCidades++;
                        InserirEmOrdem(novaCidade);
                    }
                }
                
                // Desenhar os nomes das cidades no mapa de Marte
                asCidades.Close();  // deixar arquivo fechado
            }

            dlgAbrir.Title = "Seleciona o arquivo de ligações";

            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arqLigacoes = new StreamReader(dlgAbrir.FileName);
                while (!arqLigacoes.EndOfStream)
                {
                    Ligacao novaLigacao = new Ligacao();
                    if (novaLigacao.LerRegistro(arqLigacoes))
                    {
                        InserirEmOrdem(novaLigacao);
                    }

                }
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


        private void InserirEmOrdem(Cidade cidade)
        {
            int onde = 0;
            if(ProcuraCidade(cidade,out onde) || qtasCidades + 1 > cidades.Length)
            {
                return;
            }
            for(int i = qtasCidades - 1; i >= onde; i--) {
                cidades[i + 1] = cidades[i];
            }
            cidades[onde] = cidade;
        }
        
        private void InserirEmOrdem(Ligacao ligacao)
        {
            int ondeIni;
            int ondeFim;
            if(!ProcuraCidade(new Cidade(ligacao.IdInicio), out ondeIni) || !ProcuraCidade(new Cidade(ligacao.IdFim),out ondeFim))
            {
                return;
            }

            if(ondeIni >= matrizAdjacencia.Length || ondeFim >= matrizAdjacencia.Length)
            {
                return;
            }

            matrizAdjacencia[ondeIni, ondeFim] = ligacao;
            matrizAdjacencia[ondeFim, ondeIni] = ligacao;
        }
        
        private bool ProcuraCidade(Cidade proc, out int onde)
        {
            int ini = 0;
            int fim = qtasCidades - 1;
            while(ini < fim)
            {
                onde = ini + (fim - ini) / 2;
                int comparacao = cidades[onde].CompareTo(proc);
                if ( comparacao == 0)
                {
                    return true;
                }
                else if(comparacao < 0)
                {
                    ini = onde + 1;
                }
                else
                {
                    fim = onde - 1;
                }
            }
            onde = ini;
            return false;
        }


        private List<List<Ligacao>> ProcuraCaminhoPilha(int idIni,int idFim)
        {
            List<List<Ligacao>> caminhosTotais = new List<List<Ligacao>>();
            PilhaLista<Ligacao> pilhaBacktracking = new PilhaLista<Ligacao>();
            
            bool[] visitados = new bool[tamanhoVetor];
   
            int indOrigem = 0,indDestino = 0,indFinal = 0;

            ProcuraCidade(new Cidade(idIni), out indOrigem);
            ProcuraCidade(new Cidade(idFim), out indFinal);

            int indCidade = indOrigem;

            bool podeContinuar = true;
            while (podeContinuar)
            {
                podeContinuar = !(indCidade == indOrigem && indDestino == tamanhoVetor && pilhaBacktracking.EstaVazia);
                bool achouCaminho = false;

                if (podeContinuar)
                {
                    while((indDestino < tamanhoVetor) && !achouCaminho)
                    {
                        if (matrizAdjacencia[indCidade,indDestino] == null)
                        {
                            indDestino++;
                        }
                        else
                        {
                            if (visitados[indDestino])
                            {
                                indDestino++;
                            }
                            else
                            {
                                if(indDestino == indFinal) {

                                    pilhaBacktracking.Empilhar(matrizAdjacencia[indCidade, indDestino]);

                                    caminhosTotais.Add(pilhaBacktracking.ConteudoInvertido());
                                    pilhaBacktracking.Desempilhar();

                                    visitados[indFinal] = false;
                                    achouCaminho = true;
                                    indDestino++;
                                }
                                else
                                {

                                    pilhaBacktracking.Empilhar(matrizAdjacencia[indCidade, indDestino]);

                                    visitados[indCidade] = true;
                                    indDestino = 0;
                                    ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdFim), out indCidade);

                                }
                            }
                        }
                    }
                    if (!achouCaminho)
                    {
                        visitados[indCidade] = false;
                        ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdInicio), out indCidade);
                        ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdFim), out indDestino);
                        indDestino++;

                        pilhaBacktracking.Desempilhar();
                    }
                }
            }

            return caminhosTotais;
        }
    }
}

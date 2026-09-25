using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosEmMarte
{
    public partial class FrmCaminhos : Form
    {
        const int tamanhoVetor = 25;
        
        private Ligacao[,] matrizAdjacencia;
        private Cidade[] cidades;
        private int qtasCidades;
        
        private CriteriosSeparacao criterioAtual;
        private List<List<Ligacao>> caminhos;
        
        private int indFinal;
        private int indCaminhoAtual;
        private int indMelhorCaminho;

        private bool desenhaCaminhos = false;

        private const float tamanhoCirculo = 10f;

        public FrmCaminhos()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cidades = new Cidade[tamanhoVetor];
            matrizAdjacencia = new Ligacao[tamanhoVetor, tamanhoVetor];
            qtasCidades = 0;
            caminhos = null;

           if(!LeuArquivoCidades() || !LeuArquivoLigacoes())
            {
                MessageBox.Show("Erro ao ler arquivos", "Abortando programa", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
                return;
            }


            PreencheCbCidades(ref cbOrigem);
            PreencheCbCidades(ref cbDestino);

            pnlMapa.Invalidate();
        }

        private bool LeuArquivoCidades()
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
                        InserirEmOrdem(novaCidade);
                    }
                    else
                    {
                        return false;
                    }
                }

                // Desenhar os nomes das cidades no mapa de Marte
                asCidades.Close();
                return true;// deixar arquivo fechado
            }
            return false;
        }

        private bool LeuArquivoLigacoes()
        {
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
                    else
                    {
                        return false;
                    }

                }

                return true;
            }

            return false;

        }

        private void PreencheCbCidades(ref ComboBox cb)
        {
            for(int i = 0; i < qtasCidades; i++)
            {
                if (cidades[i] == null)
                {
                    continue;
                }
                cb.Items.Add(cidades[i]);
            }
            cb.DisplayMember = "Nome";

            cb.SelectedIndex = 0;
        }

        private void btnAcharCaminho_Click(object sender, EventArgs e)
        {
            Cidade cidadeOrigem = (Cidade)cbOrigem.SelectedItem;
            Cidade cidadeDestino = (Cidade)cbDestino.SelectedItem;

            if (cidadeOrigem.CompareTo(cidadeDestino) == 0)
            {
                MessageBox.Show("Selecione cidades difentes", "Erro ao encontrar caminhos entre cidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcuraCidade(cidadeDestino, out indFinal);

            caminhos = new List<List<Ligacao>>();

            if (rbPilhas.Checked)
            {
                ProcuraCaminhoPilha(cidadeOrigem.Id);
            }
            else
            {
                int indOrigem = 0;
                ProcuraCidade(cidadeOrigem, out indOrigem);
                ProcuraCaminhoRecursivo(indOrigem, new List<Ligacao>(), new bool[tamanhoVetor]);
            }

            ExibirCaminhos();
        }
        
        private void ExibirCaminhos()
        {
            indMelhorCaminho = 1;
            int melhorParametro = int.MaxValue;
            int tamanhoMaiorCaminho = 0;

            dgvCaminhos.Columns.Clear();
            dgvCaminhos.Rows.Clear();

            if(caminhos == null)
            {
                MessageBox.Show("Não existem caminhos entre as cidades selecionadas !", "Erro ao encontrar caminho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach(List<Ligacao> caminho in caminhos)
            {
                if(caminho.Count > tamanhoMaiorCaminho)
                {
                    tamanhoMaiorCaminho = caminho.Count;
                }
            }

            for(int i = 0; i <= tamanhoMaiorCaminho; i++)
            {
                dgvCaminhos.Columns.Add("col" + i, $"{i+1}a");
            }

            int indCidadeIni = 0;
            int indCidadeFim = 0;
            int parametroAtual = 0;
            int colunaAtual = 0;
            List<Cidade> cidadesVistas = new List<Cidade>();
            foreach (List<Ligacao> caminho in caminhos)
            {
                 int linhaAtual = dgvCaminhos.Rows.Add();
                 indCidadeIni = 0;
                 indCidadeFim = 0;
                 parametroAtual = 0;
                 colunaAtual = 0;

                cidadesVistas = new List<Cidade>(); 
                
                foreach(Ligacao lig in caminho)
                {
                    parametroAtual += lig.AcessarCriterioSeparacao(criterioAtual);
                    
                    ProcuraCidade(new Cidade(lig.IdInicio), out indCidadeIni);
                    ProcuraCidade(new Cidade(lig.IdFim), out indCidadeFim);

                    
                    if (cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeIni]) == 0) == default(Cidade))
                    {
                        dgvCaminhos[colunaAtual++,linhaAtual].Value = cidades[indCidadeIni].Nome;
                        cidadesVistas.Add(cidades[indCidadeIni]);
                    }
                    if (cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeFim]) == 0) == default(Cidade))
                    {
                        dgvCaminhos[colunaAtual++, linhaAtual].Value = cidades[indCidadeFim].Nome;
                        cidadesVistas.Add(cidades[indCidadeFim]);

                    }
                }
                if(parametroAtual < melhorParametro)
                {
                    indMelhorCaminho = linhaAtual;
                }
            }

            ExibirMelhorCaminho(indMelhorCaminho);
        }

        private void ExibirMelhorCaminho(int indMelhorCaminho)
        {

            dgvMelhorCaminho.Columns.Clear();
            dgvMelhorCaminho.Rows.Clear();

            dgvMelhorCaminho.Columns.Add("melhorCaminho", "Passando por");
      
            List<Ligacao> melhorCaminho = caminhos[indMelhorCaminho];

            int indCidadeIni = 0;
            int indCidadeFim = 0;
            int somaParametro = 0;

            List<Cidade> cidadesVistas = new List<Cidade>();
            
            foreach(Ligacao lig in melhorCaminho)
            {
                int indLinha;
                somaParametro += lig.AcessarCriterioSeparacao(criterioAtual);

                ProcuraCidade(new Cidade(lig.IdInicio), out indCidadeIni);
                ProcuraCidade(new Cidade(lig.IdFim), out indCidadeFim);

                if (cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeIni]) == 0) == default(Cidade))
                {
                    indLinha = dgvMelhorCaminho.Rows.Add();
                    dgvMelhorCaminho.Rows[indLinha].Cells[0].Value = cidades[indCidadeIni].Nome;
                    cidadesVistas.Add(cidades[indCidadeIni]);
                }
                if (cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeFim]) == 0) == default(Cidade))
                {
                    indLinha = dgvMelhorCaminho.Rows.Add();
                    dgvMelhorCaminho.Rows[indLinha].Cells[0].Value = cidades[indCidadeFim].Nome;
                    cidadesVistas.Add(cidades[indCidadeFim]);

                }
            }

            switch (criterioAtual)
            {
                case CriteriosSeparacao.Distancia: lbMelhorCaminho.Text = $"Melhor caminho {somaParametro}km";break;
                case CriteriosSeparacao.Tempo: lbMelhorCaminho.Text = $"Melhor caminho {somaParametro}h";break;
                case CriteriosSeparacao.Custo:lbMelhorCaminho.Text = $"Melhor caminho {somaParametro}$";break;
            }
        }

        private void VerificaCriterio(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "rbDistancia":criterioAtual = CriteriosSeparacao.Distancia;break;
                    case "rbTempo":criterioAtual = CriteriosSeparacao.Tempo;break;
                    case "rbPreco":criterioAtual = CriteriosSeparacao.Custo;break;
                }
            }
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
            qtasCidades++;
        }
        
        private void InserirEmOrdem(Ligacao ligacao)
        {
            int ondeIni;
            int ondeFim;

            if(!(ProcuraCidade(new Cidade(ligacao.IdInicio), out ondeIni) && ProcuraCidade(new Cidade(ligacao.IdFim),out ondeFim)))
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

            while(ini <= fim)
            {
                onde = ini + (fim - ini) / 2;
                int comparacao = cidades[onde].CompareTo(proc);
                if (comparacao == 0)
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


        private void ProcuraCaminhoPilha(int idIni)
        {
            PilhaLista<Ligacao> pilhaBacktracking = new PilhaLista<Ligacao>();
            
            bool[] visitados = new bool[tamanhoVetor];
   
            int indOrigem = 0,indDestino = 0;

            ProcuraCidade(new Cidade(idIni), out indOrigem);
    
            int indCidade = indOrigem;

            bool podeContinuar = true;
            while (podeContinuar)
            {
                podeContinuar = !(indCidade == indOrigem && indDestino == qtasCidades && pilhaBacktracking.EstaVazia);
                bool achouCaminho = false;

                if (podeContinuar)
                {
                    while((indDestino < qtasCidades) && !achouCaminho)
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

                                    caminhos.Add(pilhaBacktracking.ConteudoInvertido());
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
                                    ProcuraCidade(new Cidade((pilhaBacktracking.OTopo().IdFim != cidades[indCidade].Id) ? pilhaBacktracking.OTopo().IdFim : pilhaBacktracking.OTopo().IdInicio), out indCidade);

                                }
                            }
                        }
                    }
                    if (!achouCaminho)
                    {
                        visitados[indCidade] = false;
                        if (!pilhaBacktracking.EstaVazia)
                        {
                            int orig = indCidade;

                            Ligacao topo = pilhaBacktracking.OTopo();
                            int idFim = (topo.IdInicio == cidades[indCidade].Id) ? topo.IdFim : topo.IdInicio;

                            ProcuraCidade(new Cidade(idFim), out indCidade);

                            indDestino = orig + 1;

                            pilhaBacktracking.Desempilhar();
                        }
                    }
                }
            }
        }

        private void ProcuraCaminhoRecursivo(int orig,List<Ligacao> caminhoAtual,bool[] visitados)
        {
            if(orig == indFinal)
            {
                caminhos.Add(new List<Ligacao>(caminhoAtual));
            }
            else
            {
                for(int i = 0; i < tamanhoVetor; i++)
                {
                    if (visitados[i] || matrizAdjacencia[orig,i] == null)
                    {
                        continue;
                    }

                    caminhoAtual.Add(matrizAdjacencia[orig, i]);
                    visitados[i] = true;

                    ProcuraCaminhoRecursivo(i, caminhoAtual, visitados);

                    caminhoAtual.RemoveAt(caminhoAtual.Count - 1);
                    visitados[i] = false;
                }
            }
        }
        private void pnlMapa_Paint(object sender, PaintEventArgs e)
        {
            
            DesenhaCidades(e.Graphics);

            if (desenhaCaminhos)
            {
                DesenhaCaminho(e.Graphics);
            }
        }

        private void PintaMelhorCaminho(object sender, DataGridViewCellEventArgs e)
        {
            desenhaCaminhos = true;
            indCaminhoAtual = indMelhorCaminho;
            pnlMapa.Invalidate();
        }

        private void DesenhaCaminho(Graphics g)
        {
            if (caminhos.Count < indCaminhoAtual)
            {
                return;
            }

            List<Ligacao> caminhoSelecionado = caminhos[indCaminhoAtual];

            float tamanhoXMapa = pnlMapa.Width;
            float tamanhoYMapa = pnlMapa.Height;
            
            Pen pen = new Pen(Brushes.Red,4f);
            foreach(Ligacao lig in caminhoSelecionado)
            {
                int indCidadeIni = 0;
                int indCidadeFim = 0;

                ProcuraCidade(new Cidade(lig.IdInicio), out indCidadeIni);
                ProcuraCidade(new Cidade(lig.IdFim), out indCidadeFim);

                float coordenadaX1 = (float)cidades[indCidadeIni].CordX * tamanhoXMapa;
                float coordenadaY1 = (float)cidades[indCidadeIni].CordY * tamanhoYMapa;

                float coordenadaX2 = (float)cidades[indCidadeFim].CordX * tamanhoXMapa;
                float coordenadaY2 = (float)cidades[indCidadeFim].CordY * tamanhoYMapa;

                g.DrawLine(pen, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2);
            }
        }

        private void DesenhaCidades(Graphics g)
        {

            if(cidades == null)
            {
                return;
            }

            float tamanhoMapaX = pnlMapa.Width;
            float tamanhoMapaY = pnlMapa.Height;

            for(int i = 0; i < qtasCidades; i++)
            {
                float coordenadaXCidade = (float)cidades[i].CordX * tamanhoMapaX;
                float coordenadaYCidade = (float)cidades[i].CordY * tamanhoMapaY;

                g.DrawEllipse(Pens.Black, coordenadaXCidade - (tamanhoCirculo / 2), coordenadaYCidade - (tamanhoCirculo / 2), tamanhoCirculo, tamanhoCirculo);
                g.FillEllipse(Brushes.Black, coordenadaXCidade - (tamanhoCirculo / 2), coordenadaYCidade - (tamanhoCirculo / 2), tamanhoCirculo, tamanhoCirculo);
                g.DrawString(cidades[i].Nome, Font, Brushes.Black, coordenadaXCidade - tamanhoCirculo, coordenadaYCidade + tamanhoCirculo / 2);
            }

        }   

        private void pnlMapa_Resize(object sender, EventArgs e)
        {
            desenhaCaminhos = true;
            pnlMapa.Invalidate();
        }

        private void dgvCaminhos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indCaminhoAtual = dgvCaminhos.SelectedCells[0].RowIndex;
            desenhaCaminhos = true;
            pnlMapa.Invalidate();
        }

        
    }
}

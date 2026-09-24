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
            }


            PreencheCbCidades(ref cbOrigem);
            PreencheCbCidades(ref cbDestino);
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
                        qtasCidades++;
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
        }

        private void btnAcharCaminho_Click(object sender, EventArgs e)
        {
            Cidade cidadeOrigem = (Cidade)cbOrigem.SelectedItem;
            Cidade cidadeDestino = (Cidade)cbDestino.SelectedItem;

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
            int indCaminhoAtual = 1;
            int indMelhorCaminho = 1;
            int melhorParametro = int.MaxValue;

            dgvCaminhos.Columns.Clear();
            dgvCaminhos.Rows.Clear();

            if(caminhos == null)
            {
                MessageBox.Show("Não existem caminhos entre as cidades selecionadas !", "Erro ao encontrar caminho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach(List<Ligacao> caminho in caminhos)
            {
                dgvCaminhos.Columns.Add("NumeroCaminho" + indCaminhoAtual, $"{indCaminhoAtual}a");
                
                int parametroAtual = 0;
                int linhaAtual = 0;
                int indCidadeIni = 0;
                int indCidadeFim = 0;
                List<Cidade> cidadesVistas = new List<Cidade>();
                foreach(Ligacao lig in caminho)
                {
                    parametroAtual += lig.AcessarCriterioSeparacao(criterioAtual);
                    
                    
                    ProcuraCidade(new Cidade(lig.IdInicio), out indCidadeIni);
                    ProcuraCidade(new Cidade(lig.IdFim), out indCidadeFim);

                    if (cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeIni]) == 0) == default(Cidade))
                    {
                        dgvCaminhos.Rows.Add();
                        dgvCaminhos.Rows[linhaAtual++].Cells[indCaminhoAtual - 1].Value = cidades[indCidadeIni].Nome;
                    }
                    if(cidadesVistas.Find(c => c.CompareTo(cidades[indCidadeFim]) == 0) == default(Cidade))
                    { 
                        dgvCaminhos.Rows.Add();
                        dgvCaminhos.Rows[linhaAtual++].Cells[indCaminhoAtual - 1].Value = cidades[indCidadeFim].Nome;
                    }

                    cidadesVistas.Add(cidades[indCidadeIni]);
                    cidadesVistas.Add(cidades[indCidadeFim]);
                }


                if(parametroAtual < melhorParametro)
                {
                    indMelhorCaminho = indCaminhoAtual;
                }
                indCaminhoAtual++;

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
                    case "rbCusto":criterioAtual = CriteriosSeparacao.Custo;break;
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

            if(ini == fim)
            {
                onde = ini;
                return false;
            }

            while(ini <= fim)
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
                                    ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdFim), out indCidade);

                                }
                            }
                        }
                    }
                    if (!achouCaminho)
                    {
                        visitados[indCidade] = false;
                        if (!pilhaBacktracking.EstaVazia)
                        {
                            ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdInicio), out indCidade);
                            ProcuraCidade(new Cidade(pilhaBacktracking.OTopo().IdFim), out indDestino);
                            indDestino++;

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

        }
    }
}

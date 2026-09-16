using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class PilhaLista<T> : IStack<T>
             where T : IComparable<T>, IRegistro<T>, new()
{
    NoLista<T> topo;        // primeiro nó da lista/pilha
    int tamanho;

    public PilhaLista()
    {
        topo = null;
        tamanho = 0;
    }

    public int Tamanho { get => tamanho; }
    public bool EstaVazia { get => topo == null; }

    public void Empilhar(T dado)
    {
        // Instancia um nó, coloca o Dado o nele e o liga ao antigo topo da pilha
        NoLista<T> novoNo = new NoLista<T>(dado, topo);
        topo = novoNo;          // topo passa a apontar o novo nó
        tamanho++;              // atualiza número de elementos na pilha
    }
    public T OTopo()
    {
        if (EstaVazia)
            throw new Exception("Underflow da pilha");
        return topo.Info;
    }
    public T Desempilhar()
    {
        if (EstaVazia)
            throw new Exception("Underflow da pilha");
        T dado = topo.Info;  // obtém o objeto do topo
        topo = topo.Prox;    // avança topo para o nó seguinte
        tamanho--;           // atualiza número de elementos na pilha
        return dado;         // devolve o objeto que estava no topo
    }

    public List<T> Conteudo()
    {
        var conteudo = new List<T>();
        NoLista<T> atual = topo;
        while (atual != null)
        {
            conteudo.Add(atual.Info);
            atual = atual.Prox;
        }
        return conteudo;
    }
    public void Exibir(DataGridView dgvPilha)
    {
        List<T> dadosEmpilhados = Conteudo();
        dgvPilha.Rows.Clear();
        dgvPilha.RowCount = 1;
        dgvPilha.ColumnCount = Tamanho;
        for (int j = 0; j < Tamanho; j++)
        {
            dgvPilha.Columns[j].HeaderText = j.ToString();
            dgvPilha[j, 0].Value = dadosEmpilhados[j];
        }
        Thread.Sleep(1500);
        Application.DoEvents();
    }

}

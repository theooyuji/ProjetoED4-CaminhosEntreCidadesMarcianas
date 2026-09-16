using System;
using System.Collections.Generic;

interface IStack<T>
{
    void Empilhar(T item);
    T Desempilhar();
    T OTopo();
    int Tamanho { get; }
    bool EstaVazia { get; }
    List<T> Conteudo();
}


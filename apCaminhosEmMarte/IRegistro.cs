using System;
using System.IO;

public interface IRegistro<Tipo> where Tipo : IComparable<Tipo>
{
  bool LerRegistro(StreamReader arquivo);
  void EscreverRegistro(StreamWriter arquivo);
  int CompareTo(Tipo outro);  // <0, ==0, >0
}

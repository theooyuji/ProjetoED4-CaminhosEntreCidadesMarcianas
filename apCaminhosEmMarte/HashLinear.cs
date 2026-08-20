using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HashLinear<Tipo> : ITabelaDeHash<Tipo>
      where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
  public List<string> Conteudo()
  {
    throw new NotImplementedException();
  }

  public int Hash(string chave)
  {
    throw new NotImplementedException();
  }

  bool ITabelaDeHash<Tipo>.Existe(Tipo item, out int onde)
  {
    throw new NotImplementedException();
  }

  void ITabelaDeHash<Tipo>.Inserir(Tipo item)
  {
    throw new NotImplementedException();
  }

  bool ITabelaDeHash<Tipo>.Remover(Tipo item)
  {
    throw new NotImplementedException();
  }
}


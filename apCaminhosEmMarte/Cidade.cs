using System;
using System.Collections.Generic;
using System.IO;

namespace apCaminhosEmMarte
{
  public class Cidade: IRegistro<Cidade>, IComparable<Cidade>
    {
        private int id;
        private double cordX, cordY;
        private string nome;

        public int Id
        {
            get => id;
            private set
            {
                if(id < 0)
                {
                    throw new Exception("Valor inválido para o ID da cidade");
                }
                id = value;
            }   
        }

        public double CordX
        {
            get => cordX;
            set => cordY = value;
        }

        public double CordY
        {
            get => cordY;
            set => cordY = value;
        }

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Valor inválido para o nome da cidade");
                }
                nome = value;
            }
        }


        public Cidade()
        {

        }

        public Cidade(int idCidade,string nomeCidade,double cordX,double cordY)
        {
            this.Id = idCidade;
            this.Nome = nomeCidade;
            this.CordX = cordX;
            this.CordY = cordY;
        }

        public int CompareTo(Cidade outra)
        {
            return this.id.CompareTo(outra.id);
        }

        public bool LerRegistro(StreamReader arquivo)
        {
            string[] campos = arquivo.ReadLine().Split(';');
            if(campos != null && campos.Length == 4)
            {
                this.id = int.Parse(campos[0]);
                this.nome = campos[1];
                this.cordX = double.Parse(campos[2]);
                this.cordY = double.Parse(campos[3]);
                return true;
            }
            return false;
        }

        public void EscreverRegistro(StreamWriter arquivo)
        {
            arquivo.WriteLine($"{id};{nome};{cordX};{cordY}");
        }
    }
}

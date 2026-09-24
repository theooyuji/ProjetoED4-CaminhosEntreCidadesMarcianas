using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosEmMarte
{
  public class Ligacao : IRegistro<Ligacao>, IComparable<Ligacao>
    {
        private int idIni;
        private int idFim;
        private int dist;
        private int tempo;
        private int custo;

        public int IdInicio
        {
            get => idIni;
            private set {
                if(value < 0)
                {
                    throw new Exception("Valor inválido para o idCidade");
                }
                idIni = value;
            }
        }
        public int IdFim
        {
            get => idFim;
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Valor inválido para o idCidade");
                }
                idFim = value;
            }
        }

        public int Distancia
        {
            get => dist;
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Valor inválido para a distância"); ;
                }
                dist = value;
            }
        }

        public int Tempo
        {
            get => tempo;
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Valor inválido para o tempo");
                }
                tempo = value;
            }
        }

        public int Custo
        {
            get => custo;
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Valor inválido para a distância");
                }
                custo = value;
            }
        }

        public Ligacao(int idInicio, int idFim, int dist, int tempo, int custo)
        {
            this.IdInicio = idInicio;
            this.IdFim = idFim;
            this.Distancia = dist;
            this.Tempo = tempo;
            this.Custo = custo;
        }

        public Ligacao()
        {
            this.idIni = 0;
            this.idFim = 0;
            this.custo = 0;
            this.tempo = 0;
            this.dist = 0;
        }

        public int AcessarCriterioSeparacao(CriteriosSeparacao criterio)
        {
            if(criterio == CriteriosSeparacao.Distancia)
            {
                return Distancia;
            }
            else if(criterio == CriteriosSeparacao.Tempo)
            {
                return Tempo;
            }
            else if(criterio == CriteriosSeparacao.Custo)
            {
                return Custo;
            }
            return default(int);
        }

        public int CompareTo(Ligacao other)
        {
            return this.idIni.CompareTo(other.idIni);
        }

        public void EscreverRegistro(StreamWriter arquivo)
        {
            arquivo.WriteLine($"{idIni};{idFim};{Distancia};{Tempo};{Custo}");
        }

        public bool LerRegistro(StreamReader arquivo)
        {
            string[] campos = arquivo.ReadLine().Split(';');
            if(campos != null && campos.Length == 5)
            {
                IdInicio = int.Parse(campos[0]);
                IdFim = int.Parse(campos[1]);
                Distancia = int.Parse(campos[2]);
                Tempo = int.Parse(campos[3]);
                Custo = int.Parse(campos[4]);

                return true;
            }
            return false;
        }
    }
}

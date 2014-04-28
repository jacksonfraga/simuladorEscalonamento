using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEscalonamento.Core
{
    public class Processo
    {        
        public int PID { get; set; }
        public string Nome { get; set; }
        public int Inicio { get; set; }
        public int Duracao { get; set; }
        public int Prioridade { get; set; }

        private int processado;

        public int Processado { get { return processado; } }

        public int TempoExecucao { get; set; }
        public int TempoEspera { get; set; }

        public void Processar()
        {
            processado++;
        }

        public bool Terminado()
        {
            return Duracao.Equals(Processado);
        }

        public void Limpar()
        {
            processado = 0;
            TempoEspera = 0;
            TempoExecucao = 0;
        }
    }
}

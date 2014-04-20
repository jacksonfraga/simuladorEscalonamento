using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEscalonamento.Core
{
    public class AlgoritmoFIFO : Algoritmo
    {
        public override void ProximoTempo()
        {
            int pid = EmpilharFila();

            if (PIDAtual == 0)
            {
                if (FilaEspera.Count > 0)
                {
                    PIDAtual = pid;
                    RetirarFilaEspera(PIDAtual);
                }
            }

            Executar();
        }

    }
}

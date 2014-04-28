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
            // aqui empilha processos na fila quando houver novos no tempo atual, tras o PID do próximo da fila (ordem por entrada na fila)
            int pid = EmpilharFila();

            if (PIDAtual == 0)
            {
                // pega apenas da fila caso haja um na espera e se não houver em execução
                if (FilaEspera.Count > 0)
                {
                    PIDAtual = pid;
                    // retira da fila
                    RetirarFilaEspera(PIDAtual);
                }
            }

            Executar();
        }

    }
}

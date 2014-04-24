﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEscalonamento.Core
{
    public class AlgoritmoPrioridade : Algoritmo
    {
        public override void ProximoTempo()
        {
            int pid = EmpilharFila(true);

            if (PIDAtual == 0)
            {
                if (FilaEspera.Count > 0)
                {
                    PIDAtual = pid;
                    RetirarFilaEspera(PIDAtual);
                }
            }
            else
            {
                if ((FilaEspera.Count > 0) && (Tempo % Quantum == 0))
                {
                    if (GetProcessoAtual().Prioridade > GetProcesso(pid).Prioridade)
                    {
                        int nextPID = pid;
                        RetirarFilaEspera(nextPID);
                        ColocarFilaEspera(PIDAtual);
                        PIDAtual = nextPID;
                    }
                }
            }


            Executar();
        }
    }
}

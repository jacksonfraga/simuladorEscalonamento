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
            // aqui empilha processos na fila quando houver novos no tempo atual, tras o PID do próximo da fila (ordem por maior prioridade)
            int pid = EmpilharFila(OrdemEspera.Prioridade);

            // verifica se esta processando
            if (PIDAtual == 0)
            {
                // se não estiver processando e tiver fila de espera
                if (FilaEspera.Count > 0)
                {
                    // inicia a execução do processo
                    PIDAtual = pid;
                    // remove ele da fila
                    RetirarFilaEspera(PIDAtual);
                }
            }
            else
            {
                
                // se já tiver processando: caso tenha fila de espera e tiver no Quantum
                if ((FilaEspera.Count > 0) && (Tempo % Quantum == 0))
                {
                    int prioridade = GetProcessoAtual().Prioridade;

                    // reduz a prioridade caso tenha outro processo
                    prioridade--;
                    
                    // verifica se o processo da fila possui maior prioridade
                    if (prioridade < GetProcesso(pid).Prioridade)
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

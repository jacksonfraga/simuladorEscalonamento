using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEscalonamento.Core
{
    public class AlgoritmoSJF : Algoritmo
    {
        public override void ProximoTempo()
        {
            // aqui empilha processos na fila quando houver novos no tempo atual, tras o PID do próximo da fila (ordem por duracao)
            int pid = EmpilharFila(OrdemEspera.Duracao);

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
                    Processo processoAtual  = GetProcessoAtual();
                    Processo processoFila = GetProcesso(pid);
                    
                    // calcula os tempos de execucao
                    int duracaoAtual = processoAtual.Duracao - processoAtual.Processado;
                    int duracaoFila = processoFila.Duracao - processoFila.Processado;
                    
                    // se o processo da fila for menor q o atual
                    if (duracaoFila < duracaoAtual)
                    {
                        // efetua a mudança de contexto (troca entre processos execução e um da fila)
                        int nextPID = pid;
                        RetirarFilaEspera(nextPID);
                        // coloca no final da fila novamente
                        ColocarFilaEspera(PIDAtual);
                        PIDAtual = nextPID;
                    }
                }
            }

            // executa o processo atual
            Executar(); 
        }
    }
}

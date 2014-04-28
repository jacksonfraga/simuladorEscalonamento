using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEscalonamento.Core
{
    public enum OrdemEspera
    {
        Normal,
        Prioridade,
        Duracao
    }
    public abstract class Algoritmo
    {
        public Algoritmo()
        {

            processos = new List<Processo>();
            filaEspera = new List<int>();

            Quantum = 1;
            Tempo = 0;

        }

        private List<Processo> processos;
        private List<int> filaEspera;

        public List<Processo> Processos { get { return processos; } }
        public List<int> FilaEspera { get { return filaEspera; } }

        public int PIDAtual { get; set; }
        public int Quantum { get; set; }
        public int Tempo { get; set; }

        public abstract void ProximoTempo();

        protected void Executar()
        {
            Processo processo = GetProcessoAtual();
            if (processo != null)
            {
                processo.Processar();
            }

            Tempo++;
        }

        protected int EmpilharFila(OrdemEspera ordemEspera = OrdemEspera.Normal)
        {
            if (PIDAtual > 0 && GetProcessoAtual().Terminado())
                PIDAtual = 0;


            // busca todos os processos que iniciam "agora"
            List<Processo> processosEmpilhar = Processos.Where(p => p.Inicio.Equals(Tempo)).ToList();            

            foreach (var item in processosEmpilhar)
            {
                // adiciona os processos na fila
                ColocarFilaEspera(item.PID);
            }

            if (ordemEspera == OrdemEspera.Prioridade) // qdo for por prioridade ordena pelo maior prioridade
                filaEspera = filaEspera.OrderByDescending(p => GetProcesso(p).Prioridade).ToList();
            else if (ordemEspera == OrdemEspera.Duracao)// qdo for por Duracao, orderna os menores
                filaEspera = filaEspera.OrderBy(p => GetProcesso(p).Duracao - GetProcesso(p).Processado).ToList();

            // sempre retorna o próximo processo a ser executado
            return FilaEspera.Count > 0 ? FilaEspera.ElementAt(0) : 0;

        }

        protected Processo GetProcessoAtual()
        {
            // retorna o Processo atraves do PID atual
            return Processos.FirstOrDefault(p => p.PID.Equals(PIDAtual));
        }

        public void CriaProcesso(int inicio, int duracao, string nome, int prioridade)
        {            
            if (inicio <= 0)
                inicio = 0;

            if (duracao <= 0)
                duracao = 1;

            Processo processo = new Processo()
            {
                Inicio = inicio,
                Duracao = duracao,
                Nome = nome,
                Prioridade = prioridade,
                PID = Processos.Count > 0 ? Processos.Max(p => p.PID) + 1 : 1
            };

            processos.Add(processo);
        }

        protected void ColocarFilaEspera(int pid)
        {
            if (filaEspera.Contains(pid))
                throw new Exception(String.Format("O processo {0} já estava na fila, houve algum erro!", pid));

            filaEspera.Add(pid);
        }

        protected void RetirarFilaEspera(int pid)
        {
            if (!filaEspera.Contains(pid))
                throw new Exception(String.Format("O processo {0} não estava na fila, houve algum erro!", pid));

            filaEspera.Remove(pid);
        }


        public bool Pendente()
        {
            // verifica se existe processos que ainda não terminaram
            return processos.Exists(p => !p.Terminado());
        }

        public void Reiniciar()
        {
            filaEspera.Clear();

            foreach (var item in processos)
            {
                item.Limpar();
            }

            PIDAtual = 0;
            Tempo = 0;
        }

        public void LimparProcessos()
        {
            Tempo = 0;
            processos.Clear();
        }

        public Processo GetProcesso(int PID)
        {
            return Processos.FirstOrDefault(p => p.PID.Equals(PID));
        }
    }
}

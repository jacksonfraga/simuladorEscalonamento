using SimuladorEscalonamento.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorEscalonamento
{
    public partial class Form1 : Form
    {
        private Algoritmo algoritmo;        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            algoritmo = new AlgoritmoFIFO();

            #region Dados Exemplo
            algoritmo.CriaProcesso(0, 13, "A", 1);
            algoritmo.CriaProcesso(2, 14, "B", 1);
            algoritmo.CriaProcesso(3, 12, "C", 1);
            algoritmo.CriaProcesso(4, 12, "D", 1);
            #endregion

            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;

        }

        private void buttonAddProcesso_Click(object sender, EventArgs e)
        {
            int inico = int.Parse(textBoxInicio.Text);
            int duracao = int.Parse(textBoxDuracao.Text);
            int prioridade = int.Parse(textBoxPrioridade.Text);
            string nome = textBoxNome.Text;

            algoritmo.CriaProcesso(inico, duracao, nome, prioridade);

            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;
        }

        private void buttonSimular_Click(object sender, EventArgs e)
        {
            listBoxRetorno.Items.Clear();
            algoritmo.Reiniciar();
            algoritmo.Quantum = Int32.Parse(textBoxQuantum.Text);



            listBoxRetorno.Items.Add(String.Format("Iniciado {0}", DateTime.Now));

            dataGridViewSimulacao.Columns.Clear();
            dataGridViewSimulacao.Columns.Add("PID", "PID");
            dataGridViewSimulacao.Columns.Add("Processo", "Processo");

            for (int i = 0; i < algoritmo.Processos.Count; i++)
            {

                dataGridViewSimulacao.Rows.Add();
                dataGridViewSimulacao.Rows[i].Cells["PID"].Value = algoritmo.Processos[i].PID;
                dataGridViewSimulacao.Rows[i].Cells["Processo"].Value = algoritmo.Processos[i].Nome;
            }

            do
            {
                

                listBoxRetorno.Items.Add(String.Format("---------- TEMPO {0} ----------", algoritmo.Tempo));

                string columnName = "T" + algoritmo.Tempo.ToString();

                dataGridViewSimulacao.Columns.Add(columnName, columnName);//, "T" + algoritmo.Tempo.ToString());
                dataGridViewSimulacao.Columns[columnName].Width = 25;

                algoritmo.ProximoTempo();


                foreach (DataGridViewRow item in dataGridViewSimulacao.Rows)
                {
                    if (item.Cells["PID"].Value != null)
                    {
                        int pid = Int32.Parse(item.Cells["PID"].Value.ToString());

                        if (algoritmo.FilaEspera.Contains(pid))
                            item.Cells[columnName].Style.BackColor = Color.Yellow;

                        if (algoritmo.PIDAtual.Equals(pid))
                            item.Cells[columnName].Style.BackColor = Color.Blue;
                    }  
                }




                listBoxRetorno.Items.Add(String.Format("Fila: {0}", String.Join(", ", algoritmo.FilaEspera)));
                listBoxRetorno.Items.Add(String.Format("Executando: {0}", String.Join(", ", algoritmo.PIDAtual)));


            } while (algoritmo.Pendente());


            listBoxRetorno.Items.Add("-------------------------------");
            listBoxRetorno.Items.Add("          Finalizado");
            listBoxRetorno.Items.Add("-------------------------------");


        }

        private void buttonStepbyStep_Click(object sender, EventArgs e)
        {
            if (!algoritmo.Pendente())
            {
                listBoxRetorno.Items.Clear();
                algoritmo.Reiniciar();
                algoritmo.Quantum = Int32.Parse(textBoxQuantum.Text);

                listBoxRetorno.Items.Add(String.Format("Iniciado {0}", DateTime.Now));
            }

            listBoxRetorno.Items.Add(String.Format("---------- TEMPO {0} ----------", algoritmo.Tempo));

            algoritmo.ProximoTempo();


            listBoxRetorno.Items.Add(String.Format("Fila: {0}", String.Join(", ", algoritmo.FilaEspera)));
            listBoxRetorno.Items.Add(String.Format("Executando: {0}", String.Join(", ", algoritmo.PIDAtual)));

            if (!algoritmo.Pendente())
            {
                listBoxRetorno.Items.Add("-------------------------------");
                listBoxRetorno.Items.Add("          Finalizado");
                listBoxRetorno.Items.Add("-------------------------------");
            }

            listBoxRetorno.SelectedIndex = listBoxRetorno.Items.Count - 1;
            listBoxRetorno.SelectedIndex = -1;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPrioridade.Visible = comboBox1.SelectedIndex != 0;
            textBoxPrioridade.Visible = comboBox1.SelectedIndex != 0;

            var tempProcessos  = algoritmo.Processos;

            switch (comboBox1.SelectedIndex)
            {
                case 0: // FIFO
                    algoritmo = new AlgoritmoFIFO();
                    break;
                case 1: // Round-Robin
                    algoritmo = new AlgoritmoRoundRobin();
                    break;
                default:
                    break;
            }

            foreach (var item in tempProcessos)
            {
                algoritmo.CriaProcesso(item.Inicio, item.Duracao, item.Nome, item.Prioridade);  
            }
        }

    }
}

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
    public partial class FormSimulador : Form
    {
        private Algoritmo algoritmo;
        private Random random = new Random(1);

        public FormSimulador()
        {
            InitializeComponent();
        }

        private void FormSimulador_Load(object sender, EventArgs e)
        {
            algoritmo = new AlgoritmoFIFO();

            comboBox1.SelectedIndex = 0;

            #region Dados Exemplo 1
            //algoritmo.CriaProcesso(0, 4, "A", 5);
            //algoritmo.CriaProcesso(2, 4, "B", 4);
            //algoritmo.CriaProcesso(2, 4, "C", 3);
            //algoritmo.CriaProcesso(4, 4, "D", 1);
            //algoritmo.CriaProcesso(4, 4, "E", 1);
            //algoritmo.CriaProcesso(6, 4, "F", 1);
            #endregion

            #region Dados Exemplo 2 (livro)
            algoritmo.CriaProcesso(0, 5, "A", 2);
            algoritmo.CriaProcesso(0, 2, "B", 3);
            algoritmo.CriaProcesso(1, 4, "C", 1);
            algoritmo.CriaProcesso(3, 3, "D", 4);
            #endregion

            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;

            dataGridViewProcessos.Columns["PID"].Width = 35;
            dataGridViewProcessos.Columns["Nome"].Width = 60;
            dataGridViewProcessos.Columns["Inicio"].Width = 70;
            dataGridViewProcessos.Columns["Duracao"].Width = 70;
            dataGridViewProcessos.Columns["Prioridade"].Width = 70;

        }

        private void buttonAddProcesso_Click(object sender, EventArgs e)
        {
            int inicio = int.Parse(textBoxInicio.Text);
            int duracao = int.Parse(textBoxDuracao.Text);
            int prioridade = int.Parse(textBoxPrioridade.Text);
            string nome = textBoxNome.Text;

            algoritmo.CriaProcesso(inicio, duracao, nome, prioridade);

            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;

            if (nome.Length == 1)
            {
                int chr = Char.ConvertToUtf32(nome, 0);

                textBoxNome.Text = Char.ConvertFromUtf32(++chr);

                textBoxDuracao.Text = random.Next(10).ToString();

                inicio += random.Next(3);
                textBoxInicio.Text = inicio.ToString();
            }

        }

        private void Preparar()
        {
            listBoxRetorno.Items.Clear();
            algoritmo.Reiniciar();
            algoritmo.Quantum = Int32.Parse(textBoxQuantum.Text);



            listBoxRetorno.Items.Add(String.Format("Iniciado {0}", DateTime.Now));

            dataGridViewSimulacao.Columns.Clear();
            dataGridViewSimulacao.Columns.Add("PID", "PID");
            dataGridViewSimulacao.Columns["PID"].Width = 30;
            dataGridViewSimulacao.Columns.Add("Processo", "Processo");
            dataGridViewSimulacao.Columns["Processo"].Width = 60;

            var temp = algoritmo.Processos.ToList();

            temp.Reverse();

            for (int i = 0; i < temp.Count; i++)
            {

                dataGridViewSimulacao.Rows.Add();
                dataGridViewSimulacao.Rows[i].Cells["PID"].Value = temp[i].PID;
                dataGridViewSimulacao.Rows[i].Cells["Processo"].Value = temp[i].Nome;
            }
        }

        private void buttonSimular_Click(object sender, EventArgs e)
        {

            Preparar();

            do
            {
                ExecutarPasso();
            } while (algoritmo.Pendente());


            listBoxRetorno.Items.Add("-------------------------------");
            listBoxRetorno.Items.Add("          Finalizado");
            listBoxRetorno.Items.Add("-------------------------------");
            listBoxRetorno.Items.Add(String.Format("Tempo médio de execução: {0}", algoritmo.TempoMedioExecucao()));
            listBoxRetorno.Items.Add(String.Format("Tempo médio de espera: {0}", algoritmo.TempoMedioEspera()));
            MessageBox.Show("Finalizado", "Simulador", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listBoxRetorno.SelectedIndex = listBoxRetorno.Items.Count - 1;
            listBoxRetorno.SelectedIndex = -1;

        }

        private void ExecutarPasso()
        {
            listBoxRetorno.Items.Add(String.Format("---------- TEMPO {0} ----------", algoritmo.Tempo));

            string columnName = "T" + algoritmo.Tempo.ToString();

            dataGridViewSimulacao.Columns.Add(columnName, columnName);//, "T" + algoritmo.Tempo.ToString());
            dataGridViewSimulacao.Columns[columnName].Width = 30;

            algoritmo.ProximoTempo();


            foreach (DataGridViewRow item in dataGridViewSimulacao.Rows)
            {
                if (item.Cells["PID"].Value != null)
                {
                    int pid = Int32.Parse(item.Cells["PID"].Value.ToString());

                    if (algoritmo.FilaEspera.Contains(pid))
                    {
                        item.Cells[columnName].Style.BackColor = Color.Yellow;
                        item.Cells[columnName].Value = algoritmo.GetProcesso(pid).Prioridade;
                    }

                    if (algoritmo.PIDAtual.Equals(pid))
                    {
                        item.Cells[columnName].Style.BackColor = Color.Blue;
                        item.Cells[columnName].Value = algoritmo.GetProcesso(pid).Prioridade;
                    }

                }
            }

            var bindListProcesso = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindListProcesso;

            listBoxRetorno.Items.Add(String.Format("Fila: {0}", String.Join(", ", algoritmo.FilaEspera)));
            listBoxRetorno.Items.Add(String.Format("Executando: {0}", String.Join(", ", algoritmo.PIDAtual)));

        }

        private void buttonStepbyStep_Click(object sender, EventArgs e)
        {
            if (!algoritmo.Pendente() || algoritmo.Tempo == 0)
            {
                Preparar();
            }

            ExecutarPasso();

            if (!algoritmo.Pendente())
            {
                listBoxRetorno.Items.Add("-------------------------------");
                listBoxRetorno.Items.Add("          Finalizado");
                listBoxRetorno.Items.Add("-------------------------------");
                listBoxRetorno.Items.Add(String.Format("Tempo médio de execução: {0}", algoritmo.TempoMedioExecucao()));
                listBoxRetorno.Items.Add(String.Format("Tempo médio de espera: {0}", algoritmo.TempoMedioEspera()));
                MessageBox.Show("Finalizado", "Simulador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            listBoxRetorno.SelectedIndex = listBoxRetorno.Items.Count - 1;
            listBoxRetorno.SelectedIndex = -1;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPrioridade.Visible = comboBox1.SelectedIndex == 1;
            textBoxPrioridade.Visible = comboBox1.SelectedIndex == 1;

            var tempProcessos = algoritmo.Processos;

            switch (comboBox1.SelectedIndex)
            {
                case 0: // FIFO
                    algoritmo = new AlgoritmoFIFO();
                    break;
                case 1: // Prioridade
                    algoritmo = new AlgoritmoPrioridade();
                    break;
                case 2: // Round-Robin
                    algoritmo = new AlgoritmoRoundRobin();
                    break;
                case 3: // SJF
                    algoritmo = new AlgoritmoSJF();
                    break;

                default:
                    break;
            }

            foreach (var item in tempProcessos)
            {
                algoritmo.CriaProcesso(item.Inicio, item.Duracao, item.Nome, item.Prioridade);
            }

            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            algoritmo.LimparProcessos();
            var bindList = new BindingList<Processo>(algoritmo.Processos);
            dataGridViewProcessos.DataSource = bindList;
            textBoxNome.Text = "A";
            textBoxInicio.Text = "0";
            textBoxDuracao.Text = random.Next(10).ToString();
            dataGridViewSimulacao.Rows.Clear();
            dataGridViewSimulacao.Columns.Clear();
        }
    }
}

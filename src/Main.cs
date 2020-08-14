using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassaDeDados
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.LoadFile("../Dados/nomes.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox2.Text))
            {
                richTextBox2.LoadFile("../Dados/sobrenomes1.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox3.Text))
            {
                richTextBox3.LoadFile("../Dados/sobrenomes2.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            RichTextBox pai = new RichTextBox();
            RichTextBox paiTemp = new RichTextBox();
            paiTemp.LoadFile("../Dados/nomes_mas.txt", RichTextBoxStreamType.PlainText);
            string nomes_paisemicompletos = paiTemp.Text;
            string[] nomes_masculinos = nomes_paisemicompletos.Split('\n');
            List<string> lista_pai = new List<string>();

            RichTextBox mae = new RichTextBox();
            RichTextBox maeTemp = new RichTextBox();
            maeTemp.LoadFile("../Dados/nomes_femi.txt", RichTextBoxStreamType.PlainText);
            string nomes_maesemicompletas = maeTemp.Text;
            string[] nomes_mae = nomes_maesemicompletas.Split('\n');
            List<string> lista_mae = new List<string>();


            string[] nome_completo = new string[] { };

            string nomes = richTextBox1.Text;
            string[] nomes_separados = nomes.Split('\n');
            List<string> nomes_final = new List<string>();

            string sobrenomes = richTextBox2.Text;
            string[] sobrenomes_separados = sobrenomes.Split('\n');
            List<string> sobrenomes_final = new List<string>();

            string sobrenomes2 = richTextBox3.Text;
            string[] sobrenomes2_separados = sobrenomes2.Split('\n');
            List<string> sobrenomes2_final = new List<string>();


            if (String.IsNullOrEmpty(textBox1.Text))
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 10)
                    {
                        int start4 = rnd.Next(0, nomes_separados.Length);
                        int startPai = rnd.Next(0, nomes_masculinos.Length);
                        int startMae = rnd.Next(0, nomes_mae.Length);
                        richTextBox4.AppendText(nomes_separados[start4] + " ");
                        pai.AppendText(nomes_masculinos[startPai] + " ");
                        mae.AppendText(nomes_mae[startMae] + " ");

                        int start5 = rnd.Next(0, sobrenomes_separados.Length);
                        int start7 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes_separados[start5] + " ");
                        pai.AppendText(sobrenomes_separados[start7] + " ");
                        mae.AppendText(sobrenomes_separados[start5] + " ");

                        int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                        int start8 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes2_separados[start6]);
                        pai.AppendText(sobrenomes2_separados[start6]);
                        mae.AppendText(sobrenomes2_separados[start8]);
                    }
                    else
                    {
                        int start4 = rnd.Next(0, nomes_separados.Length);
                        int startPai = rnd.Next(0, nomes_masculinos.Length);
                        int startMae = rnd.Next(0, nomes_mae.Length);
                        richTextBox4.AppendText(nomes_separados[start4] + " ");
                        pai.AppendText(nomes_masculinos[startPai] + " ");
                        mae.AppendText(nomes_mae[startMae] + " ");

                        int start5 = rnd.Next(0, sobrenomes_separados.Length);
                        int start7 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes_separados[start5] + " ");
                        pai.AppendText(sobrenomes_separados[start7] + " ");
                        mae.AppendText(sobrenomes_separados[start5] + " ");

                        int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                        int start8 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes2_separados[start6]);
                        richTextBox4.AppendText("\n");
                        pai.AppendText(sobrenomes2_separados[start6]);
                        pai.AppendText("\n");
                        mae.AppendText(sobrenomes2_separados[start8]);
                        mae.AppendText("\n");
                    }
                }

            }

            else
            {
                int quantidade = int.Parse(textBox1.Text);
                for (int i = 0; i < quantidade; i++)
                {
                    if (i == quantidade)
                    {
                        int start4 = rnd.Next(0, nomes_separados.Length);
                        int startPai = rnd.Next(0, nomes_masculinos.Length);
                        int startMae = rnd.Next(0, nomes_mae.Length);
                        richTextBox4.AppendText(nomes_separados[start4] + " ");
                        pai.AppendText(nomes_masculinos[startPai] + " ");
                        mae.AppendText(nomes_mae[startMae] + " ");

                        int start5 = rnd.Next(0, sobrenomes_separados.Length);
                        int start7 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes_separados[start5] + " ");
                        pai.AppendText(sobrenomes_separados[start7] + " ");
                        mae.AppendText(sobrenomes_separados[start5] + " ");

                        int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                        int start8 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes2_separados[start6]);
                        pai.AppendText(sobrenomes2_separados[start6]);
                        mae.AppendText(sobrenomes2_separados[start8]);
                    }
                    else
                    {
                        int start4 = rnd.Next(0, nomes_separados.Length);
                        int startPai = rnd.Next(0, nomes_masculinos.Length);
                        int startMae = rnd.Next(0, nomes_mae.Length);
                        richTextBox4.AppendText(nomes_separados[start4] + " ");
                        pai.AppendText(nomes_masculinos[startPai] + " ");
                        mae.AppendText(nomes_mae[startMae] + " ");

                        int start5 = rnd.Next(0, sobrenomes_separados.Length);
                        int start7 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes_separados[start5] + " ");
                        pai.AppendText(sobrenomes_separados[start7] + " ");
                        mae.AppendText(sobrenomes_separados[start5] + " ");

                        int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                        int start8 = rnd.Next(0, sobrenomes_separados.Length);
                        richTextBox4.AppendText(sobrenomes2_separados[start6]);
                        richTextBox4.AppendText("\n");
                        pai.AppendText(sobrenomes2_separados[start6]);
                        pai.AppendText("\n");
                        mae.AppendText(sobrenomes2_separados[start8]);
                        mae.AppendText("\n");
                    }
                }
            }

            richTextBox4.SaveFile("../Dados/nomesCompletos.txt", RichTextBoxStreamType.PlainText);
            pai.SaveFile("../Dados/nomesDoPai.txt", RichTextBoxStreamType.PlainText);
            mae.SaveFile("../Dados/nomesDaMae.txt", RichTextBoxStreamType.PlainText);
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox4.Text = "";
        }

        private void nomeCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            Form1 form1 = new Form1();
            main.ShowDialog();
            form1.Close();
            form1.Hide();

        }

        private void geradorCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            main.Close();
            main.Hide();
        }
    }
}

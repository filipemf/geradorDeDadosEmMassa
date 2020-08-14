using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data.SqlClient;

namespace MassaDeDados
{
    public partial class Form1 : Form
    {
        Database database = new Database();
        private static string conexao = "Data Source=database.db";
        private static string nomebanco = "database.db";

        public class Informa
        {
            public int id { get; set; }
            public string nomes_dos_filhos { get; set; }
            public string nomes_dos_pais { get; set; }
            public string nomes_das_maes { get; set; }
            public string endereço { get; set; }
            public string fone { get; set; }
            public string rg { get; set; }
            public string salario { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!File.Exists(nomebanco))
            {
                SQLiteConnection.CreateFile(nomebanco);
                SQLiteConnection conn = new SQLiteConnection(conexao);
                conn.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine(" CREATE TABLE dados (id   INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, nomes_dos_filhos  TEXT NOT NULL, nomes_dos_filhos  TEXT NOT NULL, nomes_dos_pais TEXT NOT NULL, nomes_das_maes TEXT NOT NULL, endereço  TEXT NOT NULL, fone TEXT NOT NULL, salario TEXT NOT NULL");

                SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Executado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Banco de dados ja existente");
            }

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
            RichTextBox riquinho = new RichTextBox();
            richTextBox1.LoadFile("../Dados/nomes_masc.txt", RichTextBoxStreamType.PlainText);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox3.Text))
            {
                richTextBox3.LoadFile("../Dados/sobrenomes2.txt", RichTextBoxStreamType.PlainText);
            }
        }

       


        public void GerarPaisEFilhos()
        {
            Random rnd = new Random();

            RichTextBox pai = new RichTextBox();
            RichTextBox paiTemp = new RichTextBox();
            paiTemp.LoadFile("../Dados/nomes_mas.txt", RichTextBoxStreamType.PlainText);
            string nomes_paisemicompletos = paiTemp.Text;
            string[] nomes_masculinos = nomes_paisemicompletos.Split('\n');
            List<string> lista_pai = new List<string>();
            List<string> temp_pai = new List<string>();

            RichTextBox mae = new RichTextBox();
            RichTextBox maeTemp = new RichTextBox();
            maeTemp.LoadFile("../Dados/nomes_femi.txt", RichTextBoxStreamType.PlainText);
            string nomes_maesemicompletas = maeTemp.Text;
            string[] nomes_mae = nomes_maesemicompletas.Split('\n');
            List<string> lista_mae = new List<string>();
            List<string> temp_mae = new List<string>();

            RichTextBox filho = new RichTextBox();
            RichTextBox filhoTemp = new RichTextBox();
            filhoTemp.LoadFile("../Dados/nomes_filho.txt", RichTextBoxStreamType.PlainText);
            string filho_temp = filhoTemp.Text;
            string[] nomes_filho = filho_temp.Split('\n');
            List<string> lista_filho = new List<string>();
            List<string> temp_filho = new List<string>();

            RichTextBox sobrenomesR = new RichTextBox();
            sobrenomesR.LoadFile("../Dados/sobrenomes1.txt", RichTextBoxStreamType.PlainText);
            string sobrenomes = sobrenomesR.Text;
            string[] sobrenomes_separados = sobrenomes.Split('\n');
            List<string> sobrenomes_final = new List<string>();

            RichTextBox sobrenomes2R = new RichTextBox();
            sobrenomes2R.LoadFile("../Dados/sobrenomes2.txt", RichTextBoxStreamType.PlainText);
            string sobrenomes2 = sobrenomes2R.Text;
            string[] sobrenomes2_separados = sobrenomes2.Split('\n');
            List<string> sobrenomes2_final = new List<string>();


            int quantidade = int.Parse(textBox1.Text);
            for (int i = 0; i < quantidade; i++)
            {

                int start4 = rnd.Next(0, nomes_filho.Length);
                int startPai = rnd.Next(0, nomes_masculinos.Length);
                int startMae = rnd.Next(0, nomes_mae.Length);

                int start5 = rnd.Next(0, sobrenomes_separados.Length);
                int start7 = rnd.Next(0, sobrenomes_separados.Length);

                int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                int start8 = rnd.Next(0, sobrenomes2_separados.Length);

                lista_filho.Add(nomes_filho[start4] + " " + sobrenomes_separados[start5] + " " + sobrenomes2_separados[start6]);
                lista_pai.Add(nomes_masculinos[startPai] + " " + sobrenomes_separados[start7] + " " + sobrenomes2_separados[start6]);
                lista_mae.Add(nomes_mae[startMae] + " " + sobrenomes_separados[start5] + " " + sobrenomes2_separados[start8]);

            }

            int tamanho1 = lista_filho.Count;

            int tamanho2 = lista_pai.Count;

            int tamanho3 = lista_mae.Count;

            for (int j = 0; j < tamanho1; j++)
            {
                richTextBox1.AppendText(lista_filho[j] + '\n');

            }
            for (int j = 0; j < tamanho2; j++)
            {
                richTextBox2.AppendText(lista_pai[j] + '\n');

            }
            for (int j = 0; j < tamanho3; j++)
            {
                richTextBox3.AppendText(lista_mae[j] + '\n');

            }
            lista_filho.Clear();
            lista_pai.Clear();
            lista_mae.Clear();
        }

        public void CarregarAdicionais()
        {
            //Variaveis essenciais
            Random rnd = new Random();
            int quantidade = int.Parse(textBox1.Text);

            //Gerar numeros de celular
            List<string> lista_celulares = new List<string>();

            for (int p = 0; p < quantidade; p++)
            {
                lista_celulares.Add("9");
                for (int j = 0; j < 8; j++)
                {
                    int numero_da_vez = rnd.Next(0, 9);
                    lista_celulares.Add(numero_da_vez.ToString());

                }
                int tamanho4 = lista_celulares.Count;
                for (int l = 0; l < tamanho4; l++)
                {
                    richTextBox7.AppendText(lista_celulares[l]);
                }
                lista_celulares.Clear();
                richTextBox7.AppendText("\n");
            }


            //Gerar numeros de RG
            List<string> lista_rg = new List<string>();

            for (int p = 0; p < quantidade; p++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int numero_da_vez = rnd.Next(0, 9);
                    lista_rg.Add(numero_da_vez.ToString());
                }

                if (p <= quantidade - 1)
                {
                    lista_rg.Add("-");
                    lista_rg.Add(rnd.Next(0, 9).ToString());
                }

                int tamanho2 = lista_rg.Count;
                for (int l = 0; l < tamanho2; l++)
                {
                    richTextBox6.AppendText(lista_rg[l]);
                }
                lista_rg.Clear();
                richTextBox6.AppendText("\n");
            }

            //Gerar salarios
            List<string> lista_salarios = new List<string>();

            for (int p = 0; p < quantidade; p++)
            {
                lista_salarios.Add("R$");
                for (int j = 0; j < 1; j++)
                {
                    int valores = rnd.Next(1000, 15000);
                    lista_salarios.Add(valores.ToString());

                }
                int tamanho3 = lista_salarios.Count;
                for (int l = 0; l < tamanho3; l++)
                {
                    richTextBox5.AppendText(lista_salarios[l]);
                }
                lista_salarios.Clear();
                richTextBox5.AppendText("\n");
            }
            List<string> lista = new List<string>();


            //Gerar endereço
            List<string> lista_nomeclaturas = new List<string>();
            lista_nomeclaturas.Add("Av ");
            lista_nomeclaturas.Add("Rua ");
            lista_nomeclaturas.Add("Vila ");

            for (int i = 0; i < quantidade; i++)
            {
                List<string> lista_ender = new List<string>();
                string texto = richTextBox1.Text;
                string[] nomes_ender = texto.Split('\n');

                int nomeclatura_da_vez = rnd.Next(0, 2);
                int nome_da_vez = rnd.Next(0, nomes_ender.Length);

                lista_ender.Add(lista_nomeclaturas[nomeclatura_da_vez]);
                lista_ender.Add(nomes_ender[nome_da_vez] + "\n");

                int tamanho = lista_ender.Count;
                for (int j = 0; j < tamanho; j++)
                {
                    richTextBox8.AppendText(lista_ender[j]);
        
                }
                lista_ender.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GerarPaisEFilhos();
            CarregarAdicionais();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Por precausão, só é permitido reescrever as informações se algum dado estiver presente.");
            }
            else
            {
                richTextBox1.SaveFile("../Dados/nomes.txt", RichTextBoxStreamType.PlainText);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox2.Text))
            {
                MessageBox.Show("Por precausão, só é permitido reescrever as informações se algum dado estiver presente.");
            }
            else
            {
                richTextBox2.SaveFile("../Dados/sobrenomes1.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox3.Text))
            {
                MessageBox.Show("Por precausão, só é permitido reescrever as informações se algum dado estiver presente.");
            }
            else
            {
                richTextBox3.SaveFile("../Dados/sobrenomes2.txt", RichTextBoxStreamType.PlainText);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            filho.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {

            string nomes_completos = richTextBox7.Text;
            string[] nomes_finais = nomes_completos.Split('\n');
            int quantidade = nomes_finais.Length;

            /* Arrays */
            string nomes_filhos = richTextBox1.Text;
            string[] nomes_dos_filhos = nomes_filhos.Split('\n');

            string nomes_pais = richTextBox2.Text;
            string[] nomes_dos_pais = nomes_pais.Split('\n');

            string nomes_maes = richTextBox3.Text;
            string[] nomes_das_maes = nomes_maes.Split('\n');

            string ender = richTextBox8.Text;
            string[] endereço = ender.Split('\n');

            string fone_inc = richTextBox7.Text;
            string[] fone = fone_inc.Split('\n');

            string rg_inc = richTextBox6.Text;
            string[] rg = rg_inc.Split('\n');

            string sal_inc = richTextBox5.Text;
            string[] salario = sal_inc.Split('\n');

            Database data = new Database();
            Informa informações = new Informa();

            SQLiteConnection conn = new SQLiteConnection(conexao);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            for (int i = 0; i < quantidade; i++)
            {
                if (i == quantidade - 1)
                    break;
                informações.nomes_dos_filhos = nomes_dos_filhos[i];
                informações.nomes_dos_pais = nomes_dos_pais[i];
                informações.nomes_das_maes = nomes_das_maes[i];
                informações.endereço = endereço[i];
                informações.fone = fone[i];
                informações.rg = rg[i];
                informações.salario = salario[i];

                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO dados (nomes_dos_filhos, nomes_dos_pais, nomes_das_maes, endereço, fone, rg, salario) VALUES (@filho, @pai, @mae, @endereço, @fone, @rg, @salario)", conn);
                cmd.Parameters.AddWithValue("@filho", informações.nomes_dos_filhos);
                cmd.Parameters.AddWithValue("@pai", informações.nomes_dos_pais);
                cmd.Parameters.AddWithValue("@mae", informações.nomes_das_maes);
                cmd.Parameters.AddWithValue("@endereço", informações.endereço);
                cmd.Parameters.AddWithValue("@fone", informações.fone);
                cmd.Parameters.AddWithValue("@rg", informações.rg);
                cmd.Parameters.AddWithValue("@salario", informações.salario);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex);
                }
            }


            if (conn.State == ConnectionState.Closed)
                conn.Open();

            /*
            SQLiteDataAdapter sqlDa = new SQLiteDataAdapter("SELECT * FROM dados", conn);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            // dataGridView1.DataSource = sqlDa;

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM dados", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Student");
            dataGridView1.DataSource = ds.Tables["nome"];

            if (conn.State == ConnectionState.Open)
                conn.Close();*/
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /*
            SQLiteConnection conn = new SQLiteConnection(conexao);
            SQLiteConnection com = new SQLiteConnection(conexao);
            SQLiteDataAdapter sqlDa = new SQLiteDataAdapter("SELECT * FROM tb_dados", conn);
            DataTable dataTable = new DataTable();
            BindingSource binding = new BindingSource();*/
            SQLiteConnection conn = new SQLiteConnection(conexao);

            conn.Open();
            SQLiteCommand comm = new SQLiteCommand("Select * From dados", conn);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
            dataGridView1.Rows.Add(new object[] {
            //read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("id")),  // Or column name like this
            read.GetValue(read.GetOrdinal("nomes_dos_filhos")),
            read.GetValue(read.GetOrdinal("nomes_dos_pais")),
            read.GetValue(read.GetOrdinal("nomes_das_maes")),
            read.GetValue(read.GetOrdinal("endereço")),
            read.GetValue(read.GetOrdinal("fone")),
            read.GetValue(read.GetOrdinal("rg")),
            read.GetValue(read.GetOrdinal("salario"))
            });
                }
            }
            /*
            try
            {
                conn.Open();

                sqlDa.Fill(dataTable);
                dataGridView1.DataSource = sqlDa;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel carregar: "+ex);
            }
            dataGridView1.DataSource = GetData();
            

            if (conn.State == ConnectionState.Closed)
                conn.Open();


            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM tb_dados", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Student");
            dataGridView1.DataSource = ds.Tables["nome"];

            if (conn.State == ConnectionState.Open)
                conn.Close();

            if (textBox2.Text == "ola")
            {
                try
                {
                    SqlConnection conne = new SqlConnection(conexao);
                    if (conne.State == ConnectionState.Closed)
                        conne.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tb_dados", conne);
                }
                catch (Exception er)
                {
                    MessageBox.Show("droga"+er);
                }
            }*/
        }
        private DataTable GetData()
        {
            DataTable dtEmployees = new DataTable();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_dados", connection))
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtEmployees.Load(reader);
                }
            }
            return dtEmployees;
        }

        private void nomesCompletosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            //this.Close();

        }

        private void geradorCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            richTextBox8.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox7.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox6.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();

            RichTextBox pai = new RichTextBox();
            RichTextBox paiTemp = new RichTextBox();
            paiTemp.LoadFile("../Dados/nomes_mas.txt", RichTextBoxStreamType.PlainText);
            string nomes_paisemicompletos = paiTemp.Text;
            string[] nomes_masculinos = nomes_paisemicompletos.Split('\n');
            List<string> lista_pai = new List<string>();
            List<string> temp_pai = new List<string>();

            RichTextBox mae = new RichTextBox();
            RichTextBox maeTemp = new RichTextBox();
            maeTemp.LoadFile("../Dados/nomes_femi.txt", RichTextBoxStreamType.PlainText);
            string nomes_maesemicompletas = maeTemp.Text;
            string[] nomes_mae = nomes_maesemicompletas.Split('\n');
            List<string> lista_mae = new List<string>();
            List<string> temp_mae = new List<string>();

            RichTextBox filho = new RichTextBox();
            RichTextBox filhoTemp = new RichTextBox();
            filhoTemp.LoadFile("../Dados/nomes_filho.txt", RichTextBoxStreamType.PlainText);
            string filho_temp = filhoTemp.Text;
            string[] nomes_filho = filho_temp.Split('\n');
            List<string> lista_filho = new List<string>();
            List<string> temp_filho = new List<string>();

            RichTextBox sobrenomesR = new RichTextBox();
            sobrenomesR.LoadFile("../Dados/sobrenomes1.txt", RichTextBoxStreamType.PlainText);
            string sobrenomes = sobrenomesR.Text;
            string[] sobrenomes_separados = sobrenomes.Split('\n');
            List<string> sobrenomes_final = new List<string>();

            RichTextBox sobrenomes2R = new RichTextBox();
            sobrenomes2R.LoadFile("../Dados/sobrenomes2.txt", RichTextBoxStreamType.PlainText);
            string sobrenomes2 = sobrenomes2R.Text;
            string[] sobrenomes2_separados = sobrenomes2.Split('\n');
            List<string> sobrenomes2_final = new List<string>();


                int quantidade = int.Parse(textBox1.Text);
                for (int i = 0; i < quantidade; i++)
                {
                    
                        int start4 = rnd.Next(0, nomes_filho.Length);
                        int startPai = rnd.Next(0, nomes_masculinos.Length);
                        int startMae = rnd.Next(0, nomes_mae.Length);

                        int start5 = rnd.Next(0, sobrenomes_separados.Length);
                        int start7 = rnd.Next(0, sobrenomes_separados.Length);

                        int start6 = rnd.Next(0, sobrenomes2_separados.Length);
                        int start8 = rnd.Next(0, sobrenomes2_separados.Length);

                        lista_filho.Add(nomes_filho[start4] + " " + sobrenomes_separados[start5] + " " + sobrenomes2_separados[start6]);
                        lista_pai.Add(nomes_masculinos[startPai] + " " + sobrenomes_separados[start7] + " " + sobrenomes2_separados[start6]);
                        lista_mae.Add(nomes_mae[startMae] + " " + sobrenomes_separados[start5] + " " + sobrenomes2_separados[start8]);

                    }

                    int tamanho1 = lista_filho.Count;

                    int tamanho2 = lista_pai.Count;

                    int tamanho3 = lista_mae.Count;

                    for (int j = 0; j < tamanho1; j++)
                    {
                        richTextBox1.AppendText(lista_filho[j] + '\n');

            }
                    for (int j = 0; j < tamanho2; j++)
                    {
                        richTextBox2.AppendText(lista_pai[j] + '\n');

            }
                    for (int j = 0; j < tamanho3; j++)
                    {
                        richTextBox3.AppendText(lista_mae[j]+'\n');

                    }
                    lista_filho.Clear();
                    lista_pai.Clear();
                    lista_mae.Clear();
                }
            }

}

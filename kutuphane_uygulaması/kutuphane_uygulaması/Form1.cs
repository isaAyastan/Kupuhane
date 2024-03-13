using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kutuphane_uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbCommand komut;
        OleDbConnection baglanti;
        OleDbDataAdapter da;
      
        void listele()
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source =  kutuphane.mdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select * From kitaplar",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO kitaplar (adi,yazar,tur,raf,sayfa_sayisi) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();

            
        }     
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                string sorgu = " DELETE FROM kitaplar WHERE kimlik = " + textBox6.Text + "";
                komut = new OleDbCommand(sorgu, baglanti);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                listele();
            
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE kitaplar SET adi = '"  +textBox1.Text  +"', yazar='"+textBox2.Text+"', tur='"+textBox3.Text+"',raf='"+textBox4.Text+"',sayfa_sayisi='"+textBox5.Text+"' WHERE Kimlik = " + textBox6.Text;
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }
    }
}

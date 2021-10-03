using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            displayData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static SqlConnection koneksi()
        {
            string connection_string = @"Data Source=DFITRA\SQLEXPRESS;Initial Catalog=db_barang;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection_string);
            return conn;
        }

        public void displayData()
        {
            SqlConnection conn = koneksi();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT barang_id AS ID, barang_nama AS Nama, barang_stok AS Stok, barang_jenis AS Jenis, barang_harga AS Harga, barang_warna AS Warna, barang_size AS Size FROM barang";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO barang VALUES("+Convert.ToInt32(textBox1.Text)+",'"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            displayData();
            MessageBox.Show("Simpan Data Berhasil");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE barang SET barang_nama = '"+textBox2.Text+ "', barang_stok='" + textBox3.Text + "', barang_jenis = '"+textBox4.Text+ "', barang_harga='" + textBox5.Text + "', barang_warna='" + textBox6.Text + "', barang_size='" + comboBox1.Text + "' WHERE barang_id = " + Convert.ToInt32(textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            displayData();
            MessageBox.Show("Update data berhasil!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM barang WHERE barang_id=" + Convert.ToInt32(textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            displayData();
            MessageBox.Show("Hapus data berhasil");
        }
    }
    


}


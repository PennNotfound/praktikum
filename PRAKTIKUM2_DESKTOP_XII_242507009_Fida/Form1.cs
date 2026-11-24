using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PRAKTIKUM2_DESKTOP_XII_242507009_Fida
{
    public partial class Form1 : Form
    {
        string connectionString = "server=localhost;user=root;database=db_apotek_gudang;password=";
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxsatuan.Text = row.Cells["id_suplemen"].Value.ToString();
                textBoxkode.Text = row.Cells["kode_barang"].Value.ToString();
                textBoxnama.Text = row.Cells["nama_barang"].Value.ToString();
                textBoxkategori.Text = row.Cells["kategori"].Value.ToString();
                textBoxstok.Text = row.Cells["stok"].Value.ToString();
                textBoxsatuan.Text = row.Cells["satuan"].Value.ToString();
                textBoxharga.Text = row.Cells["harga_satuan"].Value.ToString();
                textBoxbatasMin.Text = row.Cells["batas_minimum"].Value.ToString();
            }
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tb_suplemen", con);
                string query = "SELECT * FROM tb_suplemen";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("gagal memuat data: " + ex.Message);
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tb_suplemen", con);
                string query = "SELECT * FROM tb_suplemen";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("gagal memuat data: " + ex.Message);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kode = textBoxkode.Text.Trim();
            string nama = textBoxnama.Text.Trim();
            string kategori = textBoxkategori.Text.Trim();
            string stokText = textBoxstok.Text.Trim();
            string satuan = textBoxsatuan.Text.Trim();
            string hargaText = textBoxharga.Text.Trim();
            string batasMinText = textBoxbatasMin.Text.Trim();

            if (string.IsNullOrWhiteSpace(kode) ||
                string.IsNullOrWhiteSpace(nama) ||
                string.IsNullOrWhiteSpace(stokText) ||
                string.IsNullOrWhiteSpace(hargaText))
            {
                MessageBox.Show(
                    "Semua field wajib diisi !",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO tb_suplemen (kode_barang, nama_barang, kategori, stok, satuan, harga_satuan, batas_minimum) VALUES (@kode_barang, @nama_barang, @kategori_barang, @stok, @satuan, @harga_satuan, @batas_minimum)";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@kode_barang", textBoxkode.Text.ToString());
                command.Parameters.AddWithValue("@nama_barang", textBoxnama.Text.ToString());
                command.Parameters.AddWithValue("@kategori_barang", textBoxkategori.Text.ToString());
                command.Parameters.AddWithValue("@stok", textBoxstok.Text.ToString());
                command.Parameters.AddWithValue("@satuan", textBoxsatuan.Text.ToString());
                command.Parameters.AddWithValue("@harga_satuan", textBoxharga.Text.ToString());
                command.Parameters.AddWithValue("@batas_minimum", textBoxbatasMin.Text.ToString());
                command.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "UPDATE tb_suplemen SET kode_barang=@kode_barang, nama_barang=@nama_barang, kategori=@kategori, stok=@stok, satuan=@satuan, harga_satuan=@harga_satuan, batas_minimum=@batas_minimum WHERE id_suplemen=@id";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@id", textBoxsatuan.Text.ToString());
                command.Parameters.AddWithValue("@kode_barang", textBoxkode.Text.ToString());
                command.Parameters.AddWithValue("@nama_barang", textBoxnama.Text.ToString());
                command.Parameters.AddWithValue("@kategori_barang", textBoxkategori.Text.ToString());
                command.Parameters.AddWithValue("@stok", textBoxstok.Text.ToString());
                command.Parameters.AddWithValue("@satuan", textBoxsatuan.Text.ToString());
                command.Parameters.AddWithValue("@harga_satuan", textBoxharga.Text.ToString());
                command.Parameters.AddWithValue("@batas_minimum", textBoxbatasMin.Text.ToString());
                command.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "DELETE FROM tb_suplemen WHERE id_suplemen=@id and kode_barang=@kode_barang or nama_barang=@nama_barang or kategori=@kategori or stok=@stok or satuan=@satuan or harga_satuan=@harga or batas_minimum=@batas_minimum";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@id", textBoxsatuan.Text);
                command.Parameters.AddWithValue("@kode_barang", textBoxkode.Text);
                command.Parameters.AddWithValue("@nama_barang", textBoxnama.Text);
                command.Parameters.AddWithValue("@kategori_barang", textBoxkategori.Text);
                command.Parameters.AddWithValue("@stok", textBoxstok.Text);
                command.Parameters.AddWithValue("@satuan", textBoxsatuan.Text);
                command.Parameters.AddWithValue("@harga", textBoxharga.Text);
                command.Parameters.AddWithValue("@batas_minimum", textBoxbatasMin.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            con.Close();
        }
    }
}
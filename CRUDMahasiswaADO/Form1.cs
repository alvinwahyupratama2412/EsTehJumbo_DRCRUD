using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq.Expressions;


namespace CRUDMahasiswaADO
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=LAPTOP-5BS6SFFN\\ALVIN;Initial Catalog=DBAkademikADO;Integrated Security=True";


        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void ConnectDataBase()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                MessageBox.Show("Koneksi berhasil");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDataBase();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Rows.Add("NIM", "NIM");
                dataGridView1.Rows.Add("Nama", "Nama");
                dataGridView1.Rows.Add("JenisKelamin", "Jenis Kelamnin");
                dataGridView1.Rows.Add("TanggalLahir", "Tanggal Lahir");
                dataGridView1.Rows.Add("Alamat", "Alamat");
                dataGridView1.Rows.Add("KodeProdi", "Kode Prodi");

                string query = "SELECT * FROM Mahasiswa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["NIM"].ToString(),
                        reader["Nama"].ToString(),
                        reader["JenisKelamin"].ToString(),
                        Convert.ToDateTime(reader["TanggalLahir"]).ToShortDateString(),
                        reader["Alamat"].ToString(),
                        reader["KodeProdi"].ToString()
                        );

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data : " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

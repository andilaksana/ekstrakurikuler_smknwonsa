using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Aplikasi_Ekstrakurikuler_SMKNWONSA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = "server=localhost;user=root;password=;database=ekstrakurikuler_wonsa";
            MySqlConnection koneksi = new MySqlConnection(server);
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kolom Harus Terisi");
            }
            else
            {
                koneksi.Open();
                MySqlCommand perintah = new MySqlCommand("select * from user", koneksi);
                MySqlDataReader reader = perintah.ExecuteReader();
                while (reader.Read())
                {
                    if (username.Equals(reader.GetString("username")) && (password.Equals(reader.GetString("password"))))
                    {
                        MessageBox.Show("Login Berhasil");
                        this.Hide();
                        Home panggil = new Home();
                        panggil.Show();
                    }
                    else
                    {
                        MessageBox.Show("Gagal Login Silahkan Menggunakan Username dan Password yang Benar");
                    }
                }
                koneksi.Close();
            }
        }
    }
}

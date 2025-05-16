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
            MySqlConnection koneksi = new MySqlConnection("server=localhost;user=root;password=;database=ekstrakurikuler_wonsa");
            MySqlCommand command = new MySqlCommand("select count(*) from Login where username = @username and password = @password", koneksi);
            command.Parameters.AddWithValue("@username", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home panggil = new Home();
                panggil.Show();
            }
            else
            {
                MessageBox.Show("mohon isi username dan password dengan benar !!", "perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

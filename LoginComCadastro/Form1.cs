using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginComCadastro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2A4LQ4P;Initial Catalog=DBProjetoLoginCadastro;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string login = "SELECT * FROM Usuario WHERE usuário='" + txtUsuario.Text + "'and senhar='" + txtSenha.Text + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                new FormSistema().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void cbxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMostrarSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new FormCadastrar().Show();
            this.Hide();
        }
    }
}

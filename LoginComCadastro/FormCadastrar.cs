using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginComCadastro
{
    public partial class FormCadastrar : Form
    {
        public FormCadastrar()
        {
            InitializeComponent();
        }
     
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2A4LQ4P;Initial Catalog=DBProjetoLoginCadastro;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text==""&& txtSenha.Text == "") 
            {
                MessageBox.Show("Usuário ou senha errada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtConfirmaSenha.Text == txtSenha.Text)
            {
                con.Open();
                string REGISTRO = "insert into Usuario values('" + txtUsuario.Text + "','" + txtSenha.Text + "')";
                cmd = new SqlCommand(REGISTRO,con);
                cmd.ExecuteReader();
                con.Close();
                txtUsuario.Text = ""; txtSenha.Text = ""; txtConfirmaSenha.Text = "";
                MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Senhas diferentes", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = "";
                txtConfirmaSenha.Text = "";
                txtSenha.Focus();
            }
        
        }

        private void cbxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMostrarSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
                txtConfirmaSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
                txtConfirmaSenha.PasswordChar = '*';
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            txtSenha.Text = "";
            txtConfirmaSenha.Text = "";
            txtSenha.Focus();
        }

        private void lblRetornar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}

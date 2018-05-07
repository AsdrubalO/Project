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

namespace Conexion
{
    public partial class Login : Form
    {
        conexionbd c = new conexionbd();
       
        public Login()
        {
            InitializeComponent();
          
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public void Log(string usuario, string password)
        {
            try 
            {
                c.abrir();
                SqlCommand cmd = new SqlCommand("Select Nombre, Tipo_usuario from Usuarios where Usuario = @usuario and Pass=@password", c.conectarbd );
                cmd.Parameters.AddWithValue("Usuario", usuario);
                cmd.Parameters.AddWithValue("Password",password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    this.Hide();

                    if(dt.Rows[0][1].ToString() == "Admin")
                    {
                        new Administrador().Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "User")
                    {
                        new Usuarios().Show();
                    }

                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecto");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.cerrar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Log(this.txtUser.Text, this.txtPass.Text);
        }
    }
}

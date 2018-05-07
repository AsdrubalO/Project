using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Conexion
{
    class conexionbd
    {
        string cadena = "Data Source= USER\\EMERSON;Initial Catalog= Ejemplo; Integrated Security=true";

        public SqlConnection conectarbd = new SqlConnection();

        public conexionbd()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try 
            {
                conectarbd.Open();
                MessageBox.Show("Conexion Abierta");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al abrir la conexion "+ex);
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }

    }
}

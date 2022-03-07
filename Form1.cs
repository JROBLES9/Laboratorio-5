using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_5
{
    public partial class Form1 : Form
    {
        List <Informacion> informacion = new List <Informacion> ();
        List <Horas> horas = new List <Horas> ();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Usuario\source\repos\Laboratorio 5\bin\Debug\Informacion.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Informacion b = new Informacion();
                String texto = reader.ReadLine();

                b.Numero_empleado = Convert.ToInt32(texto);
                texto = reader.ReadLine();
                b.Nombre = texto;
                texto = reader.ReadLine();
                b.sueldoXHora = Convert.ToInt32(texto);
                informacion.Add(b);
            }
            reader.Close();
            
            fileName = @"C:\Users\Usuario\source\repos\Laboratorio 5\bin\Debug\Horas.txt";
            stream = new FileStream(fileName, FileMode.Open,FileAccess.Read);
            reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Horas b = new Horas();
                String texto = reader.ReadLine();

                b.Numero_empleado = Convert.ToInt32(texto);
                texto = reader.ReadLine();
                b.HorasXmes = Convert.ToInt32(texto);
                texto = reader.ReadLine();
                b.mes = texto;
                horas.Add(b);
            }
            reader.Close();

            for (int i = 0; i < horas.Count; i++)
            {

            }

            


            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = informacion;
            dataGridView1.Refresh();
        }
    }
}

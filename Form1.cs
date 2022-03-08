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
        List <Empleado> empleado = new List <Empleado> ();
        List<Empleado> aux = new List<Empleado> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string fileName = "Informacion.txt";
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
            
            fileName = "Horas.txt";
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
                Empleado a = new Empleado();
                a.Numero_Empleado = informacion[i].Numero_empleado;
                a.Nombre = informacion[i].Nombre;
                a.sueldoXhora = informacion[i].sueldoXHora;
                a.horasXmes = horas[i].HorasXmes;
                a.mes = horas[i].mes;
                a.sueldoXmes = a.horasXmes * a.sueldoXhora;

                empleado.Add(a);
            }

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = empleado;
            dataGridView1.Refresh();

            foreach (var a in empleado)
            {
                comboBox1.Items.Add(a.Nombre);
            }
        }
        
        private void BuscarEmpleadoBt_Click(object sender, EventArgs e)
        {
            string nombre = comboBox1.SelectedItem.ToString();

            Empleado a = empleado.Find(b => b.Nombre.Equals(nombre));
            aux.Add(a);
            

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = aux;
            dataGridView2.Refresh();
        }
    }
}

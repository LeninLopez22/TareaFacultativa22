using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasadecambio
{
    public partial class Form1 : Form
    {
        //Los cambios son los siguientes - Declarar Variable Globales
        ServiceCambio.Tipo_Cambio_BCNSoapClient cliente = new ServiceCambio.Tipo_Cambio_BCNSoapClient();
        double TC; //TC indica el tipo de cambio
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //si das doble click al textbox1 unicamente, te crea el metodo pero no hará nada al respecto.
            //No lo borres ahora porque ya que se hizo el evento,
            //Si eliminas este metodo vacio empezará a dar error en el Form1.cs[Diseño].
            //ten cuidao en donde hacéis doble click en el Diseño....
        }
        //paso 1 hacer doble click sobre el diseño, paso 2 digitar y Guardar Cambios, paso 3 es INICIAR (ejecutarlo)
        private void Form1_Load(object sender, EventArgs e)
        {
            //Invocamos el metodo RecuperarTC_Dia y mostramos su resultado en la caja de texto
            //ServiceCambio.Tipo_Cambio_BCNSoapClient cliente = new ServiceCambio.Tipo_Cambio_BCNSoapClient();
            //textBox1.Text = cliente.RecuperaTC_Dia(DateTime.Today.Year, DateTime.Now.Month, DateTime.Today.Day).ToString();
            TC = cliente.RecuperaTC_Dia(DateTime.Today.Year, DateTime.Now.Month, DateTime.Today.Day);
            textBox1.Text = TC.ToString();
        }
        //Hacer doble click en el button1 para generar evento - metodo
        private void button1_Click(object sender, EventArgs e)
        {
            double resultado = double.Parse(textBox2.Text) / TC;
            textBox3.Text = "U$" + resultado;
        }
        //Hacer doble click en el button2 para generar evento - metodo
        private void button2_Click(object sender, EventArgs e)
        {
            double resultado = double.Parse(textBox3.Text) * TC;
            textBox2.Text = "C$" + resultado;
        }
    }
}

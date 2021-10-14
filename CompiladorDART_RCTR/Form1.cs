using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CompiladorDART_RCTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lexico = new Lexico(textBox1.Text);
            lexico.EjecutarLexico();

            var objSintactico = new Sintactico(lexico.listaToken);
            objSintactico.EjecutarSintactico(objSintactico.listaTokens);

            List<Error> listaErroresLexico = lexico.listaErrorLexico;
            List<Error> listaErroresSintactico = objSintactico.listaError;

            List<Error> listaErrores = listaErroresLexico.Union(listaErroresSintactico).ToList();

            var Lista = new BindingList<Token>(lexico.listaToken);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Lista;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = listaErrores;

        }
    }
}

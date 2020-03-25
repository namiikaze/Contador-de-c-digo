using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CountCode
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rodar(txtPath.Text);
        }

        private void Rodar(string path){
            Contar contar = new Contar();

            string listaExtensoes = txtExtensoes.Text;
            string[] extensoes = listaExtensoes.Split(';');

            foreach (string a in extensoes)
            {
             //   MessageBox.Show(a);
            }
            
            List<string> tipo = new List<string>();
            tipo.Add("js");
            // tipo.Add(".php");
            string[] TiposPermitido = tipo.ToArray();

            string resultado = contar.Calcular(path, extensoes);
            richTextBox1.Text = resultado;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
        }
    }
}

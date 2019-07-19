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
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace XML_Display_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string FilePath;
        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.ShowDialog();
                FilePath = openFileDialog1.FileName;
                textBox1.Text = string.Format(FilePath);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var allTheTextOfFile = File.ReadAllText(FilePath);
                XmlDocument file1 = new XmlDocument();
                StringWriter neat = new StringWriter();
                file1.LoadXml(allTheTextOfFile);
                file1.Save(neat);
                String nicelyFormatted = neat.ToString();
                textBox2.Text = nicelyFormatted;
            }
            catch
            {
                //Here we can add in a message box to warn the user
                MessageBox.Show("Looks like something went wrong. Make sure a valid XML (.xml) file is selected.");
            }
        }
    }
}
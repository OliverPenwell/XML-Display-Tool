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
                var allTheTextOfFile = File.ReadAllText(FilePath);
                textBox1.Text = string.Format(FilePath);
                XmlDocument file1 = new XmlDocument();
                StringWriter neat = new StringWriter();
                file1.LoadXml(allTheTextOfFile);
                file1.Save(neat);
                String nicelyFormatted = neat.ToString();
                textBox2.Text = nicelyFormatted;
            }
        }
    }
}
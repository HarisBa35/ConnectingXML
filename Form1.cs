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
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;


        }
        //Spajanje exporta
        private void button1_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"C:\Terminal_razmjena\Prenos_na_terminal");
            if (filePaths.Length == 0)
            {
                MessageBox.Show("Niste exportovali drugi export!");
                return;
            }
            XElement xFileRoot = XElement.Load(@"C:\Users\fakturno1\Desktop\New folder (4)\export.xml");
            XElement xFileChild = XElement.Load(@"C:\Terminal_razmjena\Prenos_na_terminal\export.xml");
            var header = xFileChild.Elements("zaglavlje");
            xFileRoot.Add(header);
            xFileRoot.Save(@"C:\Terminal_razmjena\Prenos_na_terminal\export.xml");
            label1.Text = "Exporti su spojeni. Izvršite slanje exporta na prenosni terminal!";
            File.Delete(@"C:\Users\fakturno1\Desktop\New folder (4)\export.xml");
            button1.Enabled = false;

        }
        
        // Prebacivanje u folder za spajanje       
        private void button2_Click(object sender, EventArgs e)
        {
            string fileToCopy = @"C:\Terminal_razmjena\Prenos_na_terminal\export.xml";
            string destinationDirectory = @"C:\Users\fakturno1\Desktop\New folder (4)\export.xml";
            string[] filePathsPrebaci = Directory.GetFiles(@"C:\Terminal_razmjena\Prenos_na_terminal");
            if (filePathsPrebaci.Length == 0)
            {
                MessageBox.Show("Nema exporta u folderu!");
                return;
            }
            File.Move(fileToCopy, destinationDirectory);
            MessageBox.Show("Export je prebačen u folder za spajanje, sad exportujte drugi export");
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string MessageBoxTitle = "Spajanje exporta!!!";
            string MessageBoxContent = "Jeste li sigurni da ste završili spajanje exporta???";

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (dialogResult == DialogResult.Yes)
            {
               
                Application.ExitThread();
            }

        }
    }
    
}

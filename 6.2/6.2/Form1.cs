using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>();
            foreach (Control obj in this.Controls)
            {
                if (obj is Label)
                {
                    labels.Add((Label)obj);
                }

            }
            foreach (Label label in labels)
            {
                this.Controls.Remove(label);

            }
        }
    }
}

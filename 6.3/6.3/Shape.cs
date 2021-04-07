using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._3
{
    public partial class Shape : PictureBox
    {
        private PictureBox pictureBox1 = new PictureBox();

        public void PaintPicBox(Form form)
        {
            pictureBox1.Name = "rectangle";
            pictureBox1.MouseMove += MouseOn;
            pictureBox1.MouseLeave += MouseOff;
            pictureBox1.Location = new Point(200, 160);
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.BackColor = Color.Black;
            form.Controls.Add(pictureBox1);
        }
        private void MouseOn(object sender, MouseEventArgs e)

        {
            if (listBox1.SelectedItem == null) pictureBox1.BackColor = Color.Green;
            else pictureBox1.BackColor = Color.FromName(listBox1.SelectedItem.ToString());
            pictureBox1.BackColor = Color.Red;
        }
        private void MouseOff(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        
    }
}

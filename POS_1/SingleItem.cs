using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_1
{
    public partial class SingleItem : UserControl
    {
        public SingleItem(int id,String code,String name,int qty,double price)
        {
            InitializeComponent();
            label1.Text = id.ToString();
            label2.Text = code;
            label3.Text = name;
            label4.Text = qty.ToString();
            label5.Text = price.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

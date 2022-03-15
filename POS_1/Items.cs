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
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            int topMargin = 10;
            for (int i=0;i<10;i++) {
                SingleItem SinItm = new SingleItem(1,"#2356","Samba Rice",25,150.00);
                panel1.Controls.Add(SinItm);
                SinItm.Top = topMargin;
                topMargin = (SinItm.Top + SinItm.Height + 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Container con = new Container();
            con.Visible = true;
        }
    }
}

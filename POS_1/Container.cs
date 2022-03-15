using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_1
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            AddItems additm = new AddItems();
            additm.Dock = DockStyle.Fill;
            panel1.Controls.Add(additm);


            
        }
    }
}

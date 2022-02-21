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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items itm = new Items();
            itm.Dock = DockStyle.Fill;
            panel3.Controls.Add(itm);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }
    }
}

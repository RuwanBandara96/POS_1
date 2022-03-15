using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            panel3.Controls.Clear();
            Items itm = new Items();
            itm.Dock = DockStyle.Fill;
            panel3.Controls.Add(itm);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

<<<<<<< HEAD
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AddItems additm = new AddItems();
            additm.Dock = DockStyle.Fill;
            panel3.Controls.Add(additm);
=======
        private void button6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userid = 0;
            Properties.Settings.Default.userrole = null;
            Thread tr = new Thread(()=> {
                Application.Run(new Login());
            });
            tr.SetApartmentState(ApartmentState.STA);
            tr.Start();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SettingsControl scontrol = new SettingsControl();
            scontrol.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(scontrol);
>>>>>>> gayantha
        }
    }
}

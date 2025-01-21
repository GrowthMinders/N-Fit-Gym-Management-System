using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Fit_Gym_Management_System
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.Progress.Maximum = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Progress.Value == 100)
            {
                timer_Tick.Stop();
                LoginForm form2 = new LoginForm();
                form2.Show();
                this.Hide();

            }
            else
            {
                this.Progress.Value += 1;
            }
        }
    }
}

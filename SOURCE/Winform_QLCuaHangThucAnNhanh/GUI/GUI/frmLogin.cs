using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
			this.button1.Click += Button1_Click;
        }

		private void Button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

	}
}

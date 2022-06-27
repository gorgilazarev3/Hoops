using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoops
{
    public partial class PlayerForm : Form
    {
        public string PlayerName { get; set; }
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Trim().Length > 0)
            {
                PlayerName = tbName.Text;
            }
            else
            {
                this.Close();
            }
        }
    }
}

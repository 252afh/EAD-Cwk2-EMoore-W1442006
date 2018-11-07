using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeEdit : Form
    {
        public IncomeEdit()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}

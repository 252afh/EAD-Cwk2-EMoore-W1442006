using System;
using System.Windows.Forms;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayersEdit : Form
    {
        public PayersEdit()
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

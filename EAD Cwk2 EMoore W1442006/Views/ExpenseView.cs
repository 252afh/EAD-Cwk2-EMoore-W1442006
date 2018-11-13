using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class ExpenseView : Form
    {
        /// <summary>
        /// The view to add a new <see cref="Expense"/>
        /// </summary>
        private ExpenseAdd ExpenseAddView;

        /// <summary>
        /// The view to edit an <see cref="Expense"/>
        /// </summary>
        private ExpenseEdit ExpenseEditView;

        public ExpenseView()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.ExpenseEditView == null)
            {
                this.ExpenseEditView = new ExpenseEdit();
                this.ExpenseEditView.FormClosed += this.ExpenseEditViewOnFormClosed;
            }

            this.ExpenseEditView.Show(this);
            this.Hide();
        }

        private void ExpenseEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.ExpenseEditView = null;
            this.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (this.ExpenseAddView == null)
            {
                this.ExpenseAddView = new ExpenseAdd();
                this.ExpenseAddView.FormClosed += this.ExpenseAddViewOnFormClosed;
            }

            this.ExpenseAddView.Show(this);
            this.Hide();
        }

        private void ExpenseAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.ExpenseAddView = null;
            this.Show();
        }

        private void ExpenseView_VisibleChanged(object sender, EventArgs e)
        {
            this.ExpenseListView.Items.Clear();

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                ExpenseListView.Items.Add(new ListViewItem(new[]
                {
                    expense.Payee.Name,
                    expense.Ref,
                    "£" + expense.Amount.ToString(),
                    expense.IsRecurring ? "Yes" : "No",
                    expense.IsRecurring ? expense.Interval.ToString() + " days" : "-",
                    expense.InitialPaidDate.ToShortDateString(),
                    expense.IsRecurring ? expense.LastPaidDate.ToShortDateString() : "-"
                }));
            }
        }
    }
}

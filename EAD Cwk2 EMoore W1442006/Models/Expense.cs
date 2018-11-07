using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    [Serializable]
    public class Expense : Payment
    {
        /// <summary>
        /// The <see cref="Payee"/> related to a expense payment
        /// </summary>
        public Payee Payee { get; set; }
    }
}

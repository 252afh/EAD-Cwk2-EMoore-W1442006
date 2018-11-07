using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_Cwk2_EMoore_W1442006.Models
{
    [Serializable]
    public class Income : Payment
    {
        /// <summary>
        /// The <see cref="Payer"/> related to the income payment
        /// </summary>
        public Payer Payer { get; set; }
    }
}

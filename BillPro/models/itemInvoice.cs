using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BillPro.models;

namespace BillPro
{
    public class itemInvoice
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Itemm")]
        public int itemId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Invoicee")]
        public int invoiceNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual Invoice Invoicee { get; set; }
        public virtual Item Itemm { get; set; }

    }
}

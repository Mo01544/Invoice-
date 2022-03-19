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
    public class Invoice
    {
        [Key]
        public int invoiceNamber { get; set; }

        [ForeignKey("Clientt")]
        public int clientNumber { get; set; }

        [Column(TypeName = "date"), Required]
        public DateTime invoiceDate { get; set; }

        [Required]
        public double invoicePaidup { get; set; }


        public double invoiceNet { get; set; }

       

        public virtual Client Clientt { get; set; }
        public virtual List<itemInvoice> ItemInvoices { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BillPro.models
{
    public class Client
    {
        [Key]
        public int clientNumber { get; set; }

        [Required]
        public string clientName { get; set; }

        [MaxLength(60)]
        public string clientAddress { get; set; }

        [Column(TypeName ="varchar")]
        [Required]
        [StringLength(14)]
        public string clientPhone { get; set; }

        public virtual List<Invoice> Invoices{ get; set; }

        //coment ////t399
    }
}

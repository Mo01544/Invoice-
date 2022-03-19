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
    public class Item
    {
        [Key]
        public int itemId { get; set; }

        [Required]
        public string itemName { get; set; }

        [ForeignKey("comp")]
        public string companyName { get; set; }

        [ForeignKey("Typee")]
        public string typeName { get; set; }

        [ForeignKey("Unitt")]
        public string unitName { get; set; }
        [MaxLength(100)]
        public string itemNotes { get; set; }

        [Required]
        public int itemBuyingPrice { get; set; }

        [Required]
        public int itemSellingPrice { get; set; }

        public virtual Company comp { get; set; }
        public virtual Typee Typee { get; set; }
        public virtual Unit Unitt { get; set; }
        public virtual List<itemInvoice> ItemInvoices { get; set; }

    }
}

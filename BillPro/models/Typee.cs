using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillPro.models
{
    public class Typee
    {
        [Key]
        public string typeName { get; set; }

        [MaxLength(100)]
        public string typeNotes { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}

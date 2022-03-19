using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BillPro.models
{
    public class Unit
    {
        [Key]
        public string unitName { get; set; }

        [MaxLength(100)]
        public string unitNotes { get; set; }

        public virtual List<Item>Items { get; set; }
    }
}

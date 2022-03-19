using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillPro.models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }

        [ForeignKey("Comp")]
        public string cName { get; set; }

        [MaxLength(50), Required]
        public string empName { get; set; }

        public virtual Company Comp { get; set; }
    }
}

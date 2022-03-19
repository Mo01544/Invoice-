using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BillPro.models
{
    public class Company
    {
        [Key]
        public string companyName { get; set; }

        [MaxLength(100)]
        public string companyNotes { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public virtual List<Item> Items { get; set; }

    }
}

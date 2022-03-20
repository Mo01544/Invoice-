using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillPro.models;
namespace BillPro
{
    public partial class Reports : Form
    {
        billDB db;
        public Reports()
        {
            InitializeComponent();
            db = new billDB();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var q = db.Invoices.Where(i => i.invoiceDate.CompareTo(from.Value) >= 0 && i.invoiceDate.CompareTo(dateTimePicker1.Value) <= 0).Select(item =>  new { item.invoiceNamber , item.clientNumber,item.billTolal,item.percentageDiscount,item.valueDiscount,item.invoicePaidup, item.invoiceNet,item.invoiceRest,item.invoiceDate   }).ToList();
            dataGridView1.DataSource = q;
        }
    }
}

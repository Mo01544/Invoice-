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
    public partial class invoice : Form
    {
        billDB db;
        public invoice()
        {
            InitializeComponent();
            db = new billDB(); 
            cmbItemName.DisplayMember = "itemName";
            cmbItemName.ValueMember = "itemName";
            //cmbItemName.DataSource = db.ItemInvoices.ToList();
            cmbClientName.DisplayMember = "clientName";
            cmbClientName.ValueMember = "clientNumber";
            cmbClientName.DataSource = db.Clients.ToList();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invoice invoicee = new Invoice()
            {
                invoiceDate = DateTime.Now,
                invoicePaidup = int.Parse(txtPaidUp.Text),
                


            };
            //MessageBox.Show(cmbItemName.SelectedValue.ToString());
            //invoicee.ItemInvoicee.itemName = cmbItemName.SelectedValue.ToString();
            //invoicee.Clientt.clientName = cmbClientName.SelectedValue.ToString();


            //if (int.Parse(txtQuantity.Text) < 0)
            //{
            //    MessageBox.Show("Quantity Should be Greater than Zero or Equal Zero");
            //    return;
            //}

            //if (int.Parse(txtPaidUp.Text) < 0)
            //{
            //    MessageBox.Show("Paid Up Should be Greater than Zero or Equal Zero");
            //    return;
            //}

            db.Invoices.Add(invoicee);
            //MessageBox.Show("Done And Added");
            db.SaveChanges();

        }
    }
}

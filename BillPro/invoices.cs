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
        Item itemm;
        decimal billTotal = 0;
        List<object> addedItems;
        public invoice()
        {
            InitializeComponent();
            db = new billDB();
            addedItems = new List<object>();

        }
        static bool typeCheckInt(string input)
        {
            int num = 1;
            return int.TryParse(input, out num);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            var data = db.Items.Select(i => new { item_code = i.itemId, item_name = i.itemName, unit = i.unitName, quantiy = txtQuantity.Value, total = (txtQuantity.Value * i.itemSellingPrice) }).Where(ii => ii.item_code == (int)cmbItemName.SelectedValue).ToList().Single();
            addedItems.Add(data);
            dgItems.DataSource = null;
            dgItems.DataSource = addedItems;

            

            foreach (var item in addedItems)
            billTotal += (decimal)item.GetType().GetProperty("total").GetValue(item, null);


            txtBillTotal.Text = billTotal.ToString();
            billTotal = 0;
        }


        

        private void invoice_Load(object sender, EventArgs e)
        {
            cmbItemName.DisplayMember = "itemName";
            cmbItemName.ValueMember = "itemId";
            cmbItemName.DataSource = db.Items.ToList();
            

            cmbClientName.DisplayMember = "clientName";
            cmbClientName.ValueMember = "clientNumber";
            cmbClientName.DataSource = db.Clients.ToList();

            //set bill date 
            txtBillDate.Text = DateTime.Now.ToString();
            //load bill number 
            var bill = db.Invoices.ToList().LastOrDefault();

            if (bill != null)
            {
                txtBillNumber.Text = (bill.invoiceNamber+1).ToString();

            }
            else
            {
                txtBillNumber.Text = (1).ToString();
            }
        }

        private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
  

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (txtQuantity.Value * itemm.itemSellingPrice).ToString();
            
        }

        private void cmbItemName_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            itemm = db.Items.ToList().Where(i => i.itemId == (int)cmbItemName.SelectedValue).SingleOrDefault();
            if (itemm != null)
                txtSelling.Text = itemm.itemSellingPrice.ToString();
        }

        private void txtValueDiscound_TextChanged(object sender, EventArgs e)
        {
            string value = txtValueDiscound.Text;
            if (value == "")
            {
                MessageBox.Show("PLZ enter Discound");
                txtPercentage.Enabled = true;
            }
            else if (typeCheckInt(txtValueDiscound.Text) == false)
            {
                MessageBox.Show("Discount Value must be A number");
            }
            else
            {
                var calcnet = (decimal.Parse(txtBillTotal.Text) - decimal.Parse(txtValueDiscound.Text)).ToString();
                txtNet.Text = calcnet.ToString();
                txtPercentage.Enabled = false;
            }
           
        }

        private void txtPaidUp_TextChanged(object sender, EventArgs e)
        {
            string v1 = txtPaidUp.Text;
            string v2 = txtNet.Text;
            if(v1 == "")
            {
                MessageBox.Show("Please Add Paid for client First");

            }
            else if(double.Parse(v2) > double.Parse(v1))
            {
                nameError.ForeColor = Color.Red;
                nameError.Text = "Piad Up must be greater than or equl The Net";
            }
            else if (typeCheckInt(txtPaidUp.Text) == false)
            {
                MessageBox.Show("Piad Up must be A number");
            }
            else
            {

                nameError.ForeColor = Color.Green;
                nameError.Text = "success";
                var calcrest = (decimal.Parse(txtPaidUp.Text) - decimal.Parse(txtNet.Text));
                txtRest.Text = calcrest.ToString();
            }
           
        }

        

        private void txtNet_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBillTotal_TextChanged(object sender, EventArgs e)
        {
            
        }
       
        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {
            string value = txtPercentage.Text;

            if (value == "")
            {
                //Display Error Message
                MessageBox.Show("Please Add Discount First");
                txtValueDiscound.Enabled = true;
            }
            else if(typeCheckInt(txtPercentage.Text) == false)
            {
                MessageBox.Show("Discount Percentage must be A number");
            }
            else
            {
                //Get the discount in decimal value
                decimal subTotal = decimal.Parse(txtBillTotal.Text);
                decimal discount = decimal.Parse(txtPercentage.Text);
                txtValueDiscound.Enabled = false;
                
                decimal grandTotal = (discount / 100) * subTotal;

                //Display the GrandTotla in TextBox
                txtNet.Text = grandTotal.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice()
            {
            clientNumber = (int)cmbClientName.SelectedValue,
            invoiceDate = txtBillDate.Value,
            invoicePaidup = int.Parse(txtPaidUp.Text),
            invoiceNet = double.Parse(txtNet.Text),
        };

            
            

            db.Invoices.Add(invoice);
            MessageBox.Show("saved :)");
            db.SaveChanges();
        }
    }
}
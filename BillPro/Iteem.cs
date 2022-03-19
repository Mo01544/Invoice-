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
    public partial class Iteem : Form
    {
        billDB db;
        public Iteem()
        {
            InitializeComponent();
            db=new billDB();
            cmb_company.ForeColor = Color.Black;
            cmb_company.DisplayMember = "companyName";
            cmb_company.ValueMember = "companyName";
            cmb_company.DataSource = db.Companies.ToList();

            cmb_type.DisplayMember = "typeName";
            cmb_type.ValueMember= "typeName";
            cmb_type.DataSource = db.Types.ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Item_Enter(object sender, EventArgs e)
        {
            if (txt_item_name.Text=="Item Name")
            {
                txt_item_name.Text = "";
                txt_item_name.ForeColor = Color.Black;
            }
        }

        private void sell_Enter(object sender, EventArgs e)
        {
            if (txt_Selling.Text == "Selling Price")
            {
                txt_Selling.Text = "";
                txt_Selling.ForeColor = Color.Black;
            }
        }

        private void buy_Enter(object sender, EventArgs e)
        {
            if (txt_buying_name.Text == "Buying Price")
            {
                txt_buying_name.Text = "";
                txt_buying_name.ForeColor = Color.Black;
            }
        }

        private void Note_Enter(object sender, EventArgs e)
        {
            if (T_notes.Text == "Notes")
            {
                T_notes.Text = "";
                T_notes.ForeColor = Color.Black;
            }
        }

        private void Iteem_Load(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            Item i = new Item()
            {
                companyName = cmb_company.SelectedValue.ToString(),
                typeName = cmb_type.SelectedValue.ToString(),
                itemName=txt_item_name.Text,
                itemNotes=T_notes.Text,
                itemSellingPrice=int.Parse(txt_Selling.Text),
                itemBuyingPrice=int.Parse(txt_buying_name.Text),
               
            };
            if (int.Parse(txt_Selling.Text) < 0)
            {
                MessageBox.Show("Selling Price Should be Greater than Zero or Equal Zero");
                return;
            }
            
            if (int.Parse(txt_buying_name.Text) < 0 )
            {
                MessageBox.Show("Buting Price Should be Greater than Zero or Equal Zero and less than from Selling Price");
                return;
            }
            if (int.Parse(txt_buying_name.Text) > int.Parse(txt_Selling.Text))
            {
                MessageBox.Show("Buting Price Should be less than from Selling Price");
                return;
            }

            db.Items.Add(i);
            db.SaveChanges();
            cmb_company.Text = cmb_type.Text = txt_item_name.Text = txt_buying_name.Text = txt_Selling.Text = T_notes.Text = "";
            MessageBox.Show("Done And Added");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

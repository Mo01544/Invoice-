using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillPro
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
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
    }
}

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
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void C_name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void text_changed(object sender, EventArgs e)
        {
            if (C_name.Text == "Company Name")
            {
                C_name.Text = "";
                C_name.ForeColor = Color.Black;
            }
            
        }

        private void C_name_MouseEnter(object sender, EventArgs e)
        {

        }

        private void C_name_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void Note_Enter(object sender, EventArgs e)
        {
            if (C_notes.Text == "Notes")
            {
                C_notes.Text = "";
                C_name.ForeColor = Color.Black;
            }
        }
    }
}

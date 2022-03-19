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
    public partial class unitt : Form
    {
        billDB db;
        public unitt()
        {
            InitializeComponent();
            db = new billDB();
        }

        private void unit_Load(object sender, EventArgs e)
        {

        }
        static bool typeCheckInt(string input)
        {
            int num = 1;
            return int.TryParse(input, out num);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Unit u = new Unit() { 
                unitName = txt_unit_name.Text,
                unitNotes = txt_unit_notes.Text 
            };

            if (typeCheckInt(txt_unit_name.Text) == true)
            {
                MessageBox.Show("Enter Name Again");
                return;
            }
            db.Units.Add(u);
            db.SaveChanges();
            MessageBox.Show("Done and updated");
            txt_unit_name.Text = "";
            txt_unit_notes.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

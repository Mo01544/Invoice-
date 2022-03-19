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
    public partial class Companny : Form
    {
        billDB db;
        public Companny()
        {
            InitializeComponent();
            db = new billDB();
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
                C_notes.ForeColor = Color.Black;
            }
        }
        static bool typeCheckInt(string input)
        {
            int num = 1;
            return int.TryParse(input, out num);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Company c = new Company()
            {
                companyName = C_name.Text,
                companyNotes = C_notes.Text
            };
            if (C_name.Text == "")
            {

                MessageBox.Show("Required");

            }
            else if (db.Companies.Where(n => n.companyName == C_name.Text).SingleOrDefault() != null)
            {
                MessageBox.Show("Duplicated");
                C_name.Text = "";
            }
            else if (typeCheckInt(C_name.Text) == true)
            {
                MessageBox.Show("PLz enter your Name again");
                C_name.Text = "";
            }
            else
            {
                db.Companies.Add(c);
                db.SaveChanges();
                MessageBox.Show("Done And Saved");
                C_name.Text = "Company Name";
                C_name.ForeColor = Color.Gray;
                C_notes.Text = "Notes";
                C_notes.ForeColor = Color.Gray;
            }


        }

        private void C_notes_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Species : Form
    {
        billDB db;
        string cname;
        public Species()
        {
            InitializeComponent();
            db=new billDB();
            cmb_company_name.ForeColor = Color.Black;
            cmb_company_name.DisplayMember = "companyName";
            cmb_company_name.DataSource = db.Companies.ToList();
        }


        private void Species_Load(object sender, EventArgs e)
        {

        }
        static bool typeCheckInt(string input)
        {
            int num = 1;
            return int.TryParse(input, out num);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Typee type = new Typee()
            {
                typeName = txt_type_type_name.Text,
                typeNotes = txt_type__notes.Text
            
            };

            if (typeCheckInt(txt_type_type_name.Text) == true)
            {
                MessageBox.Show("Enter Name Again");
                return;
            }
            cname = cmb_company_name.SelectedValue.ToString();
            db.Types.Add(type);
            db.SaveChanges();
            MessageBox.Show("Done and updated");
            txt_type_type_name.Text = "";
            txt_type__notes.Text = "";
        }

        private void cmb_company_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillPro.models;
namespace BillPro
{
    public partial class Clientt : Form
    {
        billDB db;
        public Clientt()
        {
            InitializeComponent();
            db = new billDB();
        }
        static bool typeCheckInt(string input)
        {
            int num = 1;
            return int.TryParse(input, out num);
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Client cn = new Client()
            {
                clientName = txt_client_name.Text,
                clientAddress = txt_address.Text,
                clientPhone = txt_phone.Text


            };


            if (typeCheckInt(cn.clientName) == true || cn.clientName =="")
            {
                nameError.ForeColor = Color.Red;
                nameError.Text = "Enter Ur Name Again";

                return;
                
            }
            else
            {
                nameError.ForeColor = Color.Green;
                nameError.Text = "success";
            }
            
            

            string num = txt_phone.Text;
            Regex regex = new Regex(@"^(00201|\+201|01)[0-2,5]{1}[0-9]{8}$");
            Match m = regex.Match(num);
            if (m.Success)
            {

            }
            else
            {
                MessageBox.Show("Please Enter Ur Phone Again");
                txt_phone.Text = "";
                return ;
            }


            db.Clients.Add(cn);
            MessageBox.Show("Done");
            db.SaveChanges();
            txt_address.Text = txt_client_name.Text = txt_phone.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

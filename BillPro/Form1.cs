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
    public partial class Form1 : Form
    {
        billDB db;
        public Form1()
        {
            InitializeComponent();
            load_Form(new Homepage());
            db = new billDB();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            load_Form(new Companny());
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            //button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //button1.BackColor = Color.Yellow;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor=Color.Green;
        }

        public void load_Form (object form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            load_Form(new Homepage());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            load_Form(new Species());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            load_Form(new unitt());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            load_Form(new Iteem());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            load_Form(new Clientt());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            load_Form(new invoice());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            load_Form(new Reports());
        }
    }
}

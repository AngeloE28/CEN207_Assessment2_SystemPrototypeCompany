using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CEN207_Assessment2_SystemPrototypeCompany
{
    public partial class LoginForm : Form
    {
        // Rabbitmq variables instances
        public static String username = "";
        public static String pass = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Get the values
            username = txtbxUserName.Text;
            pass = txtbxPassword.Text;

            OrderTrackerManagerForm trackingForm = new OrderTrackerManagerForm();
            trackingForm.ShowDialog();

            this.Close();
        }
    }
}

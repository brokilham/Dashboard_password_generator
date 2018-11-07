using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Dashboard_password_generator
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            
            string password =  txt_password.Text;
            string key = txt_key.Text;

            if (password.Length > 0 && key.Length > 0) {
                txt_result_pass.Text =  MD5_encryptor(key, password);
            }
        }

        private string MD5_encryptor(string key, string password) {
            
            var provider = MD5.Create();

            byte[] bytes = provider.ComputeHash(Encoding.ASCII.GetBytes(key + password + key));
            string computedHash = BitConverter.ToString(bytes);
            return computedHash.Replace("-", "");
        }

 

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_password.Text = "";
            txt_key.Text = "";
            txt_result_pass.Text = "";
        }
    }
}

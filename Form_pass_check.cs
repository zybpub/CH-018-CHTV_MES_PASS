using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colortv_test_automation
{
    public partial class Form_pass_check : Form
    {
        public Form_pass_check()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //999 "pass":"QWQ/r3FGnyU=",
            if (Encrypt.DES.DesDecrypt(passmes_config_json.pass) == textBox1.Text)
            {
                this.Visible=false;
                Form_Passmes_Setup fwhs = new Form_Passmes_Setup();
                fwhs.ShowDialog();
                this.Close();
            }
            else {
                label3.Text = "输入密码不正确";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                button1_Click(null,null);
            }
        }
    }
}

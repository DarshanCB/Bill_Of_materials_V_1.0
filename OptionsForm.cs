using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Importer
{
    public partial class OptionsForm : Form
    {

        public OptionsForm()
        {
            InitializeComponent();

            tbURL.Text = Properties.Settings.Default.ARAS_URL;
            tbDatabaseName.Text = Properties.Settings.Default.ARAS_DB_Name;
            tbUser.Text = Properties.Settings.Default.ARAS_DB_Username;
            tbPassword.Text = Properties.Settings.Default.ARAS_DB_Userpassword;

            if (Properties.Settings.Default.USE_AML)
            {
                rbAML.Checked = true;
                rbDirect.Checked = false;
            }
            else
            {
                rbAML.Checked = false;
                rbDirect.Checked = true;
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ARAS_URL = tbURL.Text ;
            Properties.Settings.Default.ARAS_DB_Name = tbDatabaseName.Text;
            Properties.Settings.Default.ARAS_DB_Username = tbUser.Text;
            Properties.Settings.Default.ARAS_DB_Userpassword = tbPassword.Text;

            if (rbAML.Checked)
            {
                Properties.Settings.Default.USE_AML = true;
            }
            else
            {
                Properties.Settings.Default.USE_AML = false;
            }

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void rbAML_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}

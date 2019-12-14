using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_App.Data_Library;

namespace Attendance_App.UserControls
{
    public partial class uc_scanpage : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_scanpage()
        {
            InitializeComponent();
            txt_empid.Focus();
        }

        public void refreshData()
        {
            txt_adresse.Clear();
            txt_contact.Clear();
            //txt_empid.Clear();
            txt_fonction.Clear();
            txt_name.Clear();
            txt_organisation.Clear();
            lbl_access_level.Text = "";
        }
        private void txt_empid_TextChanged(object sender, EventArgs e)
        {
            refreshData();
            rps.search_zone_infos_code(bunifuCustomDataGrid1, txt_empid.Text);
            lbl_access_level.Visible = true;
            rps.search_accesslevel_infos_code(lbl_access_level, txt_empid.Text);
            rps.search_infos_code(txt_name, txt_fonction, txt_organisation, txt_contact, txt_adresse, txt_empid.Text);
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            rps.enregistrer_attendance(DateTime.Today, txt_empid.Text);
        }
    }
}

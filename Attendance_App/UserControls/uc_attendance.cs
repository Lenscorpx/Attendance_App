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
    public partial class uc_attendance : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_attendance()
        {
            InitializeComponent();
            refreshData();
        }
        public void refreshData()
        {
            rps.afficher_attendance(bunifuCustomDataGrid1);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (rdbtn_id.Checked == true)
            {
                rps.search_attendance_byid(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_noms.Checked == true)
            {
                rps.search_attendance_byname(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_organisation.Checked == true)
            {
                rps.search_attendance_byorganisation(bunifuCustomDataGrid1, txt_search.Text);
            }
            else
            {
                MessageBox.Show("Veuillez choisir le type de recherche à effectuer!");
            }
        }
    }
}

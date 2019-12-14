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
using Attendance_App.Forms_Library;

namespace Attendance_App.UserControls
{
    public partial class uc_guests_search : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_guests_search()
        {
            InitializeComponent();
            refreshData();
        }
        private void refreshData()
        {
            rps.afficher_employees(bunifuCustomDataGrid1);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //rps.search_employee_byid(bunifuCustomDataGrid1, txt_search.Text);
            if (rdbtn_id.Checked == true)
            {
                rps.search_employee_byid(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_fonction.Checked == true)
            {
                rps.search_employee_byfonction(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_noms.Checked == true)
            {
                rps.search_employee_byname(bunifuCustomDataGrid1, txt_search.Text);                
            }
            else if (rdbtn_organisation.Checked == true)
            {
                rps.search_employee_byorganisation(bunifuCustomDataGrid1, txt_search.Text);
            }
            else
            {
                MessageBox.Show("Veuillez choisir le type de recherche à effectuer!");
            }
            //refreshData();
        }

        private void btn_ajouter_emp_Click(object sender, EventArgs e)
        {
            var fr = new frm_employees();
            fr.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_App.Data_Library;

namespace Attendance_App.Forms_Library
{
    public partial class frm_employees : Form
    {
        Data_Repository rps = new Data_Repository();
        public frm_employees()
        {
            InitializeComponent();
            refreshData();
        }
        public void refreshData()
        {
            rps.retrieve_combo_organization(cbx_organisation);
            rps.afficher_employees_full(bunifuCustomDataGrid1);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (rdbtn_id.Checked == true)
            {
                rps.search_employee_byid_full(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_fonction.Checked == true)
            {
                rps.search_employee_byfonction_full(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_noms.Checked == true)
            {
                rps.search_employee_byname_full(bunifuCustomDataGrid1, txt_search.Text);
            }
            else if (rdbtn_organisation.Checked == true)
            {
                rps.search_employee_byorganisation_full(bunifuCustomDataGrid1, txt_search.Text);
            }
            else
            {
                MessageBox.Show("Veuillez choisir le type de recherche à effectuer!");
            }
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if(txt_num_enreg.Text=="")
            {
                if(txt_adresse.Text==""||txt_contact.Text==""||txt_fonction.Text==""||txt_id_emp.Text==""||txt_name.Text==""||cbx_organisation.Text=="")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.enregistrer_employee(txt_id_emp.Text, txt_name.Text, txt_adresse.Text, txt_contact.Text, txt_fonction.Text, cbx_organisation.Text);
                }
            }
            else
            {
                if (txt_adresse.Text == "" || txt_contact.Text == "" || txt_fonction.Text == "" || txt_id_emp.Text == "" || txt_name.Text == "" || cbx_organisation.Text == "")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.modifier_employee(Convert.ToInt32(txt_num_enreg.Text),txt_id_emp.Text, txt_name.Text, txt_adresse.Text, txt_contact.Text, txt_fonction.Text, cbx_organisation.Text);
                }
            }
            refreshData();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text != "")
            {
                var rs = new DialogResult();
                rs = MessageBox.Show(this, "Voulez vous vraiment supprimer cette information?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(rs==DialogResult.Yes)
                {
                    rps.supprimer_employee(Convert.ToInt32(txt_num_enreg.Text));
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un élément de la grille à supprimer!");
            }
            refreshData();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_num_enreg.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id_emp.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            txt_name.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            txt_adresse.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            txt_contact.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            txt_fonction.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            cbx_organisation.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}

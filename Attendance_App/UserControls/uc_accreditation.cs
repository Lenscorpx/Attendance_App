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
    public partial class uc_accreditation : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_accreditation()
        {
            InitializeComponent();
            refreshData();
        }
        public void refreshData()
        {
            rps.afficher_accreditation(bunifuCustomDataGrid1);
            rps.retrieve_combo_level(cbx_level_access);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            rps.search_accreditation(bunifuCustomDataGrid1, txt_search.Text);
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text == "")
            {
                if (cbx_level_access.Text=="")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    //ajouter une accreditation de plus
                    rps.enregistrer_accreditation(txt_search.Text, cbx_level_access.Text, dtpick_expiration.Value, "Active");
                }
            }
            else
            {
                if (cbx_level_access.Text == "")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.modifier_accreditation(Convert.ToInt32(txt_num_enreg.Text), txt_search.Text, cbx_level_access.Text, dtpick_expiration.Value, "Active");
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
                if (rs == DialogResult.Yes)
                {
                    rps.supprimer_accreditation(Convert.ToInt32(txt_num_enreg.Text));
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
            //dtpick_expiration.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            txt_search.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            cbx_level_access.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            dtpick_expiration.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}

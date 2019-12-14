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
    public partial class uc_affectation : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_affectation()
        {
            InitializeComponent();
            refreshData();

        }
        public void refreshData()
        {
            rps.retrieve_combo_level(cbx_level_access);
            rps.retrieve_combo_zone(cbx_zone);
            rps.afficher_affectation_zone(bunifuCustomDataGrid1);
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text == "")
            {
                if (cbx_zone.Text == "" || cbx_level_access.Text == "")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    //ajouter une affectation de plus
                    rps.enregistrer_affectation_zone(cbx_level_access.Text, cbx_zone.Text,DateTime.Today);
                }
            }
            else
            {
                if (cbx_zone.Text == "" || cbx_level_access.Text == "")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.modifier_affectation_zonen(Convert.ToInt32(txt_num_enreg.Text), cbx_level_access.Text,cbx_zone.Text, DateTime.Today);
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
                    rps.supprimer_affectation_zone(Convert.ToInt32(txt_num_enreg.Text));
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
            cbx_level_access.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            cbx_zone.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (rdbtn_level_access.Checked == true)
                {
                    rps.search_affec_zone_by_id_level_access(bunifuCustomDataGrid1, txt_search.Text);
                }
            else if (rdbtn_zone.Checked == true)
                {
                    rps.search_affec_zone_by_id_zone(bunifuCustomDataGrid1, txt_search.Text);
                }
            else
                {
                    MessageBox.Show("Veuillez choisir le type de recherche à effectuer!");
                }
        }
    }
}

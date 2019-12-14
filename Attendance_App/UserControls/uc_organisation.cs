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
    public partial class uc_organisation : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_organisation()
        {
            InitializeComponent();
            refreshData();
        }
        public void refreshData()
        {
            rps.afficher_organisation(bunifuCustomDataGrid1);
            txt_nom_organisation.Clear();
            txt_id_organisation.Clear();
            txt_num_enreg.Clear();
            rtxt_description.Clear();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_num_enreg.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id_organisation.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            txt_nom_organisation.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            rtxt_description.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void txt_id_organisation_TextChanged(object sender, EventArgs e)
        {
            rps.search_organisation(bunifuCustomDataGrid1, txt_id_organisation.Text);
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text == "")
            {
                if (txt_id_organisation.Text == null || txt_nom_organisation.Text == null)
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.enregistrer_organisation(txt_id_organisation.Text, txt_nom_organisation.Text, rtxt_description.Text);
                }
            }
            else
            {
                if (txt_id_organisation.Text == "" || txt_nom_organisation.Text == "")
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.modifier_organisation(Convert.ToInt32(txt_num_enreg.Text), txt_id_organisation.Text, txt_nom_organisation.Text, rtxt_description.Text);
                }
            }
            refreshData();
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text != "")
            {
                var rs = new DialogResult();
                rs = MessageBox.Show(this, "Voulez vous vraiment supprimer cette information?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {
                    rps.supprimer_organisation(Convert.ToInt32(txt_num_enreg.Text));
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un élément de la grille à supprimer!");
            }
            refreshData();
        }
    }
}

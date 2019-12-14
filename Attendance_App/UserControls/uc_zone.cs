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
    public partial class uc_zone : UserControl
    {
        Data_Repository rps = new Data_Repository();
        public uc_zone()
        {
            InitializeComponent();
            refreshData();
        }
        public void refreshData()
        {
            rps.afficher_zone(bunifuCustomDataGrid1);
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_num_enreg.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id_zone.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            rtxt_description.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if (txt_num_enreg.Text == "")
            {
                if (txt_id_zone.Text == null || rtxt_description.Text == null)
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.enregistrer_zone(txt_id_zone.Text,rtxt_description.Text);
                }
            }
            else
            {
                if (txt_id_zone.Text == null || rtxt_description.Text == null)
                {
                    MessageBox.Show("Veuillez completer tous les champs informationnels avant de passer à l'enregistrement!");
                }
                else
                {
                    rps.modifier_zone(Convert.ToInt32(txt_num_enreg.Text), txt_id_zone.Text, rtxt_description.Text);
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
                    rps.supprimer_zone(Convert.ToInt32(txt_num_enreg.Text));
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un élément de la grille à supprimer!");
            }
            refreshData();
        }

        private void txt_id_zone_TextChanged(object sender, EventArgs e)
        {
            rps.search_zone(bunifuCustomDataGrid1, txt_id_zone.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_App.UserControls;

namespace Attendance_App.Forms_Library
{
    public partial class frm_dashboard : Form
    {
        public frm_dashboard()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            afficher_accueil();
        }
        private void afficher_accueil()
        {
            var fr = new uc_splash()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            //bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            //bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            var conf = new frm_confirmation();
            conf.ShowDialog();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            var fr = new uc_scanpage()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var fr = new uc_guests_search()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            var fr = new uc_attendance()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            var fr = new uc_affectation()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            var fr = new uc_accreditation()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var fr = new uc_zone()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            var fr = new uc_organisation()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var fr = new uc_access_level()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            var fr = new uc_barcode()
            {
                Size = panel4.Size
            };
            panel4.Controls.Clear();
            panel4.Controls.Add(fr);
            fr.Visible = false;
            bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            bunifuTransition1.ShowSync(fr);
            fr.Visible = true;
        }
    }
}

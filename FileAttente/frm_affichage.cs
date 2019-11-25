using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FileAttente
{
    public partial class frm_affichage : MetroForm
    {
        Data_Repository rps = new Data_Repository();
        public frm_affichage()
        {
            InitializeComponent();
            timer1.Start();
            demarrer_form();             
        }
        public void demarrer_form()
        {
            frm_assignation er = new frm_assignation();
            er.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rps.rechercher_liste_assignation(bunifuCustomDataGrid1);
        }
    }
}

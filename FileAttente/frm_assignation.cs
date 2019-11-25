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
    public partial class frm_assignation : MetroForm
    {
        Data_Repository rps = new Data_Repository();
        public frm_assignation()
        {
            InitializeComponent();
            refreshData();
        }        
        private void refreshData()
        {
            rps.afficher_assignation(bunifuCustomDataGrid1);
            rps.charger_guichet(cbx_id_entreprise);
            rps.charger_jetons_disponible(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_id_jeton.Text==""||cbx_id_entreprise.Text=="")
            {
                MessageBox.Show("Veuillez completer les cases vides");
            }
            else
            {
                rps.inserer_assignation(txt_id_jeton.Text, cbx_id_entreprise.Text);
                refreshData();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id_jeton.Text = Convert.ToString(listBox1.SelectedItem);
            }
            catch(Exception t)
            {

            }            
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            rps.supprimer_assignation(Convert.ToInt32(txt_num_assignation.Text));
            refreshData();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_num_assignation.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id_jeton.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            cbx_id_entreprise.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString());
        }
    }
}

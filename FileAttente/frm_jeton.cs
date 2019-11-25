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
    public partial class frm_jeton : MetroForm
    {

        Data_Repository rps = new Data_Repository();
        public frm_jeton()
        {
            InitializeComponent();
            refreshData();
        }


        private void refreshData()
        {
            rps.afficher_jeton(bunifuCustomDataGrid1);
            txt_id_jeton.Text = "";
            txt_description.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_description.Text=="" || txt_id_jeton.Text=="")
            {
                MessageBox.Show("Veuillez completer les cases vides");
            }
            else
            {
                rps.enregistrer_jeton(txt_id_jeton.Text, txt_description.Text);
                refreshData();
            }
            
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            if(txt_id_jeton.Text=="")
            {
                MessageBox.Show("Veuillez selectionner l'enregistrement à supprimer dans la liste des enregistrements");
            }
            else
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show(this, "Etes vous sûr de vouloir supprimer cet enregistrement?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(rs==DialogResult.Yes)
                {
                    rps.supprimer_jeton(txt_id_jeton.Text);
                    refreshData();
                }
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_id_jeton.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_description.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}

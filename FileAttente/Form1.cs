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
using System.Speech.Synthesis;

namespace FileAttente
{
    public partial class frm_guichet : MetroForm
    {
        
        SpeechSynthesizer parole = new SpeechSynthesizer();
        Data_Repository rps = new Data_Repository();
        string radiobutton_selected;
        public frm_guichet()
        {
            InitializeComponent();
            refreshData();
        }
        private void refreshData()
        {
            rps.afficher_guichet(bunifuCustomDataGrid1);
            txt_guichet.Text = "";
            txt_description.Text = "";
            //parole.SpeakAsync("Bonjour Maitre Justin! Je vous parle a partir de votre machine! je reponds au nom d'Aline Turot");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {         
            if(txt_guichet.Text==""||txt_description.Text=="")
            {
                MessageBox.Show("Veuillez completer les cases obligatoires!");
            }
            else
            {
                if (rdbtn_depot.Checked == true)
                {
                    //MessageBox.Show(txt_guichet.Text);
                    rps.enregistrer_guichet(txt_guichet.Text, txt_description.Text,"Depot");
                }
                else if (rdbtn_depot_retrait.Checked == true)
                {
                    rps.enregistrer_guichet(txt_guichet.Text, txt_description.Text, "Depot - Retrait");
                }
                else if (rdbtn_retrait.Checked == true)
                {
                    rps.enregistrer_guichet(txt_guichet.Text, txt_description.Text, "Retrait");
                }
                else
                {
                    MessageBox.Show("Veuillez choisir le type de guichet!");
                }
                refreshData();            
            }
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            if (txt_guichet.Text == "")
            {
                MessageBox.Show("Veuillez selectionner l'enregistrement à supprimer dans la liste des enregistrements");
            }
            else
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show(this, "Etes vous sûr de vouloir supprimer cet enregistrement?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    rps.supprimer_guichet(txt_guichet.Text);
                    refreshData();
                }
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_guichet.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
            txt_description.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            radiobutton_selected= bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            if(radiobutton_selected== "Depot")
            {
                rdbtn_depot.Checked = true;
            }
            else if(radiobutton_selected== "Depot - Retrait")
            {
                rdbtn_depot_retrait.Checked = true;
            }
            else if (radiobutton_selected == "Retrait")
            {
                rdbtn_retrait.Checked = true;
            }
        }
    }
}

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
    public partial class frm_appel : MetroForm
    {
        Data_Repository rps = new Data_Repository();
        SpeechSynthesizer parole = new SpeechSynthesizer();
        public frm_appel()
        {
            InitializeComponent();
            refreshData();
        }
        private void refreshData()
        {
            rps.appel_assignation(bunifuCustomDataGrid1);
            txt_guichet.Text = "";
            txt_jeton.Text = "";
            txt_numero.Text = "";
            
        }
        private void txt_guichet_Click(object sender, EventArgs e)
        {
            txt_numero.Text = "";
        }

        private void txt_guichet_MouseClick(object sender, MouseEventArgs e)
        {
            txt_numero.Text = "";
        }

        private void txt_guichet_DoubleClick(object sender, EventArgs e)
        {
            txt_numero.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txt_numero.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString();
                txt_jeton.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
                txt_guichet.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch
            {

            }
            
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            if(txt_guichet.Text==""||txt_jeton.Text==""||txt_numero.Text=="")
            {
                MessageBox.Show("Vous devez selectionner le client a appeler");
            }
            else
            {
                parole.SpeakAsync("Le numero " + txt_jeton.Text + " guichet " + txt_guichet.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_guichet.Text == "" || txt_jeton.Text == "" || txt_numero.Text == "")
            {
                MessageBox.Show("Vous devez selectionner le client a appeler");
            }
            else
            {
                rps.valider_assignation(Convert.ToInt32(txt_numero.Text));
            }            
            refreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_guichet.Text == "" || txt_jeton.Text == "" || txt_numero.Text == "")
            {
                MessageBox.Show("Vous devez selectionner le client a appeler");
            }
            else
            {
                rps.client_absent(Convert.ToInt32(txt_numero.Text));
            }
            refreshData();
        }
    }
}

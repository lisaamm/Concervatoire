﻿using CliLourdConservatoire.Controller;
using CliLourdConservatoire.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CliLourdConservatoire
{
    public partial class FormPaiements : Form
    {
        private List<Inscription> listeGetAll;
        private List<Inscription> listeGetAllAffichage;
        private Inscription selectedInscription;

        private Payer paieT1;
        private Payer paieT2;
        private Payer paieT3;

        private Trimestre trimestre1;
        private Trimestre trimestre2;
        private Trimestre trimestre3;

        /// <summary>
        /// constructeur du formulaire de paiements
        /// </summary>
        public FormPaiements()
        {
            InitializeComponent();
            //paramétrage de la taille de la fenêtre
            this.Size = new Size(900, 400);

            trimestre1 = TrimestreController.getByTrimestre("trimestre1");
            trimestre2 = TrimestreController.getByTrimestre("trimestre2");
            trimestre3 = TrimestreController.getByTrimestre("trimestre3");

            //récupérer toutes les inscriptions
            listeGetAll = InscriptionController.getAll();
            listeGetAllAffichage = InscriptionController.getAllAffichage();
            lbInscription.DataSource = listeGetAllAffichage;
            lbInscription.DisplayMember = "Afficher";

        }
        
        /// <summary>
        /// actions après la séléction d'une inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbInscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lbInscription.SelectedIndex;
                selectedInscription = listeGetAll[index];

                //récupération des paiements pour l'inscription séléctionnée
                paieT1 = PayerController.getByInscription_Trimestre(selectedInscription, "trimestre1");
                paieT2 = PayerController.getByInscription_Trimestre(selectedInscription, "trimestre2");
                paieT3 = PayerController.getByInscription_Trimestre(selectedInscription, "trimestre3");

                //vérifier qu'il y a 3 paiements par inscription
                if ((paieT1 == null) || (paieT2 == null) || (paieT3 == null)){
                    throw new Exception();
                }

                //affichage de l'état du paiement par trimestre
                if (paieT1.DatePaiement.Year != 0001)
                {
                    btnPayeT1.BackColor = Color.Green;
                    btnPayeT1.ForeColor = Color.DarkGreen;
                    btnPayeT1.Text = "payé";
                    lblDateT1.Text = paieT1.DatePaiement.ToString("dd/MM/yyyy");

                    btnValiderT1.Enabled = false;
                }
                else
                {
                    btnPayeT1.BackColor = Color.Red;
                    btnPayeT1.ForeColor = Color.DarkRed;
                    btnPayeT1.Text = "pas payé";
                    lblDateT1.Text = "";

                    btnValiderT1.Enabled = true;
                }

                if (paieT2.DatePaiement.Year != 0001)
                {
                    btnPayeT2.BackColor = Color.Green;
                    btnPayeT2.ForeColor = Color.DarkGreen;
                    btnPayeT2.Text = "payé";
                    lblDateT2.Text = paieT2.DatePaiement.ToString("dd/MM/yyyy");

                    btnValiderT2.Enabled = false;
                }
                else
                {
                    btnPayeT2.BackColor = Color.Red;
                    btnPayeT2.ForeColor = Color.DarkRed;
                    btnPayeT2.Text = "pas payé";
                    lblDateT2.Text = "";

                    btnValiderT2.Enabled = true;
                }

                if (paieT3.DatePaiement.Year != 0001)
                {
                    btnPayeT3.BackColor = Color.Green;
                    btnPayeT3.ForeColor = Color.DarkGreen;
                    btnPayeT3.Text = "payé";
                    lblDateT3.Text = paieT3.DatePaiement.ToString("dd/MM/yyyy");

                    btnValiderT3.Enabled = false;
                }
                else
                {
                    btnPayeT3.BackColor = Color.Red;
                    btnPayeT3.ForeColor = Color.DarkRed;
                    btnPayeT3.Text = "pas payé";
                    lblDateT3.Text = "";

                    btnValiderT3.Enabled = true;
                }
            }
            catch (Exception)
            {
                string message = "Erreur système. \nVeuillez réessayer ultérieurement.";
                string title = "Message d'erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);

                this.Close();
            }
        }

        /// <summary>
        /// pour le trimestre 1
        /// btn de validation du paiement du trimestre 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValiderT1_Click(object sender, EventArgs e)
        {
            bool res = Trimestre.compareDates(trimestre1.DateFin);

            if (res)
            {
                PayerController.updateDatePaiement(paieT1);
            }
            else
            {
                MessageBox.Show("Impossible de valider ce paiement. \nLa date butoire a été dépassée.", "Attention", MessageBoxButtons.OK);
            }

            int index = lbInscription.SelectedIndex;
            lbInscription.SetSelected(index, true);
        }

        /// <summary>
        /// pour le trimestre 2
        /// btn de validation du paiement du trimestre 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValiderT2_Click(object sender, EventArgs e)
        {
            bool res = Trimestre.compareDates(trimestre2.DateFin);

            if (res)
            {
                PayerController.updateDatePaiement(paieT2);
            }
            else
            {
                MessageBox.Show("Impossible de valider ce paiement. \nLa date butoire a été dépassée.", "Attention", MessageBoxButtons.OK);
            }

            int index = lbInscription.SelectedIndex;
            lbInscription.SetSelected(index, true);
        }

        /// <summary>
        /// pour le trimestre 3
        /// btn de validation du paiement du trimestre 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValiderT3_Click(object sender, EventArgs e)
        {
            bool res = Trimestre.compareDates(trimestre3.DateFin);

            if (res)
            {
                PayerController.updateDatePaiement(paieT3);
            }
            else
            {
                MessageBox.Show("Impossible de valider ce paiement. \nLa date butoire a été dépassée.", "Attention", MessageBoxButtons.OK);
            }

            int index = lbInscription.SelectedIndex;
            lbInscription.SetSelected(index, true);
        }

       
    }
}

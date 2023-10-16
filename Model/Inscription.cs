﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliLourdConservatoire.Model
{
    /// <summary>
    /// Classe Inscription
    /// </summary>
    public class Inscription
    {
        //Attributs privés
        private int idProf;
        private int idEleve;
        private string prof;
        private string eleve;
        private int numSeance;
        private DateTime dateInscription;

        /// <summary>
        /// Constructeur de la classe Inscription
        /// prenant les 2 premiers attributs comme 'string'
        /// </summary>
        /// <param name="idProf"></param>
        /// <param name="idEleve"></param>
        /// <param name="numSeance"></param>
        /// <param name="dateInscription"></param>
        public Inscription(int idProf, int idEleve, int numSeance, DateTime dateInscription)
        {
            this.idProf = idProf;
            this.idEleve = idEleve;
            this.numSeance = numSeance;
            this.dateInscription = dateInscription;
        }

        /// <summary>
        /// Constructeur de la classe Inscription
        /// prenant les 2 premiers attributs comme 'int'
        /// </summary>
        /// <param name="prof"></param>
        /// <param name="eleve"></param>
        /// <param name="numSeance"></param>
        /// <param name="dateInscription"></param>
        public Inscription(string prof, string eleve, int numSeance, DateTime dateInscription)
        {
            this.prof = prof;
            this.eleve = eleve;
            this.numSeance = numSeance;
            this.dateInscription = dateInscription;
        }

        //Propriétés publiques
        public int IdProf { get => idProf; set => idProf = value; }
        public int IdEleve { get => idEleve; set => idEleve = value; }
        public int NumSeance { get => numSeance; set => numSeance = value; }
        public DateTime DateInscription { get => dateInscription; set => dateInscription = value; }
        public string Prof { get => prof; set => prof = value; }
        public string Eleve { get => eleve; set => eleve = value; }

        //Propriété Affichant les attributs de la classe sous un format précis
        public string Afficher
        {
            get => this.Prof.PadRight(20 - this.Prof.Length)
                + "\t" + this.Eleve.PadRight(20 - this.Eleve.Length) + "\t"
                + Convert.ToString(this.NumSeance).PadRight(3 - Convert.ToString(this.NumSeance).Length) + "\t"
                + this.DateInscription.ToString("MM/dd/yyyy").PadRight(11 - this.DateInscription.ToString("MM/dd/yyyy").Length);
        }
    }
}

using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.controller;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace MediaTekDocuments.view

{
    /// <summary>
    /// Classe d'affichage
    /// </summary>
    private GroupBox grpNewCommand;
    private TextBox txtDateCommande, txtMontant, txtNombreExemplaires;
    private Button btnEnregistrerCommande;

    private void InitializeComponents()
    {
        // Configuration initiale du formulaire
        ...

    // Configuration du GroupBox pour la nouvelle commande
    grpNewCommand = new GroupBox
    {
        Text = "Nouvelle Commande",
        Location = new System.Drawing.Point(50, 380),
        Size = new System.Drawing.Size(700, 100)
    };
        this.Controls.Add(grpNewCommand);

        // TextBox pour la date de la commande
        txtDateCommande = new TextBox
        {
            Location = new System.Drawing.Point(10, 20),
            Width = 100
        };
        grpNewCommand.Controls.Add(txtDateCommande);

        // TextBox pour le montant
        txtMontant = new TextBox
        {
            Location = new System.Drawing.Point(120, 20),
            Width = 100
        };
        grpNewCommand.Controls.Add(txtMontant);

        // TextBox pour le nombre d'exemplaires
        txtNombreExemplaires = new TextBox
        {
            Location = new System.Drawing.Point(230, 20),
            Width = 100
        };
        grpNewCommand.Controls.Add(txtNombreExemplaires);

        // Button pour enregistrer la commande
        btnEnregistrerCommande = new Button
        {
            Text = "Enregistrer",
            Location = new System.Drawing.Point(340, 20),
            Width = 100
        };
        btnEnregistrerCommande.Click += BtnEnregistrerCommande_Click;
        grpNewCommand.Controls.Add(btnEnregistrerCommande);
    }

    private void BtnEnregistrerCommande_Click(object sender, EventArgs e)
    {
        DateTime dateCommande;
        if (!DateTime.TryParse(txtDateCommande.Text, out dateCommande))
        {
            MessageBox.Show("Date invalide.");
            return;
        }

        decimal montant;
        if (!decimal.TryParse(txtMontant.Text, out montant))
        {
            MessageBox.Show("Montant invalide.");
            return;
        }

        int nombreExemplaires;
        if (!int.TryParse(txtNombreExemplaires.Text, out nombreExemplaires))
        {
            MessageBox.Show("Nombre d'exemplaires invalide.");
            return;
        }

        string isbn= ;

        Commande nouvelleCommande = new Commande(
            id: 0, // Généré par la base de données normalement
            dateCommande: dateCommande,
            montant: montant,
            nombreExemplaires: nombreExemplaires,
            etapeSuivi: "en cours",
            isbn: isbn
        );

        // Enregistrer la nouvelle commande dans la base de données
        EnregistrerCommande(nouvelleCommande);
    }

    private void EnregistrerCommande(Commande commande)
    {
        // Ici, code pour enregistrer la commande dans la base de données
        MessageBox.Show("Commande enregistrée avec succès!");
    }
    private ComboBox cmbEtapeSuivi;
    private Button btnModifierEtape;
    private DataGridView dgvCommandes; //  DataGridView des commandes

    private void InitializeComponents()
    {
        // Configuration initiale du formulaire
        ...

    // ComboBox pour choisir la nouvelle étape de suivi
    cmbEtapeSuivi = new ComboBox
    {
        Location = new System.Drawing.Point(460, 20),
        Width = 120
    };
        cmbEtapeSuivi.Items.AddRange(new string[] { "en cours", "relancée", "livrée", "réglée" });
        grpNewCommand.Controls.Add(cmbEtapeSuivi);

        // Button pour modifier l'étape de suivi
        btnModifierEtape = new Button
        {
            Text = "Modifier Étape",
            Location = new System.Drawing.Point(590, 20),
            Width = 100
        };
        btnModifierEtape.Click += BtnModifierEtape_Click;
        grpNewCommand.Controls.Add(btnModifierEtape);
    }

    private void BtnModifierEtape_Click(object sender, EventArgs e)
    {
        if (dgvCommandes.CurrentRow == null)
        {
            MessageBox.Show("Veuillez sélectionner une commande.");
            return;
        }

        var selectedCommande = dgvCommandes.CurrentRow.DataBoundItem as Commande;
        string nouvelleEtape = cmbEtapeSuivi.SelectedItem.ToString();

        if (!EstChangementValide(selectedCommande.EtapeSuivi, nouvelleEtape))
        {
            MessageBox.Show("Changement d'étape invalide selon les règles définies.");
            return;
        }

        selectedCommande.EtapeSuivi = nouvelleEtape;
        // Mettre à jour la commande dans la base de données
        MettreAJourCommande(selectedCommande);
        MessageBox.Show("Étape de suivi mise à jour.");
    }

    private bool EstChangementValide(string etapeActuelle, string nouvelleEtape)
    {
        if ((etapeActuelle == "livrée" || etapeActuelle == "réglée") && (nouvelleEtape == "en cours" || nouvelleEtape == "relancée"))
            return false;
        if (etapeActuelle != "livrée" && nouvelleEtape == "réglée")
            return false;
        return true;
    }

    private void MettreAJourCommande(Commande commande)
    {
        // Chaîne de connexion à la base de données
        string connectionString = "votre_chaine_de_connexion_ici";

        // Requête SQL pour mettre à jour la commande
        string query = "UPDATE Commandes SET EtapeSuivi = @EtapeSuivi WHERE Id = @Id";

        // Créer une nouvelle connexion SQL
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Créer une commande SQL
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Paramètres SQL de la commande
                command.Parameters.AddWithValue("@EtapeSuivi", commande.EtapeSuivi);
                command.Parameters.AddWithValue("@Id", commande.Id);

                // Ouvrir la connexion
                connection.Open();

                // Exécuter la commande
                int result = command.ExecuteNonQuery();

                // Vérifier le résultat (optionnel)
                if (result < 1)
                    MessageBox.Show("Mise à jour non effectuée.");
                else
                    MessageBox.Show("Mise à jour réussie.");
            }
        }
    }

}

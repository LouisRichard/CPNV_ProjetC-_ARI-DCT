﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;


namespace MainMenu
{
    /// <summary>
    /// This is the form for the main menu
    /// </summary>
    public partial class FormMainMenu : Form
    {
        private string userEmail;
        private bool isLogged;
        public FormMainMenu()
        {
            InitializeComponent();
            this.Tag = isLogged;
        }
        
        /// <summary>
        /// If the user Click on the login button, the login form appears
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            using (FormLogin formLogin = new FormLogin())
            {
                formLogin.ShowDialog(this);
                this.isLogged=formLogin.IsLogged;
                if (isLogged)
                {
                    userEmail = formLogin.UserEmail;
                    lblMainMenuLogged.Text = $@"Connecté avec
{userEmail}";
                    btnLogin.Text = @"Jouer";
                    btnLogin.Click -= (btnLogin_Click);
                    btnLogin.Click += (btnLogin_Play);
                }
            }
        }
        /// <summary>
        /// If the player click on the Play button, the game starts
        /// </summary>
        private void btnLogin_Play(object sender, EventArgs e)
        {
            // Appeller le générateur du jeu
            // Générer les attributs du joueur (Position, inventaire etc)
            // Appeller les génerateurs d'évenements et item random
            // Appeller le form Gamescreen avec les paramètres pour l'affichage
            frmGame frmGame = new frmGame();
            frmGame.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Upgrade?
            if (Properties.Settings.Default.FormMainSize.Width == 0) Properties.Settings.Default.Upgrade();

            if (Properties.Settings.Default.FormMainSize.Width == 0 || Properties.Settings.Default.FormMainSize.Height == 0)
            {

            }
            else
            {
                this.WindowState = Properties.Settings.Default.FormMainState;
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.FormMainLoc;
                this.Size = Properties.Settings.Default.FormMainSize;
            }
        }

        private void MainMenu_Closing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormMainState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // Save location and size if the state is normal
                Properties.Settings.Default.FormMainLoc = this.Location;
                Properties.Settings.Default.FormMainSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.FormMainLoc = this.RestoreBounds.Location;
                Properties.Settings.Default.FormMainSize = this.RestoreBounds.Size;
            }

            // Save the settings
            Properties.Settings.Default.Save();
        }

        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        public bool IsLogged
        {
            get { return isLogged; }
            set { isLogged = value; }
        }
    }
}

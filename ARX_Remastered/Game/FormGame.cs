﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        private bool inGame;
        private bool inMenu;
        private bool inInventory;
        private bool inMenuCommands;
        private bool mapFound;
        private bool actionPossible;
        private bool actionEvent;

        public FormGame()
        {
            InitializeComponent();
            inGame = true;
            pbx_FormGameGame.Image = Image.FromFile("X.PNG");
        }

        private void FormGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                // W
                case (char)87:
                    if (inGame == true)
                    {
                        pbx_FormGameGame.Image = Image.FromFile("../Pics/X.jpg");
                        // Fait avancer le joueur
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers le haut
                    }
                    break;

                // Up arrow
                case (char)38:
                    if (inGame == true)
                    {
                        pbx_FormGameGame.Image = Image.FromFile("../Pics/I.jpg");
                        // Fait avancer le joueur
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers le haut
                    }
                    break;

                // A  
                case (char)65:
                    if (inGame == true)
                    {
                        // Fait tourner le joueur vers la gauche
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers la gauche
                    }
                    break;

                // Left arrow
                case (char)37:
                    if (inGame == true)
                    {
                        // Fait tourner le joueur vers la gauche
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers la gauche
                    }
                    break;

                // S
                case (char)83:
                    if (inGame == true)
                    {
                        // Déplace le joueur vers l'arrière
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers le bas
                    }
                    break;

                // Down arrow
                case (char)40:
                    if (inGame == true)
                    {
                        // Déplace le joueur vers l'arrière
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers le bas
                    }
                    break;

                // D
                case (char)68:
                    if (inGame == true)
                    {
                        // Fait tourner le joueur vers la droite
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers la droite
                    }
                    break;

                // Right arrow
                case (char)39:
                    if (inGame == true)
                    {
                        // Fait tourner le joueur vers la droite
                    }
                    if (inInventory == true)
                    {
                        // déplace la selection de l'inventaire vers la droite
                    }
                    break;

                // M
                case (char)77:
                    if (inGame == true)
                    {
                        if (mapFound == true)
                        {
                            // Fait un zoom sur la map
                        }
                    }
                    break;

                // +
                case (char)107:
                    if (inGame == true)
                    {
                        if (mapFound == true)
                        {
                            // Fait un zoom sur la map
                        }
                    }
                    break;

                // N
                case (char)78:
                    if (inGame == true)
                    {
                        if (mapFound == true)
                        {
                            // Fait un dezoom sur la map
                        }
                    }
                    break;

                // -  
                case (char)109:
                    if (inGame == true)
                    {
                        if (mapFound == true)
                        {
                            // Fait un dezoom sur la map
                        }
                    }
                    break;

                // E
                case (char)69:
                    if (actionEvent == true)
                    { 
                        if (actionPossible == true)
                        {
                            // Effectue une action sur l'événement si l'objet séléctionné correspond
                        }
                        if (actionPossible == false)
                        {
                            // Affcihe un message "Je ne peux pas utiliser cela bla bla bla
                        }
                    }
                    break;

                // I
                case (char)73:
                    if (inGame == true)
                    {
                        inInventory = true;
                        inGame = false;
                        // Ouvre l'inventaire
                    }
                    if (inInventory == true)
                    {
                        inInventory = false;
                        inGame = true;
                        // Ferme l'inventaire et revient au jeu
                    }
                    break;

                // Esc  
                case (char)27:
                    if (inGame == true)
                    {
                        inGame = false;
                        inMenu = true;
                        // Ouvre le menu
                    }
                    if (inInventory == true)
                    {
                        inInventory = false;
                        inGame = true;
                        // Ferme l'inventaire et revient au jeu
                    }
                    if (inMenu == true)
                    {
                        inMenu = false;
                        inGame = true;
                        // Ferme le menu et revient au jeu
                    }
                    if (inMenuCommands == true)
                    {
                        inMenuCommands = false;
                        inMenu = true;
                        // Ferme le menu de commande et revient au menu
                    }
                    break;

                // Counts all other keys.
                default:
                    
                    break;
            }
        }
    }
}

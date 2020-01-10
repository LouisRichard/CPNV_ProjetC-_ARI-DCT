﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.CodeDom;
using System.Data;
using Microsoft.CSharp;
using GameLib;

namespace Game
{
    public partial class FormGame : Form
    {
        private bool actionEvent;
        private bool actionPossible;
        private bool backToGame;
        private bool inGame;
        private bool inFirstMenu;
        private bool backToFirstMenu = true;
        private bool inInventory;
        private bool inMenu;
        private bool disableFirstMenu;
        private bool inMenuCommands;
        private bool mapFound;
        private bool isSelected;
        private Color testPixel;
        private Color selectedPixelColor;
        private static readonly Image notSelectedImage = Properties.Resources.NotSelected;
        private static readonly Image selectedImage = Properties.Resources.Selected;
        private string key;
        private string slot;
        private string objectiv;


        public FormGame(string lblUsername)
        {
            GameLib.Game game = new GameLib.Game();
            InitializeComponent();
            inFirstMenu = true;
            selectedPixelColor = Properties.Resources.Selected.GetPixel(50, 50);
            lblGameUserLogged.Text = @"Logged as : " + lblUsername;
            pbx_FormGameMap.Image = Properties.Resources.Map;

            //TEMP
            objectiv = "TEMP Trouvez la sortie ";
            lblPrimaryObjectiv.Text = @"Objectif Principal : " + objectiv;

            Refresh();
            
            InitializePbx();
            CheckActivePbx();

            pbxFormGameGame.Load("Pics/FirstMenu.PNG");
            }

        private void FormGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                /// W
                case (char) 119:
                    if (inGame)
                    {
                        
                    }

                        //TEMP
                        pbxFormGameGame.Load("Pics/X.PNG");

                    ///TODO Move the player - forward

                    if (inInventory)
                    {
                        key = "W";
                        InventoryManagement inventoryMovement = new InventoryManagement(key, slot, pbxFormgameInventory1, pbxFormgameInventory2, pbxFormgameInventory3, pbxFormgameInventory4, pbxFormgameInventory5, pbxFormgameInventory6, pbxFormgameInventory7,pbxFormgameInventory8,pbxFormgameInventory9, pbxFormgameInventory10);
                        CheckActivePbx();
                    }
                    break;

                /// A  
                case (char) 97:
                    if (inGame)

                        //TEMP
                        pbxFormGameGame.Load("Pics/I.PNG");

                    /// TODO Move the player - Left

                    if (inInventory)
                    {
                        key = "A";
                        InventoryManagement inventoryMovement = new InventoryManagement(key, slot, pbxFormgameInventory1, pbxFormgameInventory2, pbxFormgameInventory3, pbxFormgameInventory4, pbxFormgameInventory5, pbxFormgameInventory6, pbxFormgameInventory7, pbxFormgameInventory8, pbxFormgameInventory9, pbxFormgameInventory10);
                        CheckActivePbx();
                    }

                    break;

                /// S
                case (char) 115:
                    if (inGame)
                    {

                       

                    }

                    if (inInventory)
                    {
                        key = "S";
                        InventoryManagement inventoryMovement = new InventoryManagement(key, slot, pbxFormgameInventory1, pbxFormgameInventory2, pbxFormgameInventory3, pbxFormgameInventory4, pbxFormgameInventory5, pbxFormgameInventory6, pbxFormgameInventory7, pbxFormgameInventory8, pbxFormgameInventory9, pbxFormgameInventory10);
                        CheckActivePbx();
                    }

                    break;

                /// D
                case (char) 100:
                    if (inGame)
                    {


                    }

                    if (inInventory)
                    {
                        key = "D";
                        InventoryManagement inventoryMovement = new InventoryManagement(key, slot, pbxFormgameInventory1, pbxFormgameInventory2, pbxFormgameInventory3, pbxFormgameInventory4, pbxFormgameInventory5, pbxFormgameInventory6, pbxFormgameInventory7, pbxFormgameInventory8, pbxFormgameInventory9, pbxFormgameInventory10);
                        CheckActivePbx();
                    }

                    break;

                /// M
                case (char) 109:
                    if (inGame)
                        if (mapFound)
                        {

                            /// TODO Zoom on the map

                        }

                    break;
                
                /// N
                case (char) 110:
                    if (inGame)
                        if (mapFound)
                        {

                            /// TODO Unzoom on the map

                        }

                    break;

                /// E
                case (char) 101:
                    if (actionEvent)
                    {
                        if (actionPossible)
                        {

                            /// TODO Check if the player as requirement (object or event) to interract

                        }

                        if (actionPossible == false)
                        {

                            /// TODO Display a message "You can't do this bla bla bla"

                        }
                    }

                    break;

                /// I
                case (char) 105:
                    if (inGame)
                    {
                        inInventory = true;
                        inGame = false;
                    }
                    break;

                /// C  
                case (char) 99:
                    if (inMenu)
                    {
                        pbxFormGameGame.Load("Pics/Menucmd.PNG");
                        inMenu = false;
                        inMenuCommands = true;
                    }

                    if (inFirstMenu)
                    {
                        pbxFormGameGame.Load("Pics/Menucmd.PNG");
                        inFirstMenu = false;
                        backToFirstMenu = true;
                        inMenuCommands = true;
                    }

                    break;

                /// Q
                case (char) 113:
                    if (inMenu) Close();
                    if (inFirstMenu) Close();
                    break;

                /// Esc  
                case (char) 27:
                    if (inInventory)
                    {
                        inInventory = false;
                        inGame = true;
                    }
                    
                    if (inMenu)
                    {

                        //TODO pbx_FormGameGame.Load("Même image que en metant menu");

                        pbxFormGameGame.Load("Pics/X.PNG");
                        inMenu = false;
                        backToGame = true;

                    }

                    if (inGame)
                    {
                        pbxFormGameGame.Load("Pics/Menu.PNG");
                        inGame = false;
                        inMenu = true;
                    }
                    
                    if (inFirstMenu)
                    {
                        // TODO pbx_FormGameGame.Load("spawn");

                        pbxFormGameGame.Load("Pics/X.PNG");
                        inFirstMenu = false;
                        backToFirstMenu = false;
                        inGame = true;
                    }

                    if (inMenuCommands)
                    {
                        if (backToFirstMenu)
                        {
                            pbxFormGameGame.Load("Pics/FirstMenu.PNG");
                            inMenuCommands = false;
                            inFirstMenu = true;
                        }

                        if (backToFirstMenu == false)
                        {
                            pbxFormGameGame.Load("Pics/Menu.PNG");
                            inMenuCommands = false;
                            inMenu = true;
                        }
                    }



                    if (backToGame)
                    {
                        inGame = true;
                        backToGame = false;
                    }
                    break;
            }

        }
        
        public PictureBox[] InitializePbx()
        {
            /// Initialize picturebox -> foreach
            PictureBox[] matches = new PictureBox[]
            {
                pbxFormgameInventory1,
                pbxFormgameInventory2,
                pbxFormgameInventory3,
                pbxFormgameInventory4,
                pbxFormgameInventory5,
                pbxFormgameInventory6,
                pbxFormgameInventory7,
                pbxFormgameInventory8,
                pbxFormgameInventory9,
                pbxFormgameInventory10,
            };
            return matches;
        }
        
        public string CheckActivePbx()
        {
            ///Fuction to know wich slot is active
            foreach (PictureBox match in InitializePbx())
            {
                Bitmap testPixel = new Bitmap(match.BackgroundImage);
                this.testPixel = testPixel.GetPixel(50, 50);

                if (this.testPixel == selectedPixelColor)
                {
                    Console.WriteLine(match.Name);
                    slot = match.Name;
                }
            }
            return slot;
        }

    }
}
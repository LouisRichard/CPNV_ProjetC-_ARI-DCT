﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DBConnectionLib;
using MySql.Data.MySqlClient;

namespace MainMenuLib
{
    /// <summary>
    /// This class contain all method for login
    /// </summary>
    public class Login
    {
        private string username;
        private string password;
        /// <summary>
        /// This is the constructor for the Login Object
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;

        }
        /// <summary>
        /// Check if the username and the password of the user is correct
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True if OK</returns>
        /// <returns>Exception if not OK</returns>
        public bool LoginDB(Login login)
        {
            string ID;
            DBConnection connection = new DBConnection();
            connection.OpenConnection();
            ID = connection.GetUserIDFromUsername(login.username);
            if (!connection.CheckUsername(username))
            {
                throw new UnknownUsernameException();
            }
            if (!connection.CheckPassword(ID, password))
            {
                throw new InvalidPasswordException();
            }

            return true;
        }
    } 
}

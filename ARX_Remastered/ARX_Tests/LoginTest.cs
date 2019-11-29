﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionLib;
using MainMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainMenuLib;
using InvalidPasswordException = DBConnectionLib.InvalidPasswordException;


namespace ARX_Tests
{
    [TestClass]
    public class LoginTest
    {
        /// <summary>
        /// Test if the login work with an existing user
        /// First the user is created
        /// then the login is tested, with method from MainMenulLib\login.cs
        /// </summary>
        [TestMethod]
        public void TestLoginExistingUser()
        {
            string userEmail = "test.Test@test.test";
            string username = "Test";
            string password = "12345678";
            Register reg = new Register(userEmail, username, password);
            reg.RegisterInDB(reg);

            Login l = new Login(userEmail, password);
            Assert.IsTrue(l.LoginDB(l));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyFieldException))]
        public void TestLoginEmptyField()
        {
            string userEmail = "";
            string password = "";
            Login login = new Login(userEmail,password);
            login.LoginDB(login);
        }

        



    }
}

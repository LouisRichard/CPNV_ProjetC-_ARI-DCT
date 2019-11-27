﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainMenuLib;
using MainMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ARX_Tests
{
    class MenuTest
    {
        [TestClass]
        public class LoginFormTest
        {
            /// <summary>
            /// Test if the login form
            /// First, mail and password are initialised
            /// Then, Test if mail or/and password are empty or not
            /// Next, test if mail and password are longer than 8 characters
            /// then the login is tested, with method from MainMenu\CheckData.cs
            /// </summary>
            [TestMethod]
            public void TestLoginFormBothEmpty()
            {
                
                string mail = "";
                string password = "";
                string passwordCheck = "";
                CheckData logincheck = new CheckData(mail, password, passwordCheck);
                Assert.IsTrue(mail == "" && password == "");
            }
            [TestMethod]
            public void TestLoginFormMailEmpty()
            {

                string mail = "";
                string password = "12345678";
                string passwordCheck = "";
                CheckData logincheck = new CheckData(mail, password, passwordCheck);
                Assert.IsTrue(mail == "");
            }
            [TestMethod]
            public void TestLoginFormPasswordEmpty()
            {
 
                string mail = "Gerardine";
                string password = "";
                string passwordCheck = "";
                CheckData logincheck = new CheckData(mail, password, passwordCheck);
                Assert.IsTrue(password == "" && mail == "Gerardine");
            }
            [TestMethod]
            public void TestLoginFormUsernameTooshort()
            {
   
                string mail = "Gerard";
                string password = "12345678";
                string passwordCheck = "";
                CheckData logincheck = new CheckData(mail, password, passwordCheck);
                Assert.IsTrue(mail.Length < 8);
            }
            [TestMethod]
            public void TestLoginFormPasswordTooshort()
            {

                string mail = "Gerardine";
                string password = "1234";
                string passwordCheck = "";
                CheckData logincheck = new CheckData(mail, password, passwordCheck);
                Assert.IsTrue(password.Length < 8);
            }
        }
    }
}

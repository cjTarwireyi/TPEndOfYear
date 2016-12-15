using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BusineesLogic.factories;
using System.Collections.Generic;
using BusineesLogic.domain;

namespace UnitTests.factories
{
    [TestClass]
    public class TestEmail
    {
        [TestMethod]
        public void testCreateEmail()
        {
            List<string> emailDetails = new List<string>();
            emailDetails.Add("cj@gmail.com");
            emailDetails.Add("Cj");
            emailDetails.Add("Hey");
            EmailDTO email = EmailFactory.createEmail(emailDetails);

            Assert.AreEqual(email.emailAddress, "cj@gmail.com");
        }

        [TestMethod]
        public void testUpdateEmail()
        {
            List<string> emailDetails = new List<string>();
            emailDetails.Add("cj@gmail.com");
            emailDetails.Add("Cj");
            emailDetails.Add("Hey");
            EmailDTO email = EmailFactory.createEmail(emailDetails);

            EmailDTO updateEmail = new EmailDTO.EmailBuilder()
                                       .copy(email)
                                       .buildEmailAddress("sw@gmail.com")
                                       .build();
            Assert.AreNotEqual(email.emailAddress,updateEmail.emailAddress);
                                   
                                

            
        }
    }
}

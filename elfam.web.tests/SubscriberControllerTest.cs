using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using elfam.web.Controllers;
using elfam.web.Models;
using elfam.web.Services;
using NUnit.Framework;

namespace elfam.web.tests
{
    [TestFixture]
    class SubscriberControllerTest
    {
        [Test]
        public void TestUnsubscribe()
        {
            const string email = "kpdpok@gmail.com";
            var token = SubscriberService.CalculateToken(email);
            Assert.IsTrue(SubscriberService.VerifyToken(email, token));
        }
    }
}

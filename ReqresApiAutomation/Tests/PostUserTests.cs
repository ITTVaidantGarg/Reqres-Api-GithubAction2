using NUnit.Framework;
using System.Net;
using ReqresApiAutomation.Base;
using ReqresApiAutomation.Models;
using Allure.NUnit.Attributes;

namespace ReqresApiAutomation.Tests
{
    // Simple create check -> Smoke suite
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("SmokeSuite")]
    [AllureSuite("User Management")]
    [AllureFeature("Create User")]
    public class PostUserTests : TestBase
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureDescription("Verify that creating a user returns 201 Created status with user details in response")]
        [AllureTag("smoke", "post", "api", "create")]
        public void CreateUser_ShouldReturn201()
        {
            var body = new CreateUserBody
            {
                name = "Vaidant",
                job = "QA Engineer"
            };

            var response = client.PostUser(body);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Content, Does.Contain("Vaidant"));
            Assert.That(response.Content, Does.Contain("QA Engineer"));
        }
    }
}

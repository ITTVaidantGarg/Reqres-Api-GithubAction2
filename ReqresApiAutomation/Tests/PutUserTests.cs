using NUnit.Framework;
using System.Net;
using ReqresApiAutomation.Base;
using Allure.NUnit.Attributes;

namespace ReqresApiAutomation.Tests
{
    // Update scenario -> Regression suite
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("RegressionSuite")]
    [AllureSuite("User Management")]
    [AllureFeature("Update User")]
    public class PutUserTests : TestBase
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        [AllureDescription("Verify that updating a user with PUT method returns 200 OK with updated details")]
        [AllureTag("regression", "put", "api", "update")]
        public void UpdateUser_ShouldReturn200()
        {
            var body = new { name = "Vaidant Garg", job = "Senior QA" };
            var response = client.UpdateUser(2, body);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("Senior QA"));
        }
    }
}
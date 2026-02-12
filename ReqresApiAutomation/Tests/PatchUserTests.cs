
using NUnit.Framework;
using System.Net;
using ReqresApiAutomation.Base;
using Allure.NUnit.Attributes;

namespace ReqresApiAutomation.Tests
{
    // Partial update scenario -> Regression suite
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("RegressionSuite")]
    [AllureSuite("User Management")]
    [AllureFeature("Patch User")]
    public class PatchUserTests : TestBase
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        [AllureDescription("Verify that partially updating a user with PATCH method returns 200 OK")]
        [AllureTag("regression", "patch", "api", "update")]
        public void PatchUser_ShouldReturn200()
        {
            var body = new { job = "Lead QA" };
            var response = client.PatchUser(2, body);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("Lead QA"));
        }
    }
}
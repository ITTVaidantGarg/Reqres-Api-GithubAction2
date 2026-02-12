using NUnit.Framework;
using System.Net;
using ReqresApiAutomation.Base;
using Allure.NUnit.Attributes;

namespace ReqresApiAutomation.Tests
{
    // Destructive delete scenario -> Regression suite
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("RegressionSuite")]
    [AllureSuite("User Management")]
    [AllureFeature("Delete User")]
    public class DeleteUserTests : TestBase
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureDescription("Verify that deleting a user returns 204 No Content status")]
        [AllureTag("regression", "delete", "api", "destructive")]
        public void DeleteUser_ShouldReturn204()
        {
            var response = client.DeleteUser(2);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent),
                    "The API should return status 204 (No Content).");

                Assert.That(string.IsNullOrEmpty(response.Content), Is.True,
                    "The response body should be empty for a 204 status.");
            });
        }
    }
}
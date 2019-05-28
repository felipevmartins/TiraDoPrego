using NUnit.Framework;
using TiraDoPrego.Api.Infra;

namespace Tests
{
    public class PasswordEncryptTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyPasswordSuccess()
        {
            string passIn = "123456";
            string passExpected = "E33IVs5ZtnUC4PdXM+lGvGQdI915nG3kch4xPLmL4PM=";
            bool passVerify = PasswordEncrypt.VerifyPassword(passExpected, passIn);
            Assert.IsTrue(passVerify);
        }


        [Test]
        public void VerifyPasswordFail()
        {
            string passIn = "345345";
            string passExpected = "E33IVs5ZtnUC4PdXM+lGvGQdI915nG3kch4xPLmL4PM=";
            bool passVerify = PasswordEncrypt.VerifyPassword(passExpected, passIn);
            Assert.IsFalse(passVerify);
        }
    }
}
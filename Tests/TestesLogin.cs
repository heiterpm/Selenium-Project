using SwagLabs.Common;
using SwagLabs.Pages;

namespace SwagLabs.Tests
{
    public class TestesLogin : DefaultConfs
    {
        private LoginPage _login;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Navegador);
        }



        [Test]
        [Category("Teste")]
        public void ShouldSeeMainArea()
        {
            _login.With("standard_user","secret_sauce");
            Assert.AreEqual("PRODUCTS",PageName());
        }


        [TestCase ("","321","Epic sadface: Username is required")]
        [TestCase ("123","","Epic sadface: Password is required")]
        [TestCase ("123","123","Epic sadface: Username and password do not match any user in this service")]
        [TestCase ("locked_out_user","secret_sauce","Epic sadface: Sorry, this user has been locked out.")]
        public void DDT(string email, string senha, string expectedMessage)
        {
            _login.With(email,senha);
            Assert.AreEqual(expectedMessage, ErrorMessage());
        }

    }
}
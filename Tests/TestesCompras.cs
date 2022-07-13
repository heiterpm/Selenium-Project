using SwagLabs.Common;
using SwagLabs.Pages;

namespace SwagLabs.Tests
{
    public class TestesCompras : DefaultConfs
    {
        private LoginPage _login;
        private ComprasPage _compra;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Navegador);
            _compra = new ComprasPage(Navegador);
            _login.With("standard_user","secret_sauce");
        }

        [Test]
        public void ShouldSelectProducts()
        {
            _compra.ShouldSelectAllProducts();
            _compra.ShouldRemoveProducts();
            _compra.ShouldRemoveCartProducts();
        }


        [TestCase ("","X","X","Error: First Name is required")]
        [TestCase ("X","","X","Error: Last Name is required")]
        [TestCase ("X","X","","Error: Postal Code is required")]
        public void DDT(string email, string senha, string CEP, string expectedMessage)
        {
            _compra.FormFill(email,senha, CEP);
            Assert.AreEqual(expectedMessage, ErrorMessage());
        }

        [Test]
        public void ShouldContinueBuy()
        {
            _compra.FormFill("Nome","Sobrenome", "1551515");
            Navegador.ClickButton("finish");
            Assert.AreEqual("CHECKOUT: COMPLETE!",PageName());
        }
    }
}
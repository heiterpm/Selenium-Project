using Coypu;

namespace SwagLabs.Pages
{
    public class ComprasPage
    {
        private readonly BrowserSession _navegador;

            public ComprasPage(BrowserSession navegador)
            {
                _navegador = navegador;
            }

            public void ShouldSelectAllProducts()
            {
                _navegador.ClickButton("add-to-cart-sauce-labs-backpack");
                _navegador.ClickButton("add-to-cart-sauce-labs-bike-light");
                _navegador.ClickButton("add-to-cart-sauce-labs-bolt-t-shirt");
                _navegador.ClickButton("add-to-cart-sauce-labs-fleece-jacket");
                _navegador.ClickButton("add-to-cart-sauce-labs-onesie");
                _navegador.ClickButton("add-to-cart-test.allthethings()-t-shirt-(red)");
            }

            public void ShouldRemoveProducts()
            {
                _navegador.ClickButton("remove-sauce-labs-onesie");
                _navegador.ClickButton("remove-test.allthethings()-t-shirt-(red)");
                _navegador.FindCss(".shopping_cart_link").Click();
            }

            public void ShouldRemoveCartProducts()
            {
                _navegador.ClickButton("remove-sauce-labs-bolt-t-shirt");
                _navegador.ClickButton("remove-sauce-labs-fleece-jacket");
                _navegador.ClickButton("checkout");
            }

            public void FormFill(string name, string lastName, string CEP)
            {
                this.ShouldSelectAllProducts();
                this.ShouldRemoveProducts();
                this.ShouldRemoveCartProducts();

                _navegador.FillIn("first-name").With(name);
                _navegador.FillIn("last-name").With(lastName);
                _navegador.FillIn("postal-code").With(CEP);
                _navegador.ClickButton("continue");
            }
    }
}
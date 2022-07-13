using Coypu;

namespace SwagLabs.Pages
{
    public class LoginPage
    {
        private readonly BrowserSession _navegador;

            public LoginPage(BrowserSession navegador)
            {
                _navegador = navegador;
            }

            public void Load()
            {
                _navegador.Visit("/");
            }

            public void With(string email, string senha)
            {
                this.Load();
                _navegador.FillIn("user-name").With(email);
                _navegador.FillIn("password").With(senha);
                _navegador.ClickButton("login-button");
            }
    }
}
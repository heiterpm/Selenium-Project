using Coypu;
using Coypu.Drivers.Selenium;

namespace SwagLabs.Common
{
    public class DefaultConfs
    {
        protected BrowserSession Navegador;

        [SetUp]
        public void Setup()
        {
            SessionConfiguration configs = new SessionConfiguration
            {
                AppHost = "saucedemo.com",
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)
            };

            Navegador = new BrowserSession(configs);

            Navegador.MaximiseWindow();
        }

        public string ErrorMessage()
        {
            return Navegador.FindCss(".error-message-container h3").Text;
        }

        public string PageName()
        {
            return Navegador.FindCss(".title").Text;
        }

        public void TakeScreenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID;
            var shotPath = Environment.CurrentDirectory + "\\Screenshots\\";

            if (!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = $"{shotPath}\\{resultId}.png";
            
            Navegador.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);
        }


        [TearDown]
        public void Finish()
        {
            try
            {
                TakeScreenshot();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao capturar screenshot");
            }

            Navegador.Dispose();
        }
    }
}
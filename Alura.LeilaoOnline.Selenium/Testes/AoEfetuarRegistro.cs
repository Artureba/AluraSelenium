using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
                //arrange - dado (chrome ou edge) aberto, página inicial do sistema de leilões,
                //dados de registro válidos informados
                //driver.Navigate().GoToUrl("http://localhost:5000/");

            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

                //Nome
                //var inputNome = driver.FindElement(By.Id("Nome"));

                //email
                //var inputEmail = driver.FindElement(By.Id("Email"));

                //password
                //var inputSenha = driver.FindElement(By.Id("Password"));

                //confirmpassword
                //var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

                //botão de registro
                //var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            registroPO.PreencheFormulario("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "123");

                //inputNome.SendKeys("Arthur Henrique");
                //inputEmail.SendKeys("calabreso@feto.com.br");
                //inputSenha.SendKeys("123");
                //inputConfirmSenha.SendKeys("123");

                //act - quando eu efetuo o registro
                //botaoRegistro.Click();

            //act
            registroPO.SubmeteFormulario();

            //assert - devo ser redirecionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Daniel Portugal", "daniel", "123", "123")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInfoinvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmSenha);

            //act
            registroPO.SubmeteFormulario();

            //assert - devo ser redirecionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

                //assert - span.msg-erro[data-valmsg-for-Nome]
                //IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
                //Assert.Equal("The Nome field is required.", elemento.Text);

            //assert - 
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "mussarelo",
                senha: "",
                confirmSenha: ""
             );

            //act
            registroPO.SubmeteFormulario();

            //assert - span.msg-erro[data-valmsg-for-Nome]
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}

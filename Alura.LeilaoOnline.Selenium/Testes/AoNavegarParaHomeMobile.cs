using OpenQA.Selenium.Edge;
using System;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chromium;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private EdgeDriver driver;

        public AoNavegarParaHomeMobile()
        {
            
        }

        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //arrange
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new EdgeOptions();
            options.EnableMobileEmulation(deviceSettings);

            driver = new EdgeDriver(options);
            //driver = new EdgeDriver(TestHelper.PastaDoExecutavel, options);

            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //arrange
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new EdgeOptions();
            options.EnableMobileEmulation(deviceSettings);

            driver = new EdgeDriver(options);
            //driver = new EdgeDriver(TestHelper.PastaDoExecutavel, options);

            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //assert
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

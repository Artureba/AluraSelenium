﻿using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAual()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1); //em andamento

            //act
            detalhePO.OfertarLance(300);

            //assert

                //Thread.Sleep(4000);
                //Assert.Equal(300, detalhePO.LanceAtual);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until( drv => detalhePO.LanceAtual == 300 );
            Assert.True(iguais);
        }
    }
}

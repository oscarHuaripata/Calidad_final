using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAppWeb.Tests.TEST.Selenium
{
    [TestFixture]
    public class TestSelenium
    {
        string RutaGlobal = "https://localhost:44348/";
        ChromeOptions opciones = new ChromeOptions();
        [Test]
        public void btnAddCuentaIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddCuenta").Click();

            var pageId = navegador.FindElementById("ViewAddCuenta");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void validacionesAddCuentaIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddCuenta").Click();


            navegador.FindElementById("btnAddCuenta").Click();

            var pageId = navegador.FindElementById("ViewAddCuenta");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void AddCuentaPropiaIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddCuenta").Click();
            navegador.FindElementById("Nombre").SendKeys("TestPropia");
            navegador.FindElementByName("Categoria").Click();
            navegador.FindElementByName("propio").Click();
            navegador.FindElementById("SaldoInicial").SendKeys("1000");

            navegador.FindElementById("btnAddCuenta").Click();

            var pageId = navegador.FindElementById("ViewIndex");
            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void AddCuentaCreditoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddCuenta").Click();
            navegador.FindElementById("Nombre").SendKeys("TestCredito");
            navegador.FindElementByName("Categoria").Click();
            navegador.FindElementByName("credito").Click();
            navegador.FindElementById("SaldoInicial").SendKeys("1000");

            navegador.FindElementById("btnAddCuenta").Click();

            var pageId = navegador.FindElementById("ViewIndex");
            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void btnAddIngresoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddIngreso").Click();

            var pageId = navegador.FindElementById("ViewAddIngreso");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void validacionesAddIngresoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddIngreso").Click();


            navegador.FindElementById("btnAddIngreso").Click();

            var pageId = navegador.FindElementById("ViewAddIngreso");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void AddIngresoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddIngreso").Click();

            navegador.FindElementByName("Cuenta").Click();
            navegador.FindElementById("prueba").Click();

            navegador.FindElementById("Descripcion").SendKeys("TestIngreso");
            navegador.FindElementById("Monto").SendKeys("100");

            navegador.FindElementById("btnAddIngreso").Click();

            var pageId = navegador.FindElementById("ViewIndex");
            Assert.IsNotNull(pageId);

            navegador.Close();
        }

        [Test]
        public void btnAddGastoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddGasto").Click();

            var pageId = navegador.FindElementById("ViewAddGasto");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void validacionesAddGastoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddGasto").Click();


            navegador.FindElementById("btnAddGasto").Click();

            var pageId = navegador.FindElementById("ViewAddGasto");


            Assert.IsNotNull(pageId);

            navegador.Close();
        }
        [Test]
        public void AddGastoIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("btnAddGasto").Click();

            navegador.FindElementByName("Cuenta").Click();
            navegador.FindElementById("prueba").Click();

            navegador.FindElementById("Descripcion").SendKeys("TestIngreso");
            navegador.FindElementById("Monto").SendKeys("100");

            navegador.FindElementById("btnAddGasto").Click();

            var pageId = navegador.FindElementById("ViewIndex");
            Assert.IsNotNull(pageId);

            navegador.Close();


        }
            [Test]
         
        public class TipoCambio : ITipoCambio
        {
            public decimal GetTipoCambioSoles()
            {
                // conectarse a los servidores de sunata para obtener el tipo de cambio actual
                throw new Exception("No nos podemos conectar al servidor de SUNAT");
                return 3.763m;
            }

            public decimal GetTipoCambioEuros()
            {
                // conectarse a los servidores de sunata para obtener el tipo de cambio actual
                // throw new Exception("No nos podemos conectar al servidor de SUNAT");
                return 3.76m;
            }
        }

        public class TipoCambio2 : ITipoCambio
        {
            public decimal GetTipoCambioSoles()
            {
                throw new NotImplementedException();
            }

            public decimal GetTipoCambioEuros()
            {
                throw new NotImplementedException();
            }
        }


    }

    }


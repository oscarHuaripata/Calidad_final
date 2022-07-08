using System.Collections.Generic;
using System.Linq;
using FinancialApp.Tests.Helpers;
using FinancialApp.Web.DB;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Repositories;

public class TipoCuentaRepositorioTest
{
    private IQueryable<TipoCuenta> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<TipoCuenta>
        {
            new() {Id = 1, Nombre = "Credito"},
            new() {Id = 2, Nombre = "Debito"},
        }.AsQueryable();
        
        var mockDbSetTipoCuenta = new MockDBSet<TipoCuenta>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbSetTipoCuenta.Object);
    }
    
    [Test]
    public void ObtenerTodosTestCaso01()
    {
        // var mockDbSetTipoCuenta = new Mock<DbSet<TipoCuenta>>();
        // mockDbSetTipoCuenta.As<IQueryable<TipoCuenta>>().Setup(o => o.Provider).Returns(data.Provider);
        // mockDbSetTipoCuenta.As<IQueryable<TipoCuenta>>().Setup(o => o.Expression).Returns(data.Expression);
        // mockDbSetTipoCuenta.As<IQueryable<TipoCuenta>>().Setup(o => o.ElementType).Returns(data.ElementType);
        // mockDbSetTipoCuenta.As<IQueryable<TipoCuenta>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();
        
        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void ObtenerPorNombreTestCaso01()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPoNombre("Credito");
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void ObtenerPorNombreTestCaso02()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPoNombre("Efectivo");
        
        Assert.AreEqual(0, result.Count);
    }
}

 
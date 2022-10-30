using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class DomainExtensionsTest
{
    [TestMethod]
    public void TestMoneyConversion()
    {
        Money moneyToConvert = new Money(12);
        string currency = "zl";
        
        Money converted = moneyToConvert.ToCurrency(currency);
        
        Assert.AreEqual(new Money(12, "zl"), converted);
    }
    
    [TestMethod]
    public void TestNullCurrencyMoneyConversion()
    {
        Money moneyToConvert = new Money(12);
        string currency = null;
        
        Money converted = moneyToConvert.ToCurrency(currency);
        
        Assert.AreEqual(new Money(12, null), converted);
    }
}
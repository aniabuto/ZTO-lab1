using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class MoneyTest
{
    [TestMethod]
    public void TestOperatorPlusSameCurrency()
    {
        var money1 = new Money(10);
        var money2 = new Money(25);

        var money3 = money1 + money2;

        Assert.AreEqual(new Money(35), money3);
    }
    
    //should it be here?
    // the converter always ignores different currencies
    // but! tested function converts to left operand's currency
    // so we should check if the sum is of the same currency as left operand
    [TestMethod]
    public void TestOperatorPlusDifferentCurrency()
    {
        var money1 = new Money(10, "zl");
        var money2 = new Money(25);

        var money3 = money1 + money2;

        Assert.AreEqual(new Money(35, "zl"), money3);
    }
    
    [TestMethod]
    public void TestOperatorMinusSameCurrency()
    {
        var money1 = new Money(25);
        var money2 = new Money(10);

        var money3 = money1 - money2;

        Assert.AreEqual(new Money(15), money3);
    }
    
    [TestMethod]
    public void TestOperatorMinusDifferentCurrency()
    {
        var money1 = new Money(25, "zl");
        var money2 = new Money(10);

        var money3 = money1 - money2;

        Assert.AreEqual(money3, new Money(15, "zl"));
    }
    
    
}
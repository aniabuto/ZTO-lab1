using NuGet.Frameworks;
using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class InvoiceLineTest
{
    [TestMethod]
    public void TestValidationRulesNullMoneyFail()
    {
        InvoiceLine invoiceLine = new InvoiceLine("name", null);

        bool moneyNullSatisfied = InvoiceLine.ValidationRules.Money.IsSatisfiedBy(invoiceLine);
        
        Assert.IsFalse(moneyNullSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesNameFail()
    {
        InvoiceLine invoiceLine = new InvoiceLine("", null);

        bool nameSatisfied = InvoiceLine.ValidationRules.ProductName.IsSatisfiedBy(invoiceLine);
        
        Assert.IsFalse(nameSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesCurrencyEmptyFail()
    {
        InvoiceLine invoiceLine = new InvoiceLine("", new Money(0, ""));

        bool moneyNotValidSatisfied = InvoiceLine.ValidationRules.Money.IsSatisfiedBy(invoiceLine);
        
        Assert.IsFalse(moneyNotValidSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesProductNamePass()
    {
        InvoiceLine invoiceLine = new InvoiceLine("productName", null);
        
        bool nameSatisfied = InvoiceLine.ValidationRules.ProductName.IsSatisfiedBy(invoiceLine);

        Assert.IsTrue(nameSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesMoneyPass()
    {
        InvoiceLine invoiceLine = new InvoiceLine("", new Money(12));
        
        bool moneyNullSatisfied = InvoiceLine.ValidationRules.Money.IsSatisfiedBy(invoiceLine);
        
        Assert.IsTrue(moneyNullSatisfied);
    }

    [TestMethod]
    public void TestToString()
    {
        InvoiceLine invoiceLine = new InvoiceLine("pName", new Money(12));

        string invoiceLineString = invoiceLine.ToString();
        
        Assert.AreEqual("pName for 12USD", invoiceLineString);
    }

    [TestMethod]
    public void TestInvoice()
    {
        InvoiceLine invoiceLine = new InvoiceLine("pName", new Money(12));
        Invoice invoice = new Invoice("", null, null, null);

        invoiceLine.Invoice = invoice;
        
        Assert.IsNotNull(invoiceLine.Invoice);
    }

}
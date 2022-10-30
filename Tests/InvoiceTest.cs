using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class InvoiceTest
{
    [TestMethod]
    public void TestValidationRulesNumberFail()
    {
        Invoice invoice = new Invoice("", null, null, null);

        bool numberSatisfied = Invoice.ValidationRules.InvoiceNumber.IsSatisfiedBy(invoice);
        
        Assert.IsFalse(numberSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesAddressFail()
    {
        Address address = new Address("addressLine", "city", "state", "");
        Invoice invoice = new Invoice("", null, address, null);

        bool addressSatisfied = Invoice.ValidationRules.BillingAddress.IsSatisfiedBy(invoice);

        Assert.IsFalse(addressSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesRecipientFail()
    {
        Address address = new Address("addressLine", "city", "state", "");
        Recipient recipient = new Recipient("name", address);
        Invoice invoice = new Invoice("", recipient, null, null);
        
        bool recipientSatisfied = Invoice.ValidationRules.Recipient.IsSatisfiedBy(invoice);
        
        Assert.IsFalse(recipientSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesInvoiceLinesFail()
    {
        List<InvoiceLine> invoiceLines = new List<InvoiceLine>();
        invoiceLines.Add(new InvoiceLine("p1", new Money(1)));
        invoiceLines.Add(new InvoiceLine("p2", new Money(2)));
        invoiceLines.Add(new InvoiceLine("p3", new Money(3)));
        invoiceLines.Add(new InvoiceLine("", new Money(4)));
        Invoice invoice = new Invoice("", null, null, invoiceLines);
        
        bool linesSatisfied = Invoice.ValidationRules.Lines.IsSatisfiedBy(invoice);
        
        Assert.IsFalse(linesSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesDiscountFail()
    {
        Invoice invoice = new Invoice("", null, null, null, new Money(0, ""));

        bool discountSatisfied = Invoice.ValidationRules.Discount.IsSatisfiedBy(invoice);
        
        Assert.IsFalse(discountSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesNumberPass()
    {
        Invoice invoice = new Invoice("1", null, null, null);

        bool numberSatisfied = Invoice.ValidationRules.InvoiceNumber.IsSatisfiedBy(invoice);
        
        Assert.IsTrue(numberSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesAddressPass()
    {
        Address address = new Address("addressLine", "city", "state", "zip");
        Invoice invoice = new Invoice("", null, address, null);

        bool addressSatisfied = Invoice.ValidationRules.BillingAddress.IsSatisfiedBy(invoice);
        
        Assert.IsTrue(addressSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesRecipientPass()
    {
        Address address = new Address("addressLine", "city", "state", "zip");
        Recipient recipient = new Recipient("name", address);
        Invoice invoice = new Invoice("", recipient, null, null);

        bool recipientSatisfied = Invoice.ValidationRules.Recipient.IsSatisfiedBy(invoice);

        Assert.IsTrue(recipientSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesDiscountPass()
    {
        Invoice invoice = new Invoice("", null, null, null, new Money(0));

        bool discountSatisfied = Invoice.ValidationRules.Discount.IsSatisfiedBy(invoice);
        
        Assert.IsTrue(discountSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesLinesPass()
    {
        List<InvoiceLine> invoiceLines = new List<InvoiceLine>();
        invoiceLines.Add(new InvoiceLine("p1", new Money(1)));
        invoiceLines.Add(new InvoiceLine("p2", new Money(2)));
        invoiceLines.Add(new InvoiceLine("p3", new Money(3)));
        invoiceLines.Add(new InvoiceLine("p4", new Money(4)));
        Invoice invoice = new Invoice("", null, null, invoiceLines, new Money(0, ""));

        bool linesSatisfied = Invoice.ValidationRules.Lines.IsSatisfiedBy(invoice);
        
        Assert.IsTrue(linesSatisfied);
    }

    [TestMethod]
    public void TestInvoiceAttachLine()
    {
        Invoice invoice = new Invoice();
        InvoiceLine invoiceLine = new InvoiceLine("p1", new Money(1));
        
        invoice.AttachInvoiceLine(invoiceLine);
        
        Assert.AreEqual(1, invoice.Lines.Count);

    }

    [TestMethod]
    public void TestRulesPresent()
    {
        InvoiceMock invoice = new InvoiceMock();
        
        Assert.AreEqual(5, invoice.RulesCount());
    }
}
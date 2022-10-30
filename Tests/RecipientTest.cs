using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class RecipientTest
{
    [TestMethod]
    public void TestValidationNameFail()
    {
        Address address = new Address("addressLine",
            "city", "state", "zip");
        Recipient recipient = new Recipient("", address);

        bool nameSatisfied = Recipient.ValidationRules.Name.IsSatisfiedBy(recipient);

        Assert.IsFalse(nameSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesNamePass()
    {
        Address address = new Address("addressLine", 
            "city", "state", "zip");
        Recipient recipient = new Recipient("name", address);

        bool nameSatisfied = Recipient.ValidationRules.Name.IsSatisfiedBy(recipient);

        Assert.IsTrue(nameSatisfied);
    }

    [TestMethod]
    public void TestValidationAddressFail()
    {
        Address address = new Address("addressLine", 
            "city", "state", "");
        Recipient recipient = new Recipient("name", address);

        bool addressSatisfied = Recipient.ValidationRules.Address.IsSatisfiedBy(recipient);

        Assert.IsFalse(addressSatisfied);
    }
    
    [TestMethod]
    public void TestValidationRulesAddressPass()
    {
        Address address = new Address("addressLine", 
            "city", "state", "zip");
        Recipient recipient = new Recipient("name", address);

        bool addressSatisfied = Recipient.ValidationRules.Address.IsSatisfiedBy(recipient);

        Assert.IsTrue(addressSatisfied);
    }
}
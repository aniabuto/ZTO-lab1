using TDDLab.Core.InvoiceMgmt;

namespace Tests;

[TestClass]
public class AddressTest
{
    [TestMethod]
    public void TestRulesValidationAddressLinePass()
    {
        Address address = new Address("address", "a", "a", "a");
        
        bool addressRuleSatisfied = Address.ValidationRules.AddressLine1.IsSatisfiedBy(address);
        
        Assert.IsTrue(addressRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationAddressLineFail()
    {
        Address address = new Address("", "a", "a", "a");
        
        bool addressLineRuleSatisfied = Address.ValidationRules.AddressLine1.IsSatisfiedBy(address);
        
        Assert.IsFalse(addressLineRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationCityPass()
    {
        Address address = new Address("a", "city", "a", "a");
        
        bool cityRuleSatisfied = Address.ValidationRules.City.IsSatisfiedBy(address);
        
        Assert.IsTrue(cityRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationCityFail()
    {
        Address address = new Address("a", "", "a", "a");
        
        bool cityRuleSatisfied = Address.ValidationRules.City.IsSatisfiedBy(address);
        
        Assert.IsFalse(cityRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationStatePass()
    {
        Address address = new Address("a", "a", "state", "a");
        
        bool stateRuleSatisfied = Address.ValidationRules.State.IsSatisfiedBy(address);
        
        Assert.IsTrue(stateRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationStateFail()
    {
        Address address = new Address("a", "a", "", "a");
        
        bool stateRuleSatisfied = Address.ValidationRules.State.IsSatisfiedBy(address);
        
        Assert.IsFalse(stateRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationZipPass()
    {
        Address address = new Address("a", "a", "a", "zip");
        
        bool zipRuleSatisfied = Address.ValidationRules.Zip.IsSatisfiedBy(address);
        
        Assert.IsTrue(zipRuleSatisfied);
    }
    
    [TestMethod]
    public void TestRulesValidationZipFail()
    {
        Address address = new Address("a", "a", "a", "");
        
        bool zipRuleSatisfied = Address.ValidationRules.Zip.IsSatisfiedBy(address);
        
        Assert.IsFalse(zipRuleSatisfied);
    }
}
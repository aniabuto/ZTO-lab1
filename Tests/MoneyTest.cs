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

    [TestMethod]
    public void TestToString()
    {
        var money = new Money(25, "zl");

        string moneyString = money.ToString();
        
        Assert.AreEqual("25zl", moneyString);
    }

    [TestMethod]
    public void TestValidationRuleFail()
    {
        Money money = new Money(21, "");
        
        bool ruleSatisfied = Money.ValidationRules.Currency.IsSatisfiedBy(money);
        
        Assert.IsFalse(ruleSatisfied);
    }

    [TestMethod]
    public void TestValidationRulePass()
    {
        Money money = new Money(21, "zl");
        
        bool ruleSatisfied = Money.ValidationRules.Currency.IsSatisfiedBy(money);
        
        Assert.IsTrue(ruleSatisfied);
    }

    [TestMethod]
    public void TestIsEqualMoney()
    {
        Money money = new Money(21, "zl");
        Money moneyToCompare = new Money(21, "zl");

        bool areEqual = money.Equals(moneyToCompare);
        
        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public void TestNotEqualMoney()
    {
        Money money = new Money(21, "zl");
        Money moneyToCompare = new Money(21, "pln");

        bool areEqual = money.Equals(moneyToCompare);
        
        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void TestNotEqualObject()
    {
        Money money = new Money(21, "zl");
        var objectToCompare = "21zl";

        bool areEqual = money.Equals(objectToCompare);
        
        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void TestNotNullSameHashCode()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(21, "zl");

        int hash = money.GetHashCode();
        int hash2 = money2.GetHashCode();
        
        Assert.AreEqual(hash, hash2);
    }

    [TestMethod]
    public void TestNotNullDifferentHashCode()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(22, "zl");

        int hash = money.GetHashCode();
        int hash2 = money2.GetHashCode();
        
        Assert.AreNotEqual(hash, hash2);
    }

    [TestMethod]
    public void TestNullHashCode()
    {
        Money money = new Money(21, null);

        int hash = money.GetHashCode();
        int expected = money.Amount.GetHashCode() * 397;
        
        Assert.AreEqual(expected, hash);
    }

    [TestMethod]
    public void TestEqualOperatorSame()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(21, "zl");

        bool areEqual = money == money2;
        
        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public void TestEqualOperatorDifferent()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(23);

        bool areEqual = money == money2;
        
        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void TestNotEqualOperatorSame()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(21, "zl");

        bool areEqual = money != money2;
        
        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void TestNotEqualOperatorDifferent()
    {
        Money money = new Money(21, "zl");
        Money money2 = new Money(23);

        bool areEqual = money != money2;
        
        Assert.IsTrue(areEqual);
    }
}
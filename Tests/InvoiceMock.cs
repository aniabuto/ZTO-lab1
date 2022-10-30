using TDDLab.Core.InvoiceMgmt;

namespace Tests;

public class InvoiceMock : Invoice
{

    public int RulesCount()
    {
        return this.Rules.Count;
    }
    
}
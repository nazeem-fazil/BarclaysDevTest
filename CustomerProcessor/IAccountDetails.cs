using System.Collections.Generic;

namespace CustomerProcessor
{
    public interface IAccountDetails
    {
        string Name { get; }
        decimal Balance { get; }
        IDictionary<string, decimal> Creditors { get; }
    }
}

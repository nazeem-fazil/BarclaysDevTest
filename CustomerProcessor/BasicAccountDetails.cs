using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CustomerProcessor
{
    [Serializable]
    public sealed class BasicAccountDetails : IAccountDetails, ISerializable
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public IDictionary<string, decimal> Creditors { get; private set; }

        
        public BasicAccountDetails(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue(AccountConstants.Name, typeof(string));
            Balance = (decimal)info.GetValue(AccountConstants.Balance, typeof(decimal));
            Creditor[] convertedCreditors = (Creditor[])info.GetValue(AccountConstants.Creditors, typeof(Creditor[]));
            Creditors = convertedCreditors == null ? null : convertedCreditors.ToDictionary(c => c.Name, t => t.Balance);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(AccountConstants.Name, Name);
            info.AddValue(AccountConstants.Balance, Balance);
            Creditor[] convertedCreditors = Creditors == null ? null :
                Creditors.Select(kvp => new Creditor { Name = kvp.Key, Balance = kvp.Value }).ToArray();
            info.AddValue(AccountConstants.Creditors, convertedCreditors);
        }

        [Serializable]
        private class Creditor
        {
            internal string Name { get; set; }
            internal decimal Balance { get; set; }
        }
    }
}

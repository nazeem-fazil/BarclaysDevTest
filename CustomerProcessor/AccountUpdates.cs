using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using FileParser;
using System.Threading.Tasks;

namespace CustomerProcessor
{
    public class AccountUpdates
    {
        public Collection<IAccountDetails> Accounts { get; private set; }

        private AccountUpdates(string path)
        {
            Path = path;
            AccountDetails();
        }

        public void AccountDetails()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(Path);
            ILoader<BasicAccountDetails> loader = new CompressedLoader<BasicAccountDetails>();

            IList<IAccountDetails> details = files.Select(f => (IAccountDetails)loader.FromFile(f)).ToList();
            Accounts = new Collection<IAccountDetails>(details);
        }



        public static AccountUpdates CreateAccountUpdates(string path)
        {
            return new AccountUpdates(path);
        }

        public string Path
        {
            get;
            set;
        }

        public decimal TotalCredit
        {
            get { return Accounts.Where(x => x.Creditors != null).Sum(a => a.Creditors.Sum(s => s.Value)); }
        }
    }
}

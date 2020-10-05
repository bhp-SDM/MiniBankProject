using MiniBank.Core.Model.BE;
using MiniBank.Core.Model.EF;
using System.Collections.Generic;

namespace MiniBank.Core.Model.Entities
{
    public class BankAccount
    {       
        public const double DEFAULT_INTERESTRATE = 0.1;

        public BankAccount()
        {

        }

        public BankAccount(BankAccountBE acc)
        {
            AccountNumber = acc.AccountNumber;
            Balance = acc.Balance;
            InterestRate = acc.InterestRate;
            Customers = new List<Customer>();
            foreach (CustomerBE c in acc.Customers)
                Customers.Add(new Customer(c));

        }

        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }

        public List<Customer> Customers { get; set; }
    }
}

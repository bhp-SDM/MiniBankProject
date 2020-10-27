using MiniBank.Core.Model.EF;
using MiniBank.Core.Model.Entities;
using System.Collections.Generic;

namespace MiniBank.Core.Model.BE
{
    public class BankAccountBE
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public double InterestRate { get; private set; }

        public List<CustomerBE> Customers;
        
        public BankAccountBE(BankAccount acc)
        {
            AccountNumber = acc.AccountNumber;
            //Balance = acc.Balance;
            InterestRate = acc.InterestRate;
            Customers = new List<CustomerBE>();
            foreach (Customer c in acc.Customers)
                Customers.Add(new CustomerBE(c));
        }
    }
}

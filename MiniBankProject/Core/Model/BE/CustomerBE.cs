using MiniBank.Core.Model.EF;
using MiniBank.Core.Model.Entities;
using MiniBank.Core.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Core.Model.BE
{
    public class CustomerBE: Customer
    {
        new public int  Id { get; private set;}
        new public IList<BankAccountBE> Accounts {get; private set;}
        public CustomerBE(Customer c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.Address = c.Address;
            this.ZipCode = c.ZipCode;
            this.City = c.City;
            this.Email = c.Email;
            this.Phone = c.Phone;
            this.Accounts = new List<BankAccountBE>();
            foreach (BankAccount acc in c.Accounts)
                this.Accounts.Add(new BankAccountBE(acc));
        }
    }
}

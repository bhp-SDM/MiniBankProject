using MiniBank.Core.Model.BE;
using MiniBank.Core.Model.Entities;
using System.Collections.Generic;

namespace MiniBank.Core.Model.EF
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IList<BankAccount> Accounts { get; set; }

        public Customer()
        {
        }

        public Customer(CustomerBE c)
        {
            Id = c.Id;
            Name = c.Name;
            Address = c.Address;
            ZipCode = c.ZipCode;
            City = c.City;
            Email = c.Email;
            Phone = c.Phone;
            Accounts = new List<BankAccount>();
            foreach (BankAccountBE acc in c.Accounts)
            {
                Accounts.Add(new BankAccount(acc));
            }

        }
    }
}

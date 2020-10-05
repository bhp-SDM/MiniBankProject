using MiniBank.Core.Model.BE;
using MiniBank.Core.Model.EF;
using MiniBank.Core.Model.Entities;
using MiniBank.Core.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Core.Service
{
    public class BankAccountController : IBankAccountController
    {
        private static int nextAccNumber = 1;

        private IRepository<int, BankAccount> AccountsRepo;
        public BankAccountController(IRepository<int, BankAccount> BankAccountRepository)
        {
            AccountsRepo = BankAccountRepository;
        }

        public void AddCustomerToBankAccount(BankAccount acc, Customer c)
        {
            throw new NotImplementedException();
        }

        public void AddInterestToBankAccount(BankAccount acc)
        {
            throw new NotImplementedException();
        }

        public void CreateBankAccountWithInitialBalance(Customer c)
        {
            throw new NotImplementedException();
        }

        public void CreateBankAccountWithInitialBalanceAndInterestRate(Customer c)
        {
            throw new NotImplementedException();
        }

        public void CreateBankAccountWithInterestRate(Customer c)
        {
            throw new NotImplementedException();
        }

        public void CreateDefaultBankAcccount(CustomerBE cbe)
        {
            BankAccount acc = new BankAccount()
            {
                AccountNumber = nextAccNumber++,
                Balance = 0.0,
                InterestRate = BankAccount.DEFAULT_INTERESTRATE,
                Customers = new List<Customer>() { new Customer(cbe) }
            };
            

            AccountsRepo.Add(acc);

        }

        public void DepositToBankAccount(BankAccount acc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankAccountBE> GetAllBankAccounts()
        {
            throw new NotImplementedException();
        }

        public BankAccountBE GetBankAccountByAccountNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankAccountBE> GetBankAccountsForCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerFromBankAccount(BankAccount acc, Customer c)
        {
            throw new NotImplementedException();
        }

        public void SetInterestRateForBankAccount(BankAccount acc)
        {
            throw new NotImplementedException();
        }

        public void WithdrawFromBankAccount(BankAccount acc)
        {
            throw new NotImplementedException();
        }
    }
}

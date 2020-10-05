using MiniBank.Core.Model.BE;
using MiniBank.Core.Model.EF;
using MiniBank.Core.Model.Entities;
using System.Collections.Generic;

namespace MiniBank.Core.Service
{
    public interface IBankAccountController
    {
        void CreateDefaultBankAcccount(CustomerBE c);
        void CreateBankAccountWithInitialBalance(Customer c);
        void CreateBankAccountWithInterestRate(Customer c);
        void CreateBankAccountWithInitialBalanceAndInterestRate(Customer c);
        void AddCustomerToBankAccount(BankAccount acc, Customer c);
        void RemoveCustomerFromBankAccount(BankAccount acc, Customer c);
        void SetInterestRateForBankAccount(BankAccount acc);
        void DepositToBankAccount(BankAccount acc);
        void WithdrawFromBankAccount(BankAccount acc);
        void AddInterestToBankAccount(BankAccount acc);
        IEnumerable<BankAccountBE> GetAllBankAccounts();
        IEnumerable<BankAccountBE> GetBankAccountsForCustomer(Customer c);
        BankAccountBE GetBankAccountByAccountNumber(int accountNumber);
    }
}

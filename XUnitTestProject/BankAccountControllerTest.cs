using MiniBank.Core.Model.BE;
using MiniBank.Core.Model.EF;
using MiniBank.Core.Model.Entities;
using MiniBank.Core.repositories;
using MiniBank.Core.Service;
using Moq;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class BankAccountControllerTest
    {
        private Dictionary<int, BankAccount> accounts;
        private Mock<IRepository<int, BankAccount>> accountsRepoMock;
        public BankAccountControllerTest()
        {
            // Fake data store.
            accounts = new Dictionary<int, BankAccount>();
  
            // Mock creation and setup
            accountsRepoMock = new Mock<IRepository<int, BankAccount>>();

            accountsRepoMock.Setup(x => x.Add(It.IsAny<BankAccount>())).Callback<BankAccount>((acc) => accounts.Add(acc.AccountNumber, acc));
            accountsRepoMock.Setup(x => x.Update(It.IsAny<BankAccount>())).Callback<BankAccount>((acc) => accounts[acc.AccountNumber] = acc);
            accountsRepoMock.Setup(x => x.Remove(It.IsAny<BankAccount>())).Callback<BankAccount>((acc) => accounts.Remove(acc.AccountNumber));
            accountsRepoMock.Setup(x => x.GetAll()).Returns(accounts.Values);
            accountsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<int>((id) => accounts.ContainsKey(id)? accounts[id]:null);
        }

        [Fact]
        public void CreateBankAccountController()
        {

            IBankAccountController bac = new BankAccountController(accountsRepoMock.Object);
            Assert.Empty(accounts);
        }

        [Fact]
        public void AddValidBankAccount()
        {
            IBankAccountController bac = new BankAccountController(accountsRepoMock.Object);
            Customer customer = new Customer() 
            {
                Id = 1,
                Name = "Test",
                Address = "Test Road 11",
                ZipCode = 1234,
                City = "Test City",
                Email = "test@test.dk",
                Phone = "12345678",
                Accounts = new List<BankAccount>()
            };

            CustomerBE customerBE = new CustomerBE(customer);

            bac.CreateDefaultBankAcccount(customerBE);

            accountsRepoMock.Verify((repo) => repo.Add(It.IsAny<BankAccount>()), Times.Once);

            BankAccount result = accounts.Values.ToList()[0];
            Assert.Equal(1, result.AccountNumber);
            Assert.Equal(0.0, result.Balance);
            Assert.Equal(BankAccount.DEFAULT_INTERESTRATE, result.InterestRate);
            Assert.True(result.Customers.Count == 1);
            Assert.Equal(customer, result.Customers[0]);
        }

    }
}

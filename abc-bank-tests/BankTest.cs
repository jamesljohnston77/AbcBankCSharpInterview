using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class BankTest
    {

        private static readonly double DOUBLE_DELTA = 1e-15;

        [TestMethod]
        public void CustomerSummary() 
        {
            Bank bank = new Bank();
            Customer john = new Customer("john", 8);
            john.OpenAccount(new Account());
            bank.AddCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.CustomerSummary());
        }

        [TestMethod]
        public void CheckingAccount() {
            Bank bank = new Bank();
            Account checkingAccount = new Account();
            checkingAccount.accountType = (int)Account.AccountType.CHECKING;
            Customer bill = new Customer("bill",9);
            bank.AddCustomer(bill);
            Transaction transaction = new Transaction();

            transaction.Deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void Savings_account() {
            Bank bank = new Bank();
            Account checkingAccount = new Account();
            Transaction transaction= new Transaction();
            bank.AddCustomer(new Customer("Test",10));

            transaction.Deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void Maxi_savings_account() {
            Bank bank = new Bank();
            Account checkingAccount = new Account();
            bank.AddCustomer(new Customer("test2",11).OpenAccount(checkingAccount));
            Transaction transaction = new Transaction();

            transaction.Deposit(3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }
    }
}

    }
}

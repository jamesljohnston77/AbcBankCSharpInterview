using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestApp()
        {
            Account checkingAccount = new Account();
            checkingAccount.accountType = 1;
            Account savingsAccount = new Account();
            savingsAccount.accountType = 2;
            Customer henry = new Customer("test3", 12);
            Transaction transaction = new Transaction();

            transaction.Deposit(100.0);
            transaction.Deposit(4000.0);
            transaction
                .Withdraw(200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.GetStatement());
        }

        [TestMethod]
        public void TestOneAccount()
        {
            Customer oscar = new Customer("test4",12).newCustomer("Oscar");
            Account account = new Account();
            account.accountType = (int)Account.AccountType.CHECKING;
            account = account.OpenAccount(oscar, account.accountType);
            Assert.AreEqual(10, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        public void TestTwoAccount()
        {
            Customer oscar = new Customer("test6",13).newCustomer("Oscar");
            Account account = new Account();
            account.accountType = (int)Account.AccountType.CHECKING;
            account = account.OpenAccount(oscar, account.accountType);
            Account account2 = new Account();
            account2.accountType = (int)Account.AccountType.SAVINGS;
            account2 = account2.OpenAccount(oscar, account.accountType);
            Assert.AreEqual(2, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        [Ignore]
        public void TestThreeAccounts()
        {
            Customer oscar = new Customer("test7",14).newCustomer("Oscar");
            Account account = new Account();
            account.accountType = (int)Account.AccountType.CHECKING;
            account = account.OpenAccount(oscar, account.accountType);
            Account account2 = new Account();
            account2.accountType = (int)Account.AccountType.SAVINGS;
            account2 = account2.OpenAccount(oscar, account.accountType);
            Assert.AreEqual(4, oscar.GetNumberOfAccounts());
        }
    }
}

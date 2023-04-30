using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Customer
    {
        private List<Account> accounts;

        public int Id { get; set; } 
        public string Name { get; set; }
        public Account.AccountType account{ get; internal set; }
        public Transaction transaction{ get; internal set; }

        public Customer(String name, int CustomerId)
        {
            this.Name = name;
            this.Id = CustomerId;
            this.accounts = new List<Account>();
        }
        public Customer newCustomer(string name)
        {
            Customer customer = new Customer ( Name = name, Id = 7);
            return customer;
        }
        public String GetName()
        {
            return Name;

        }

        public Customer OpenAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double TotalInterestEarned() 
        {
            double total = 0;
            foreach (Account a in this.accounts)
            {
                total += a.balance;
            }

            //  Balance with interest calculations for accounts



            return total;
        }

        public String GetStatement() 
        {
            String statement = null;
            statement = "Statement for " + Name + "\n";
            double total = 0.0;
            foreach (Account a in this.accounts) 
            {
                statement += "\n" + statementForAccount() + "\n";
                total += a.balance;
            }
            statement += "\nTotal In All Accounts " + ToDollars(total);
            return statement;
        }

        private String statementForAccount()
        {
            String s = "";

            foreach (Account a in this.accounts)
            {
                //Translate to pretty account type
                if (a.accountType == 0)
                {
                    s += "Checking Account\n";
                }
                else if (a.accountType == 1)
                {
                    s += "Savings Account\n";
                }
                else
                { 
                    s += "Maxi Savings Account\n";
                 }
            }

            //Now total up all the transactions
            double total = 0.0;
            List<Transaction> transactions = null;
            transactions.Add((Transaction)from r in transactions
                                          where r.customerId == this.Id
                                          select r);

            foreach (Transaction t in transactions) {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + ToDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + ToDollars(total);
            return s;
        }

        private String ToDollars(double d)
        {
            return String.Format("$%,.2f", Math.Abs(d));
        }
}
}

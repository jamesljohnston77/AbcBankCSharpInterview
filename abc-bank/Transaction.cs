using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Transaction
    {
        public enum TransactionType
        {
            DEPOSIT,
            WITHDRAWAL,
            TRANSFER
        }


        public readonly double amount;
        public int Id { get; set; }
        public int customerId { get; set; }
        public int accountType { get; set; }
        public int transactionType { get; set; }

        private DateTime transactionDate;
        public int GetTransactionType(TransactionType transaction)
        {
            if (transaction == TransactionType.DEPOSIT) return 0;
            else if (transaction == TransactionType.WITHDRAWAL) return 1;
            else return 2;
        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                Deposit(amount);
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                Withdraw(-amount);
            }
        }
        public void Transfer(double amount, Account fromAccount, Account toAccount)
        {
            if (amount <= 0 && fromAccount.balance >= amount)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                Transfer(-amount, fromAccount, toAccount);
            }
        }

        public double TransactionDouble(double amount) 
        {
            this.transactionDate = DateProvider.getInstance().Now();
            return this.amount;
           
        }
    }
}

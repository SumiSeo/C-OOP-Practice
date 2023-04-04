using System;
using System.Collections.Generic;
using System.Text;

//same name space
namespace MySuperBank
{
	public class BankAccount
	{

		//number is only gettable ; property; can't set the number
		public string? AccountNumber { get; }
		public string? Owner { get; set; }
		public decimal Balance { get
			{
				decimal balance = 0;
				foreach (var item in allTransactions)
				{
					balance += item.Amount;
				}
				return balance;
			}  }

		//static : being shared all across the instances
		private static int accountNumberSeed = 1234567890;

		//list of transactions
		private List<Transaction> allTransactions = new List<Transaction>();

		//constructor
		public BankAccount(string name,decimal initialBalance)
		{
			//Bring these arguments and give the value to properties
			Owner = name;
			MakeDeposit(initialBalance, DateTime.Now,"Initial Balance");
			AccountNumber = accountNumberSeed.ToString();
			accountNumberSeed++;
		}

		//history of transactions
		public void MakeDeposit(decimal amount, DateTime date, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
			}
			var deposit = new Transaction(amount, date, note);
			allTransactions.Add(deposit);
		}

        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");

			}
			if(Balance - amount < 0)
			{ 
				//when exception occurs the next line of code does not happen;
				throw new InvalidOperationException("Not sufficient funds for this withdrawl");
			}
			var withdrawl = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawl);
        }

		public string GetAccountHistory()
		{
			var report = new StringBuilder();

			//Header
			report.AppendLine("Date\t\tAmount\tNote");
			foreach (var item in allTransactions)
			{
				//Rows
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
			}
			return report.ToString();
		}
    }
}


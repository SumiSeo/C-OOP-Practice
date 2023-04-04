// See https://aka.ms/new-console-template for more information
using System;

//What is object oriented programming ?
//Grouping all information
//Orienting around objects

namespace MySuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Sumi",10000);
            Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawl(120, DateTime.Now, "Hammock");

            Console.WriteLine(account.GetAccountHistory());

            //try
            //{
            //    account.MakeWithdrawl(75000, DateTime.Now, "Attempt to overdraw");
            //}
            //catch(InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}


            //if catch statements grab the error, the next code line will be excuted



            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch(ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("*****");
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

        }
    }
}




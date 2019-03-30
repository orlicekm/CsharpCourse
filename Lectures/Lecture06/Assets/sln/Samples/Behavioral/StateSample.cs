using System;

namespace Samples.Behavioral
{
    public class StateSample
    {
        public static void Main()
        {
            // Open a new account
            var account = new Account("Jim Johnson");

            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }

    internal abstract class State
    {
        protected Account account;
        protected double balance;
        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        public Account Account
        {
            get => account;
            set => account = value;
        }

        public double Balance
        {
            get => balance;
            set => balance = value;
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }

    internal class RedState : State
    {
        private double serviceFee;

        public RedState(State state)
        {
            balance = state.Balance;
            account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            serviceFee = 15.00;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            amount = amount - serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void StateChangeCheck()
        {
            if (balance > upperLimit) account.State = new SilverState(this);
        }
    }

    internal class SilverState : State
    {
        public SilverState(State state) :
            this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
                account.State = new RedState(this);
            else if (balance > upperLimit) account.State = new GoldState(this);
        }
    }

    internal class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < 0.0)
                account.State = new RedState(this);
            else if (balance < lowerLimit) account.State = new SilverState(this);
        }
    }

    internal class Account
    {
        private string owner;

        public Account(string owner)
        {
            this.owner = owner;
            State = new SilverState(0.0, this);
        }

        public double Balance => State.Balance;
        public State State { get; set; }

        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine($"Deposited {amount:C} --- ");
            Console.WriteLine($" Balance = {Balance:C}");
            Console.WriteLine($" Status = {State.GetType().Name}");
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine($"Withdrew {amount:C} --- ");
            Console.WriteLine($" Balance = {Balance:C}");
            Console.WriteLine($" Status = {State.GetType().Name}\n");
        }

        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine($" Balance = {Balance:C}");
            Console.WriteLine($" Status = {State.GetType().Name}\n");
        }
    }
}
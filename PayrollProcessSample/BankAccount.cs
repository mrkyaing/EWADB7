namespace PayrollProcessSample
{
    public class BankAccount : ICreditCard
    {
        public string AccountNo { get; set; }

        private decimal openingBalance;
        public decimal OpeningBalance
        {
            get { return openingBalance; }
            set
            {
                if (value < 0) throw new ArgumentException("INVALID INPUT AMOUNT");
                openingBalance = value;
            }
        }
        public void Deposit(decimal inputAmount)
        {
            if (inputAmount < 0)
                throw new ArgumentException("Invalid transaction.");
            openingBalance += inputAmount;
        }

        public void Withdraw(decimal inputAmount)
        {
            if (inputAmount < 0)
                throw new ArgumentException("Invalid transaction.");
            if (inputAmount > openingBalance)
                throw new ArgumentException("insufficient ammount");
            openingBalance -= inputAmount;
        }

        public void CheckBalance()=>Console.WriteLine("Your Total balance:"+openingBalance);

        public void GetThaiBAHTExchangeRate(decimal inputAmount)
        {
            Console.WriteLine($"Your Amount in MMK " + (inputAmount * 130));
        }

        public void GetUSDolorExchangeRate(decimal inputAmount)
        {
            Console.WriteLine($"Your Amount in MMK " + (inputAmount * 4500));
        }
    }
}
namespace PayrollProcessSample
{
    public interface ICreditCard
    {
        public void GetUSDolorExchangeRate(decimal inputAmount);
        public void GetThaiBAHTExchangeRate(decimal inputAmount);
    }
}
namespace WeeklyMiniProject_w30_31
{
    public class CurrencyObj // Used to read the XML document of currency exchange rates
    {
        public string CurrencyCode { get; set; }
        public double ExchangeRateFromEUR { get; set; }
        public CurrencyObj(string code, double rate)
        {
            CurrencyCode = code;
            ExchangeRateFromEUR = rate;
        }
    }
}

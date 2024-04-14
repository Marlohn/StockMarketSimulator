namespace StockPairs.Kernel.Application.Dtos
{
    public class StockPairDTO
    {
        public string Name { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public double Price { get; set; }
    }
}
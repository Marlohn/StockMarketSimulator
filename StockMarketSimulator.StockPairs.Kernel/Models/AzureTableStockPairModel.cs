﻿using AzureTables.Connector.Models;

namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class AzureTableStockPairModel : BaseAzureTableModel
    {
        public string Name { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public float Price { get; set; }
    }
}
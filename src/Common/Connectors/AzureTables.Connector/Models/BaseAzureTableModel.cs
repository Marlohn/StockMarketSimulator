using Azure;
using Azure.Data.Tables;

namespace AzureTables.Connector.Models
{
    public abstract class BaseAzureTableModel : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}